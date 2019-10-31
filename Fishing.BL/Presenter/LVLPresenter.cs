using Fishing.BL.Model.Drawer;
using Fishing.BL.Model.EventHelper;
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

        private Drawer drawer;
        private EventHelper evHelper;

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
            evHelper = new EventHelper(v);

            CurLVL.AddDeep();
            CurLVL.SetDeep();
            CurLVL.AddFishes();

            view.RepaintScreen += View_RepaintScreen;
            view.MouseClick += View_MouseLeftClick;
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
        }

        private void View_BaitTimerTick(object sender, EventArgs e)
        {
            //var res = CurLVL.GetFish();
            //if (res.isFish)
            //{
            //    view.StartFishMovesTimer();
            //    if (res.gathering)
            //    {
            //        view.StartGatheringTimer();
            //    }
            //    view.StopBaitTimer();
            //}
        }

        private void View_MainTimerTick(object sender, EventArgs e)
        {
            try
            {
                SetSounderCoord(player.EquipedRoad.CurPoint);
                if (player.EquipedRoad.IsFishAttack)
                {
                    gui.LureDeepValue = player.EquipedRoad.CurrentDeep;                   
                    AutoDecBarValues();
                    if (gui.FLineBarValue > 990)
                    {
                        player.TornFLine();
                        evHelper.AddEventToPlayer(new FLineTornEvent());
                        evHelper.ShowLastEvent();

                        player.EquipedRoad.Image = Roads.road;
                        player.EquipedRoad.FLineIncValue = 0;
                        player.EquipedRoad.RoadIncValue = 0;

                        gui.FLineBarValue = 0;
                        gui.RoadBarValue = 0;

                        sp.Stream = SoundsRes.leskaobr;
                        sp.Play();
                    }
                    if (gui.RoadBarValue > 990)
                    {
                        player.BrokeRoad();
                        evHelper.AddEventToPlayer(new RoadBrokenEvent());
                        evHelper.ShowLastEvent();

                        player.EquipedRoad.Image = Roads.road;
                        player.EquipedRoad.FLineIncValue = 0;
                        player.EquipedRoad.RoadIncValue = 0;

                        gui.FLineBarValue = 0;
                        gui.RoadBarValue = 0;
                    }                   
                }
                if (player.FirstRoad != null && player.FirstRoad.IsFishAttack)
                {
                    player.FirstRoad.CurPoint.Y += player.FirstRoad.Fish.Power.Y;
                    player.FirstRoad.CurPoint.X += player.FirstRoad.Fish.Power.X;
                    CheckBorders(player.FirstRoad.CurPoint, player.FirstRoad);
                }
                if (player.SecondRoad != null && player.SecondRoad.IsFishAttack)
                {
                    player.SecondRoad.CurPoint.Y += player.SecondRoad.Fish.Power.Y;
                    player.SecondRoad.CurPoint.X += player.SecondRoad.Fish.Power.X;
                    CheckBorders(player.SecondRoad.CurPoint, player.SecondRoad);
                }
                if (player.ThirdRoad != null && player.ThirdRoad.IsFishAttack)
                {
                    player.ThirdRoad.CurPoint.Y += player.ThirdRoad.Fish.Power.Y;
                    player.ThirdRoad.CurPoint.X += player.ThirdRoad.Fish.Power.X;
                    CheckBorders(player.ThirdRoad.CurPoint, player.ThirdRoad);
                }
                if (player.EquipedRoad.CurPoint.Y >= NO_WATER_AREA)
                {
                    player.EquipedRoad.IsBaitInWater = false;
                }
                view.UpdateForm();
            }
            catch (NullReferenceException) { }           
        }

        private void View_CountGathering(object sender, EventArgs e)
        {
            if (player.EquipedRoad.IsFishAttack)
            {
                evHelper.AddEventToPlayer(new GatheringEvent());
                evHelper.ShowLastEvent();

                player.EquipedRoad.IsFishAttack = false;
                player.Statistic.GatheringCount++;

                player.EquipedRoad.Image = Roads.road;
                player.EquipedRoad.FLineIncValue = 0;
                player.EquipedRoad.RoadIncValue = 0;

                gui.FLineBarValue = 0;
                gui.RoadBarValue = 0;

                sp.Stream = SoundsRes.sxod;
                sp.Play();

                view.StopGatheringTimer();
            }
        }

        private void View_CountFishMoves(object sender, EventArgs e)
        {
            try
            {
                Random fishMovingX = new Random();
                Random fishMovingY = new Random();
                if (player.FirstRoad != null && player.FirstRoad.IsFishAttack)
                {
                    player.FirstRoad.Fish.Power.X = fishMovingX.Next(-player.FirstRoad.Fish.Power.X, Math.Abs(player.FirstRoad.Fish.Power.X) + 1);
                    player.FirstRoad.Fish.Power.Y = fishMovingY.Next(-Math.Abs(player.FirstRoad.Fish.Power.Y), 2);
                }
                if (player.SecondRoad != null && player.SecondRoad.IsFishAttack)
                {
                    player.SecondRoad.Fish.Power.X = fishMovingX.Next(-player.SecondRoad.Fish.Power.X, Math.Abs(player.SecondRoad.Fish.Power.X) + 1);
                    player.SecondRoad.Fish.Power.Y = fishMovingY.Next(-Math.Abs(player.SecondRoad.Fish.Power.Y), 2);
                }
                if (player.ThirdRoad != null && player.ThirdRoad.IsFishAttack)
                {
                    player.ThirdRoad.Fish.Power.X = fishMovingX.Next(-player.ThirdRoad.Fish.Power.X, Math.Abs(player.ThirdRoad.Fish.Power.X) + 1);
                    player.ThirdRoad.Fish.Power.Y = fishMovingY.Next(-Math.Abs(player.ThirdRoad.Fish.Power.Y), 2);
                }
            }
            catch (NullReferenceException) { }
        }

        private void View_KeyDOWN(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.G:
                        player.EquipedRoad.CurrentDeep = gui.DeepValue - 10;
                        player.EquipedRoad.IsBaitMoving = true;
                        if (player.EquipedRoad.IsFishAttack)
                        {
                            SetRoadBend(player.EquipedRoad, player.EquipedRoad.Fish.Weight, e);
                            player.WindingSpeed = player.EquipedRoad.Assembly.Reel.Power;
                        }
                        else
                        {
                            Player.GetPlayer().WindingSpeed = 1;
                        }
                        DoWiring();
                        IncFLineBarValues();
                        break;

                    case Keys.H:
                        if (player.EquipedRoad.IsFishAttack)
                        {
                            SetRoadBend(player.EquipedRoad, player.EquipedRoad.Fish.Weight, e);
                            player.WindingSpeed = 2;
                            player.EquipedRoad.CurPoint.Y += player.WindingSpeed;
                            IncRoadBarValues();
                        }
                        break;

                    case Keys.Space:
                        if (IsFishAbleToGoIntoFpond())
                        {
                            view.StopBaitTimer();

                            player.EquipedRoad.Image = Roads.road;
                            player.EquipedRoad.FLineIncValue = 0;
                            player.EquipedRoad.RoadIncValue = 0;

                            gui.FLineBarValue = 0;
                            gui.RoadBarValue = 0;

                            gui.CheckNeedsAndClearEventBox();
                            player.Netting.ShowNetting();
                            if (!player.EquipedRoad.Fish.isTrophy())
                            {
                                evHelper.AddEventToPlayer(new FishEvent(player.EquipedRoad.Fish,
                                                                        player.EquipedRoad.Assembly.Lure));
                                evHelper.ShowLastEvent();
                            }
                            else
                            {
                                evHelper.AddEventToPlayer(new TrophyFishEvent(player.EquipedRoad.Fish,
                                                                              player.EquipedRoad.Assembly.Lure));
                                evHelper.ShowLastEvent();
                            }
                            view.CreateCurrentFish(player.EquipedRoad.Fish);
                            player.Statistic.TakenFishesCount++;

                            player.Netting.HideNetting();
                        }
                        break;

                    case Keys.T:
                        if (player.EquipedRoad.IsFishAttack == false)
                        {
                            MakeCast(player.EquipedRoad.LastCastPoint);
                        }
                        break;

                    case Keys.D1:
                        player.SetEquipedRoad(1);
                        AddRoadToGUI();
                        break;

                    case Keys.D2:
                        player.SetEquipedRoad(2);
                        AddRoadToGUI();
                        break;

                    case Keys.D3:
                        player.SetEquipedRoad(3);
                        AddRoadToGUI();
                        break;
                }
            }
            catch (NullReferenceException) { }
        }

        private void View_KeyUP(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.G:
                        if (player.EquipedRoad.IsFishAttack)
                        {
                            SetRoadBendReverse(player.EquipedRoad, player.EquipedRoad.Fish.Weight, e);
                        }
                        player.EquipedRoad.IsBaitMoving = false;
                        player.EquipedRoad.RoadY -= 7;
                        break;

                    case Keys.H:
                        if (player.EquipedRoad.IsFishAttack)
                        {
                            SetRoadBendReverse(player.EquipedRoad, player.EquipedRoad.Fish.Weight, e);
                        }
                        break;
                }
            }
            catch (NullReferenceException) { }
        }

        private void View_MouseLeftClick(object sender, MouseEventArgs e)
        {

            if (player.EquipedRoad.IsFishAttack == false && !IsPointIntersecWithRoadRect(view.CurPoint).IsIntersec)
            {
                MakeCast(view.CurPoint);
            }
            var tup = IsPointIntersecWithRoadRect(view.CurPoint);
            if (tup.IsIntersec)
            {
                player.SetEquipedRoad(tup.Road);
            }
            if (e.Button == MouseButtons.Right)
            {
                var tuple = IsPointIntersecWithRoadRect(view.CurPoint);
                if (tuple.IsIntersec)
                {
                    tuple.Road = null;
                }
            }
        }

        private void View_RepaintScreen(object sender, PaintEventArgs e)
        {
            try
            {
                drawer = new Drawer(e.Graphics);
                drawer.UpdateRectangles();
                drawer.DrawRoads();
                drawer.DrawPoints();
                if (player.EquipedRoad != null)
                {
                    drawer.DrawTrigon();                   
                }
                if (IsFishAbleToGoIntoFpond())
                {
                    drawer.DrawNetting();
                }
            }
            catch (NullReferenceException) { }
        }

        private void SetRoadBend(GameRoad road, int weight, KeyEventArgs e)
        {
            if (player.EquipedRoad.IsFishAttack)
            {
                if (road != null)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.G:
                            if (weight <= road.Assembly.Proad.Power * 0.2)
                            {
                                road.Image = Roads.izg1;
                            }
                            else if (weight <= road.Assembly.Proad.Power * 0.25)
                            {
                                road.Image = Roads.izg2;
                            }
                            else if (weight <= road.Assembly.Proad.Power * 0.3)
                            {
                                road.Image = Roads.izg3;
                            }
                            else if (weight <= road.Assembly.Proad.Power * 0.4)
                            {
                                road.Image = Roads.izg4;
                            }
                            else if (weight >= road.Assembly.Proad.Power * 0.4)
                            {
                                road.Image = Roads.izg5;
                            }
                            break;

                        case Keys.H:
                            if (weight <= road.Assembly.Proad.Power * 0.2)
                            {
                                road.Image = Roads.izg1H;
                            }
                            else if (weight <= road.Assembly.Proad.Power * 0.25)
                            {
                                road.Image = Roads.izg2H;
                            }
                            else if (weight <= road.Assembly.Proad.Power * 0.3)
                            {
                                road.Image = Roads.izg3H;
                            }
                            else if (weight <= road.Assembly.Proad.Power * 0.4)
                            {
                                road.Image = Roads.izg4H;
                            }
                            else if (weight >= road.Assembly.Proad.Power * 0.4)
                            {
                                road.Image = Roads.izg5H;
                            }
                            break;
                    }
                }
                else
                {
                    road.Image = Roads.broken;
                }
            }
        }

        private void SetRoadBendReverse(GameRoad road, int weight, KeyEventArgs e)
        {
            if (road != null)
            {
                if (player.EquipedRoad.IsFishAttack)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.H:
                            if (weight <= road.Assembly.Proad.Power * 0.2)
                            {
                                road.Image = Roads.izg1;
                            }
                            else if (weight <= road.Assembly.Proad.Power * 0.25)
                            {
                                road.Image = Roads.izg2;
                            }
                            else if (weight <= road.Assembly.Proad.Power * 0.3)
                            {
                                road.Image = Roads.izg3;
                            }
                            else if (weight <= road.Assembly.Proad.Power * 0.4)
                            {
                                road.Image = Roads.izg4;
                            }
                            else if (weight >= road.Assembly.Proad.Power * 0.4)
                            {
                                road.Image = Roads.izg5;
                            }
                            break;

                        case Keys.G:
                            if (weight <= road.Assembly.Proad.Power * 0.2)
                            {
                                road.Image = Roads.izg1;
                            }
                            else if (weight <= road.Assembly.Proad.Power * 0.25)
                            {
                                road.Image = Roads.izg2;
                            }
                            else if (weight <= road.Assembly.Proad.Power * 0.3)
                            {
                                road.Image = Roads.izg3;
                            }
                            else if (weight <= road.Assembly.Proad.Power * 0.4)
                            {
                                road.Image = Roads.izg4;
                            }
                            else if (weight >= road.Assembly.Proad.Power * 0.4)
                            {
                                road.Image = Roads.izg5;
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

        private void MakeCast(Point point)
        {
            if (player.IsPlayerAbleToFishing())
            {
                player.EquipedRoad.CurLVL = CurLVL;
                SetSounderCoord(point);
                view.StartMainTimer();
                player.EquipedRoad.RoadX = point.X;
                player.EquipedRoad.StartBaitTimer();

                player.EquipedRoad.IsBaitInWater = true;
                player.EquipedRoad.IsBaitMoving = false;

                if (!player.EquipedRoad.IsFishAttack && !IsPointIntersecWithRoadRect(point).Item1)
                {
                    CheckBorders(point, player.EquipedRoad);
                    player.EquipedRoad.LastCastPoint = point;

                    sp.Stream = SoundsRes.zabr;
                    sp.Play();
                }
                if (!player.EquipedRoad.IsFishAttack)
                {
                    player.EquipedRoad.RoadY = 350;
                    try
                    {
                        if (player.EquipedRoad.Assembly.Lure == null && player.EquipedRoad.Assembly.Proad.Type == ROAD_TYPE.Spinning)
                        {
                            player.EquipedRoad.CurPoint.Y = 0;
                            MessageBox.Show(Messages.NO_LURE_EQUIPED);
                        }
                    }
                    catch (NullReferenceException)
                    {
                        player.EquipedRoad.CurPoint.Y = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("Игрок не готов к рыбалке");
            }
        }

        private void DoWiring()
        {
            if (player.EquipedRoad.RoadY != 357)
            {
                player.EquipedRoad.RoadY += 7;
            }
            if (player.EquipedRoad.IsFishAttack)
            {
                player.WindingSpeed = player.EquipedRoad.Assembly.Reel.Power;
            }
            else
            {
                player.WindingSpeed = 1;
            }
            player.EquipedRoad.CurPoint.Y += Player.GetPlayer().WindingSpeed;
        }

        private void AutoDecBarValues()
        {
            if (gui.FLineBarValue > 0)
            {
                gui.IncrementFLineBarValue(-3);
            }
            if (gui.RoadBarValue > 0)
            {
                gui.IncrementRoadBarValue(-3);
            }
        }

        private void SetSounderCoord(Point point)
        {
            for (int y = 0; y < CurLVL.Height; y++)
            {
                for (int x = 0; x < CurLVL.Widgth; x++)
                {
                    Rectangle r = new Rectangle(CurLVL.Deeparr[x, y].Location, new System.Drawing.Size(CurLVL.Deeparr[x, y].Width, CurLVL.Deeparr[x, y].Height));
                    if (r.IntersectsWith(new Rectangle(point, new System.Drawing.Size(1, 1))))
                    {
                        gui.DeepValue = Convert.ToInt32(CurLVL.Deeparr[x, y].Tag);
                        Sounder.GetSounder().Column = y;
                        Sounder.GetSounder().Row = x;
                    }
                    player.EquipedRoad.CurrentDeep = gui.DeepValue;
                    gui.LureDeepValue = player.EquipedRoad.CurrentDeep;
                }
            }
        }
        private void IncFLineBarValues()
        {
            if (gui.RoadBarValue > 0)
            {
                gui.IncrementRoadBarValue(-(player.EquipedRoad.RoadIncValue));
            }
            if (gui.FLineBarValue < 1000)
            {
                gui.IncrementFLineBarValue(player.EquipedRoad.FLineIncValue);
            }
        }
        private void IncRoadBarValues()
        {
            if (gui.RoadBarValue < 1000)
            {
                gui.IncrementRoadBarValue(player.EquipedRoad.RoadIncValue);
            }
            if (gui.FLineBarValue > 0)
            {
                gui.IncrementFLineBarValue(-(player.EquipedRoad.FLineIncValue));
            }
        }
        private (bool IsIntersec, GameRoad Road) IsPointIntersecWithRoadRect(Point p)
        {
            System.Drawing.Size size = new System.Drawing.Size(1, 1);
            if (drawer.FirstNormalRoad.IntersectsWith(new Rectangle(p, size)) || drawer.FirstBrokenRoad.IntersectsWith(new Rectangle(p, size)))
            {
                if (player.EquipedRoad != player.FirstRoad)
                {
                    AddRoadToGUI();
                }
                return (true, player.FirstRoad);
            }
            if (drawer.SecondNormalRoad.IntersectsWith(new Rectangle(p, size)) || drawer.SecondBrokenRoad.IntersectsWith(new Rectangle(p, size)))
            {
                if (player.EquipedRoad != player.SecondRoad)
                {
                    AddRoadToGUI();
                }
                return (true, player.SecondRoad);
            }
            if (drawer.ThirdNormalRoad.IntersectsWith(new Rectangle(p, size)) || drawer.ThirdBrokenRoad.IntersectsWith(new Rectangle(p, size)))
            {
                if (player.EquipedRoad != player.ThirdRoad)
                {
                    AddRoadToGUI();
                }
                return (true, player.ThirdRoad);
            }

            return (false, null);
        }

        private void AddRoadToGUI()
        {
            gui.BaitPicture = null;
            gui.RoadPicture = null;
            gui.ReelPicture = null;
            gui.FLinePicture = null;
            gui.BaitPicture = player.EquipedRoad.Assembly.Lure.Pict;
            gui.RoadPicture = player.EquipedRoad.Assembly.Proad.Pict;
            gui.ReelPicture = player.EquipedRoad.Assembly.Reel.Pict;
            gui.FLinePicture = player.EquipedRoad.Assembly.FLine.Pict;
            drawer.RTrigon.X = player.EquipedRoad.RoadX + 12;
        }

        private void CheckBorders(Point point, GameRoad road)
        {
            if (point.Y >= CurLVL.Deeparr[0, 0].Location.Y)
            {
                road.CurPoint.Y = point.Y;
            }
            else
            {
                road.CurPoint.Y = CurLVL.Deeparr[0, 0].Location.Y + 3;
            }
            if (point.X >= CurLVL.Deeparr[0, 0].Location.X)
            {
                road.CurPoint.X = point.X;
            }
            if (point.X >= CurLVL.Deeparr[CurLVL.Widgth - 1, 0].Location.X)
            {
                road.CurPoint.X = CurLVL.Deeparr[CurLVL.Widgth - 1, 0].Location.X;
            }
        }

        private bool IsFishAbleToGoIntoFpond()
        {
            if (player.EquipedRoad.IsFishAttack && player.EquipedRoad.CurPoint.Y > 550)
            {
                return true;
            }

            return false;
        }
    }
}