using Fishing.BL.Model.Game;
using Fishing.BL.Model.UserEvent;
using Fishing.BL.Resources.Images;
using Fishing.BL.Resources.Messages;
using Fishing.BL.Resources.Sounds;
using Fishing.View.GUI;
using Fishing.View.LVLS.Ozero;
using Saver.BL.Controller;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fishing.Presenter
{
    public class LVLPresenter : BasePresenter
    {
        private const int NO_WATER_AREA = 570;
        private readonly IGameForm view;
        private readonly IGUIPresenter gui;
        private Player player;
        private SoundPlayer sp;
        public LVL CurLVL { get; set; }
        public LVLPresenter(IGameForm view, IGUIPresenter v, LVL curLVL)
        {
            this.CurLVL = curLVL;
            this.view = view;
            this.gui = v;
            view.LVLPresenter = this;
            view.BackImage = CurLVL.Image;
            view.Open();
            player = Player.GetPlayer();
            sp = new SoundPlayer();

            CurLVL.AddDeep();
            CurLVL.SetDeep();
            CurLVL.AddFishes();
            CurLVL.GatheringisTrue += View_CountGathering;
            CurLVL.StopBaitTimer += View_StopBaitTimer;

            view.RepaintScreen += View_RepaintScreen;
            view.MouseLeftClick += View_MouseLeftClick;
            view.KeyDOWN += View_KeyDOWN;
            view.KeyUP += View_KeyUP;
            view.CountFishMoves += View_CountFishMoves;
            view.CountGathering += View_CountGathering;
            view.MainTimerTick += View_MainTimerTick;
            view.BaitTimerTick += View_BaitTimerTick;
            view.FormClose += View_FormClose;
            view.DecSacietyTimerTick += View_DecSacietyTimerTick;
        }

        private void View_DecSacietyTimerTick(object sender, EventArgs e)
        {
            player.DecSatiety(5);
            gui.EatingBarValue = player.Satiety;
        }

        private void View_FormClose(object sender, EventArgs e)
        {
            BaseController.GetController().SavePlayer();
            Player.GetPlayer().CurPoint = Point.Empty;
            Player.GetPlayer().Assembly = null;
        }

        private void View_BaitTimerTick(object sender, EventArgs e)
        {
            CurLVL.GetFish();
        }

        private void View_StopBaitTimer(object sender, EventArgs e)
        {
            view.StopBaitTimer();
        }

        private void View_MainTimerTick(object sender, EventArgs e)
        {
            try
            {
                gui.LureDeepValue = player.CurrentDeep;
                if (player.IsFishAttack)
                {
                    if (gui.FLineBarValue > 990)
                    {
                        player.AddNewMessage(new FLineTornEvent());
                        gui.AddEventToBox(new FLineTornEvent());
                        gui.FLineBarValue = 0;
                        player.TornFLine();
                        sp.Stream = SoundsRes.leskaobr;
                        sp.Play();
                    }
                    if (gui.RoadBarValue > 990)
                    {
                        player.AddNewMessage(new RoadBrokenEvent());
                        gui.AddEventToBox(new RoadBrokenEvent());
                        gui.RoadBarValue = 0;
                        player.BrokeRoad();
                    }
                    player.CheckXBorders();
                    AutoDecBarValues();
                }
                if (player.IsFishAbleToGoIntoFpond())
                {
                    view.StopMainTimer();
                    player.FLineIncValue = 0;
                    player.RoadIncValue = 0;
                    player.Netting.ShowNetting();
                    player.IsBaitInWater = false;
                    gui.CheckNeedsAndClearEventBox();
                    if (!player.CFish.isTrophy())
                    {
                        player.AddNewMessage(new FishEvent(player.CFish, player.Assembly.Lure));
                        gui.AddEventToBox(new FishEvent(player.CFish, player.Assembly.Lure));
                    }
                    else
                    {
                        player.AddNewMessage(new TrophyFishEvent(player.CFish, player.Assembly.Lure));
                        gui.AddEventToBox(new TrophyFishEvent(player.CFish, player.Assembly.Lure));
                    }
                    Player.GetPlayer().Statistic.TakenFishesCount++;
                    view.CreateCurrentFish();
                    player.Netting.HideNetting();
                }
                if (player.CurPoint.Y >= NO_WATER_AREA)
                {
                    player.IsBaitInWater = false;
                }
                view.UpdateForm();
            }
            catch (NullReferenceException) { }
        }

        private void View_CountGathering(object sender, EventArgs e)
        {
            if (Player.GetPlayer().IsFishAttack == true)
            {
                Player.GetPlayer().AddNewMessage(new GatheringEvent());
                gui.AddEventToBox(new GatheringEvent());
                Player.GetPlayer().IsFishAttack = false;
                Player.GetPlayer().Statistic.GatheringCount++;
                sp.Stream = SoundsRes.sxod;
                sp.Play();
                view.StopGatheringTimer();
            }
        }

        private void View_CountFishMoves(object sender, EventArgs e)
        {
            Player player = Player.GetPlayer();
            Random fishMovingX = new Random();
            Random fishMovingY = new Random();
            if (player.IsFishAttack)
            {
                player.CFish.Power.X = fishMovingX.Next(-player.CFish.Power.X, Math.Abs(player.CFish.Power.X) + 1);
                player.CFish.Power.Y = fishMovingY.Next(-Math.Abs(player.CFish.Power.Y), 2);
            }
        }

        private void View_KeyDOWN(object sender, KeyEventArgs e)
        {
            Player player = Player.GetPlayer();
            for (int y = 0; y < CurLVL.Height; y++)
            {
                for (int x = 0; x < CurLVL.Widgth; x++)
                {
                    Point between = new Point(player.CurPoint.X - CurLVL.Deeparr[x, y].Location.X,
                                                player.CurPoint.Y - CurLVL.Deeparr[x, y].Location.Y);
                    float distance = (float)Math.Sqrt(between.X * between.X + between.Y * between.Y);
                    if (distance < 20)
                    {
                        gui.DeepValue = Convert.ToInt32(CurLVL.Deeparr[x, y].Tag);
                        Sounder.GetSounder().Column = y;
                        Sounder.GetSounder().Row = x;
                    }
                    player.CurrentDeep = gui.DeepValue - 1 * 10;
                }
            }
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.G:
                        Player.GetPlayer().IsBaitMoving = true;
                        if (Player.GetPlayer().RoadY != 357)
                        {
                            Player.GetPlayer().RoadY += 7;
                        }
                        if (Player.GetPlayer().IsFishAttack)
                        {
                            Player.GetPlayer().WindingSpeed = Player.GetPlayer().Assembly.Reel.Power;
                            if (player.IsFishAttack)
                            {
                                SetRoadBend(player.Assembly.Proad, player.CFish.Weight, e);
                                Pictures.roadMaxBend = Images.road2;
                                if (gui.RoadBarValue > 0)
                                {
                                    gui.IncrementRoadBarValue(-(player.RoadIncValue));
                                }
                                if (gui.FLineBarValue < 1000)
                                {
                                    gui.IncrementFLineBarValue(player.FLineIncValue);
                                }
                            }
                        }
                        else
                        {
                            Player.GetPlayer().WindingSpeed = 1;
                        }
                        DoWiring();

                        break;

                    case Keys.H:
                        if (player.IsFishAttack)
                        {
                            SetRoadBend(player.Assembly.Proad, player.CFish.Weight, e);
                            player.WindingSpeed = 2;
                            player.CurPoint.Y += player.WindingSpeed;
                            if (gui.RoadBarValue < 1000)
                            {
                                gui.IncrementRoadBarValue(player.RoadIncValue);
                            }
                            if (gui.FLineBarValue > 0)
                            {
                                gui.IncrementFLineBarValue(-(player.FLineIncValue));
                            }
                        }
                        break;

                    case Keys.Space:
                        if (player.CurPoint.Y > 570)
                        {
                            player.Netting.ShowNetting();
                        }
                        break;

                    case Keys.T:
                        player.CurPoint = player.IsFishAttack == false ? player.LastCastPoint : Point.Empty;
                        player.LastCastPoint = player.CurPoint;
                        MakeCast(player.LastCastPoint);
                        break;
                }
            }
            catch (NullReferenceException) { }
        }

        private void View_KeyUP(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.G:
                    if (player.IsFishAttack)
                    {
                        SetRoadBendReverse(player.Assembly.Proad, player.CFish.Weight, e);
                    }
                    Player.GetPlayer().IsBaitMoving = false;
                    Player.GetPlayer().WindingSpeed = 0;
                    Player.GetPlayer().RoadY -= 7;
                    break;

                case Keys.H:
                    if (player.IsFishAttack)
                    {
                        SetRoadBendReverse(player.Assembly.Proad, player.CFish.Weight, e);
                    }
                    break;
            }
        }

        private void View_MouseLeftClick(object sender, EventArgs e)
        {
            MakeCast(view.CurPoint);
        }

        private void View_RepaintScreen(object sender, PaintEventArgs e)
        {
            try
            {
                Player player = Player.GetPlayer();
                Rectangle NormalRoad = new Rectangle(player.CurPoint.X, player.RoadY, Pictures.road.Width, 257);
                Rectangle BrokenRoad = new Rectangle(player.RoadX - 10, player.RoadY, Pictures.izgRoad.Width, 257);
                Rectangle Netting = new Rectangle(player.CurPoint.X, -300, 60, 200);
                Rectangle RTrigon = new Rectangle(player.RoadX + 12, 585, 18, 18);
                Graphics g = e.Graphics;
                SolidBrush sbrush = new SolidBrush(Color.White);
                if (player.IsFishAttack == true)
                {
                    player.CurPoint.X += player.CFish.Power.X;
                    player.CurPoint.Y += player.CFish.Power.Y;
                }
                if (player.IsFishAbleToGoIntoFpond())
                    g.DrawImage(Pictures.netting, Netting);

                if (!player.IsFishAttack && player.Assembly.Proad != null)
                {
                    g.DrawImage(Pictures.road, NormalRoad);
                    player.RoadX = player.CurPoint.X;
                }
                if (player.IsFishAttack && player.Assembly.Proad != null)
                {
                    g.DrawImage(Pictures.izgRoad, BrokenRoad);
                }
                if (player.CurPoint.Y >= CurLVL.Deeparr[0, 0].Location.Y && player.Assembly.Proad != null)
                {
                    g.DrawEllipse(new Pen(sbrush), player.CurPoint.X, player.CurPoint.Y, 4, 4);
                    g.FillEllipse(sbrush, player.CurPoint.X, player.CurPoint.Y, 4, 4);
                    g.DrawImage(Pictures.trigon, RTrigon);
                }
                else if (player.CurPoint.Y < CurLVL.Deeparr[0, 0].Location.Y && player.CurPoint.Y != 0 && player.Assembly.Proad != null)
                {
                    player.CurPoint.Y = CurLVL.Deeparr[0, 0].Location.Y + 5;
                    g.DrawEllipse(new Pen(sbrush), player.CurPoint.X, player.CurPoint.Y, 4, 4);
                    g.FillEllipse(sbrush, player.CurPoint.X, player.CurPoint.Y, 4, 4);
                }
            }
            catch (NullReferenceException) { }
        }

        private void SetRoadBend(Road road, int weight, KeyEventArgs e)
        {
            if (Player.GetPlayer().IsFishAttack)
            {
                if (road != null)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.G:
                            if (weight <= road.Power * 0.2)
                            {
                                Pictures.izgRoad = Roads.izg1;
                            }
                            else if (weight <= road.Power * 0.25)
                            {
                                Pictures.izgRoad = Roads.izg2;
                            }
                            else if (weight <= road.Power * 0.3)
                            {
                                Pictures.izgRoad = Roads.izg3;
                            }
                            else if (weight <= road.Power * 0.4)
                            {
                                Pictures.izgRoad = Roads.izg4;
                            }
                            else if (weight >= road.Power * 0.4)
                            {
                                Pictures.izgRoad = Roads.izg5;
                            }
                            break;

                        case Keys.H:
                            if (weight <= road.Power * 0.2)
                            {
                                Pictures.izgRoad = Roads.izg1H;
                            }
                            else if (weight <= road.Power * 0.25)
                            {
                                Pictures.izgRoad = Roads.izg2H;
                            }
                            else if (weight <= road.Power * 0.3)
                            {
                                Pictures.izgRoad = Roads.izg3H;
                            }
                            else if (weight <= road.Power * 0.4)
                            {
                                Pictures.izgRoad = Roads.izg4H;
                            }
                            else if (weight >= road.Power * 0.4)
                            {
                                Pictures.izgRoad = Roads.izg5H;
                            }
                            break;
                    }
                }
                else
                {
                    Pictures.izgRoad = Roads.broken;
                }
            }
        }

        private void SetRoadBendReverse(Road road, int weight, KeyEventArgs e)
        {
            if (road != null)
            {
                if (player.IsFishAttack)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.H:
                            if (weight <= road.Power * 0.2)
                            {
                                Pictures.izgRoad = Roads.izg1;
                            }
                            else if (weight <= road.Power * 0.25)
                            {
                                Pictures.izgRoad = Roads.izg2;
                            }
                            else if (weight <= road.Power * 0.3)
                            {
                                Pictures.izgRoad = Roads.izg3;
                            }
                            else if (weight <= road.Power * 0.4)
                            {
                                Pictures.izgRoad = Roads.izg4;
                            }
                            else if (weight >= road.Power * 0.4)
                            {
                                Pictures.izgRoad = Roads.izg5;
                            }
                            break;

                        case Keys.G:
                            if (weight <= road.Power * 0.2)
                            {
                                Pictures.izgRoad = Roads.izg1;
                            }
                            else if (weight <= road.Power * 0.25)
                            {
                                Pictures.izgRoad = Roads.izg2;
                            }
                            else if (weight <= road.Power * 0.3)
                            {
                                Pictures.izgRoad = Roads.izg3;
                            }
                            else if (weight <= road.Power * 0.4)
                            {
                                Pictures.izgRoad = Roads.izg4;
                            }
                            else if (weight >= road.Power * 0.4)
                            {
                                Pictures.izgRoad = Roads.izg5;
                            }
                            break;
                    }
                }
            }
            else
            {
                Pictures.izgRoad = Roads.broken;
            }
        }

        private void AutoDecBarValues()
        {
            if (gui.FLineBarValue > 0)
                gui.IncrementFLineBarValue(-3);
            if (gui.RoadBarValue > 0)
                gui.IncrementRoadBarValue(-3);
        }

        private void MakeCast(Point point)
        {
            try
            {
                if (player.IsPlayerAbleToFishing())
                {
                    view.StartMainTimer();
                    for (int y = 0; y < CurLVL.Height; y++)
                    {
                        for (int x = 0; x < CurLVL.Widgth; x++)
                        {
                            Point between = new Point(point.X - CurLVL.Deeparr[x, y].Location.X,
                                                        point.Y - CurLVL.Deeparr[x, y].Location.Y);
                            float distance = (float)Math.Sqrt(between.X * between.X + between.Y * between.Y);
                            if (distance < 20)
                            {
                                gui.DeepValue = Convert.ToInt32(CurLVL.Deeparr[x, y].Tag);
                                Sounder.GetSounder().Column = y;
                                Sounder.GetSounder().Row = x;
                            }
                        }
                    }
                    player.IsBaitInWater = true;
                    player.CurrentDeep = gui.DeepValue;
                    player.IsBaitMoving = false;
                    if (!player.IsFishAttack && player.Assembly != null)
                    {
                        if (point.Y >= CurLVL.Deeparr[0, 0].Location.Y)
                        {
                            player.CurPoint.Y = point.Y;
                        }
                        else
                        {
                            player.CurPoint.Y = CurLVL.Deeparr[0, 0].Location.Y + 3;
                        }
                        if (point.X >= CurLVL.Deeparr[0, 0].Location.X)
                        {
                            player.CurPoint.X = point.X;
                        }
                        else
                        {
                            player.CurPoint.X = CurLVL.Deeparr[0, 0].Location.X + 5;
                        }

                        player.LastCastPoint = point;
                        sp.Stream = SoundsRes.zabr;
                        sp.Play();
                    }

                    if (!player.IsFishAttack)
                    {
                        if (player.Assembly.Proad != null)
                        {
                            view.StopBaitTimer();
                            player.RoadY = 350;
                            gui.FLineBarValue = 0;
                            gui.RoadBarValue = 0;
                            player.WindingSpeed = 0;
                        }
                        if (player.Assembly.Lure != null)
                        {
                            view.StartBaitTimer();
                        }
                        try
                        {
                            if (player.Assembly.Lure is null && player.Assembly.Proad.Type == ROAD_TYPE.Spinning)
                            {
                                player.CurPoint.Y = 0;
                                MessageBox.Show(Messages.NO_LURE_EQUIPED);
                            }
                        }
                        catch (NullReferenceException)
                        {
                            player.CurPoint.Y = 0;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Игрок не готов к рыбалке");
                }
            }
            catch (NullReferenceException) { }
        }

        private void DoWiring()
        {
            if (Player.GetPlayer().IsFishAttack)
            {
                Player.GetPlayer().WindingSpeed = Player.GetPlayer().Assembly.Reel.Power;
            }
            else
            {
                Player.GetPlayer().WindingSpeed = 1;
            }
            Player.GetPlayer().CurPoint.Y += Player.GetPlayer().WindingSpeed;
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }
    }
}