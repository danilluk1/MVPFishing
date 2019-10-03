﻿using Fishing.BL.Model.Game;
using Fishing.BL.Model.Lures;
using Fishing.BL.Model.UserEvent;
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
    public class LVLPresenter : Presenter
    {
        readonly ILVL view;
        readonly IGUIPresenter gui;
        public LVL CurLVL { get; set; }

        public event EventHandler StartBaitTimer;
        public event EventHandler StopBaitTimer;
        public event EventHandler StopGatheringTimer;
        public event EventHandler RefreshForm;
        public event EventHandler CreateCurrentFishF;

        public LVLPresenter(ILVL view, IGUIPresenter v, LVL curLVL)
        {
            this.CurLVL = curLVL;
            this.view = view;
            this.gui = v;

            CurLVL.AddDeep();
            gui.AddLabels(LVL2.GetLVL().Deeparr);
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
        }

        private void View_FormClose(object sender, EventArgs e)
        {
            BaseController.GetController().SavePlayer();
        }

        private void View_BaitTimerTick(object sender, EventArgs e)
        {
            CurLVL.GetFish();
        }

        private void View_StopBaitTimer(object sender, EventArgs e)
        {
            StopBaitTimer?.Invoke(this, EventArgs.Empty);
        }

        private void View_MainTimerTick(object sender, EventArgs e)
        {
            try
            {
                Player player = Player.GetPlayer();
                gui.LureDeepValue = player.CurrentDeep;
                SetRightDeepByType(player.Assembly.Lure.DeepType);
                player.CheckXBorders();
                AutoDecBarValues();
                if (gui.FLineBarValue > 98)
                {
                    player.AddNewMessage(new FLineTornEvent());
                    gui.AddEventToBox(new FLineTornEvent());
                    player.TornFLine();
                }
                if (gui.RoadBarValue > 98)
                {
                    player.AddNewMessage(new RoadBrokenEvent());
                    gui.AddEventToBox(new RoadBrokenEvent());
                    player.BrokeRoad();
                }
                RefreshForm?.Invoke(this, EventArgs.Empty);
                if (player.IsFishAbleToGoIntoFpond())
                {
                    int imageindex = 0;
                    if (player.Assembly.Lure is Wobbler)
                    {
                        imageindex = 4;
                    }
                    if (player.Assembly.Lure is Shaker)
                    {
                        imageindex = 2;
                    }
                    if (player.Assembly.Lure is Pinwheel)
                    {
                        imageindex = 3;
                    }
                    gui.CheckNeedsAndClearEventBox();
                    if (!player.CFish.isTrophy())
                    {
                        player.AddNewMessage(new FishEvent(player.CFish, imageindex));
                        gui.AddEventToBox(new FishEvent(player.CFish, imageindex));
                    }
                    else
                    {
                        player.AddNewMessage(new TrophyFishEvent(player.CFish, imageindex));
                        gui.AddEventToBox(new TrophyFishEvent(player.CFish, imageindex));
                    }
                    Player.GetPlayer().Statistic.TakenFishesCount++;
                    CreateCurrentFishF?.Invoke(this, EventArgs.Empty);
                    player.Netting.HideNetting();
                }
            }
            catch (NullReferenceException) { }
        }

        private void View_CountGathering(object sender, EventArgs e)
        {
            if (Player.GetPlayer().isFishAttack == true)
            {
                StopGatheringTimer?.Invoke(this, EventArgs.Empty);
                Player.GetPlayer().AddNewMessage(new GatheringEvent());
                gui.AddEventToBox(new GatheringEvent());
                Player.GetPlayer().isFishAttack = false;
                Player.GetPlayer().Statistic.GatheringCount++;
            }
        }

        private void View_CountFishMoves(object sender, EventArgs e)
        {
            Player player = Player.GetPlayer();
            Random fishMoving = new Random();
            if (player.isFishAttack)
            {
                player.CFish.Power = fishMoving.Next(-player.CFish.Power, Math.Abs(player.CFish.Power));
            }
        }

        private void View_KeyDOWN(object sender, KeyEventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            Player player = Player.GetPlayer();
            for(int y = 0; y < CurLVL.Height; y++)
            {
                for (int x = 0; x < CurLVL.Widgth; x++)
                {
                    Point between = new Point(player.CurPoint.X - CurLVL.Deeparr[x, y].Location.X,
                                                player.CurPoint.Y - CurLVL.Deeparr[x, y].Location.Y);
                    float distance = (float)Math.Sqrt(between.X * between.X + between.Y * between.Y);
                    if (distance <= 20)
                    {
                        gui.DeepValue = Convert.ToInt32(CurLVL.Deeparr[x, y].Tag);
                        Sounder.GetSounder().Column = y;
                        Sounder.GetSounder().Row = x;
                    }
                    player.CurrentDeep = gui.DeepValue;
                }
            }
            switch (e.KeyCode)
            {
                case Keys.G:
                    DoWiring(Player.GetPlayer().Assembly.Lure.DeepType);
                    if (player.RoadY < 477)
                        player.RoadY += 7;
                    if (player.isFishAttack)
                    {
                        if (gui.FLineBarValue < 100)
                        {
                            gui.IncrementFLineBarValue(Player.GetPlayer().IncValue);
                        }
                        if (gui.RoadBarValue > 0)
                        {
                            gui.IncrementRoadBarValue(-(Player.GetPlayer().IncValue));
                        }
                    }
                    break;
                case Keys.H:
                    if (player.isFishAttack)
                    {
                        if (gui.RoadBarValue < 100)
                        {
                            gui.IncrementRoadBarValue(Player.GetPlayer().IncValue);
                        }
                        if (gui.FLineBarValue > 0)
                        {
                            gui.IncrementFLineBarValue(-(Player.GetPlayer().IncValue));
                        }
                    }
                    break;
                case Keys.Space:
                    if (player.CurPoint.Y > 620)
                    {
                        player.Netting.ShowNetting();
                    }
                    break;
                case Keys.T:
                    player.CurPoint = player.isFishAttack == false ? player.LastCastPoint : Point.Empty;
                    player.LastCastPoint = player.CurPoint;
                    MakeCast(player.LastCastPoint);
                    break;
            }
        }

        private void View_KeyUP(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.G:
                    Player.GetPlayer().IsBaitMoving = false;
                    Player.GetPlayer().WindingSpeed = 0;
                    Player.GetPlayer().RoadY -= 7;
                    break;
                case Keys.H:

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
                Rectangle NormalRoad = new Rectangle(player.CurPoint.X, player.RoadY, 33, 257);
                Rectangle BrokenRoad = new Rectangle(player.RoadX, player.RoadY, 87, 257);
                Rectangle Netting = new Rectangle(player.CurPoint.X, -300, 60, 200);
                Graphics g = e.Graphics;
                SolidBrush sbrush = new SolidBrush(Color.White);
                if (player.isFishAttack == true)
                {
                    player.CurPoint.X += player.CFish.Power;
                    player.CurPoint.Y += -player.CFish.Power;
                }
                if (player.CFish != null)
                    g.DrawImage(Pictures.netting, Netting);

                if (!player.isFishAttack && player.Assembly.Proad != null)
                {
                    g.DrawImage(Pictures.road, NormalRoad);
                    player.RoadX = player.CurPoint.X;
                }
                if (player.isFishAttack && player.Assembly.Proad != null)
                {
                    g.DrawImage(Pictures.roadMaxBend, BrokenRoad);
                }
                if (player.CurPoint.Y >= CurLVL.Deeparr[0, 0].Location.Y && player.Assembly.Proad != null)
                {
                    g.DrawEllipse(new Pen(sbrush), player.CurPoint.X, player.CurPoint.Y, 4, 4);
                    g.FillEllipse(sbrush, player.CurPoint.X, player.CurPoint.Y, 4, 4);
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
        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        private void AutoDecBarValues()
        {
            if (gui.FLineBarValue > 0)
                gui.IncrementFLineBarValue(-1);
            if (gui.RoadBarValue > 0)
                gui.IncrementRoadBarValue(-1);
        }

        private void MakeCast(Point point)
        {
            try
            {
                Player player = Player.GetPlayer();
                player.IsBaitMoving = false;
                SoundPlayer sp = new SoundPlayer();
                if (!player.isFishAttack && player.Assembly != null)
                {
                    if (point.Y >= CurLVL.Deeparr[0, 0].Location.Y)
                    {
                        player.CurPoint = point;
                    }
                    else
                    {
                        player.CurPoint.Y = CurLVL.Deeparr[0, 0].Location.Y + 1;
                        player.CurPoint.X = point.X;
                    }
                    player.LastCastPoint = point;
                    sp.Stream = SoundsRes.zabr;
                    sp.Play();
                }
                for (int y = 0; y < CurLVL.Height; y++)
                {
                    for (int x = 0; x < CurLVL.Widgth; x++)
                    {
                        Point between = new Point(point.X - CurLVL.Deeparr[x, y].Location.X,
                                                    point.Y - CurLVL.Deeparr[x, y].Location.Y);
                        float distance = (float)Math.Sqrt(between.X * between.X + between.Y * between.Y);
                        if (distance <= 20)
                        {
                            gui.DeepValue = Convert.ToInt32(CurLVL.Deeparr[x, y].Tag);
                            Sounder.GetSounder().Column = y;
                            Sounder.GetSounder().Row = x;
                        }
                    }
                }
                if (!player.isFishAttack)
                {
                    if (player.Assembly.Proad != null)
                    {
                        StartBaitTimer?.Invoke(this, EventArgs.Empty);
                        player.RoadY = 470;
                        gui.FLineBarValue = 0;
                        gui.RoadBarValue = 0;
                        player.WindingSpeed = 0;
                    }
                    if (!(player.Assembly.Lure is null))
                    {
                        StartBaitTimer?.Invoke(this, EventArgs.Empty);
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
                player.CurrentDeep = 0;
            }
            catch (NullReferenceException) { }
        }

        void DoWiring(DeepType type)
        {
            Player.GetPlayer().IsBaitMoving = true;
            if (Player.GetPlayer().isFishAttack)
            {
                Player.GetPlayer().WindingSpeed = Player.GetPlayer().Assembly.Reel.Power;
            }
            else
            {
                Player.GetPlayer().WindingSpeed = gui.SpeedValue;
            }
            switch (type)
            {
                case DeepType.Deep:
                    Player.GetPlayer().CurrentDeep -= 80;
                    break;
                case DeepType.Flying:
                    if (Player.GetPlayer().isFishAttack)
                    {
                        Player.GetPlayer().WindingSpeed = Player.GetPlayer().Assembly.Reel.Power;
                    }
                    else
                    {
                        Player.GetPlayer().WindingSpeed = gui.SpeedValue;
                    }
                    break;
                case DeepType.Top:
                    Player.GetPlayer().CurrentDeep = 20;
                    break;
            }
            Player.GetPlayer().CurPoint.Y += Player.GetPlayer().WindingSpeed;
        }

        void SetRightDeepByType(DeepType type)
        {
            switch (type)
            {
                case DeepType.Deep:
                    if (Player.GetPlayer().CurrentDeep < gui.DeepValue && !Player.GetPlayer().IsBaitMoving)
                    {
                        Player.GetPlayer().CurrentDeep += 10;
                    }
                    break;
                case DeepType.Flying:
                    if(Player.GetPlayer().CurrentDeep < gui.DeepValue / 2 && !Player.GetPlayer().IsBaitMoving)
                    {
                        Player.GetPlayer().CurrentDeep += 10;
                    }
                    break;
                case DeepType.Top:
                    Player.GetPlayer().CurrentDeep = 20;
                    break;
            }
        }
    }
}
