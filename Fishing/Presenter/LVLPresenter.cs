using Fishing.Resources;
using Fishing.View.GUI;
using Fishing.View.LVLS.Ozero;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.Presenter
{
    class LVLPresenter : Presenter
    {
        ILVL view;
        IGUIPresenter gui;
        
        public event EventHandler StartBaitTimer;
        public event EventHandler StopGatheringTimer;
        public LVLPresenter(ILVL view, IGUIPresenter v)
        {
            this.view = view;
            this.gui = v;
            view.RepaintScreen += View_RepaintScreen;
            view.MouseLeftClick += View_MouseLeftClick;
            view.KeyDOWN += View_KeyDOWN;
            view.KeyUP += View_KeyUP;
            view.CountFishMoves += View_CountFishMoves;
            view.CountGathering += View_CountGathering;
            view.MainTimerTick += View_MainTimerTick;
        }

        private void View_MainTimerTick(object sender, EventArgs e)
        {
            LVL.lvl2.MainTimertick();
        }

        private void View_CountGathering(object sender, EventArgs e)
        {

            if (Player.getPlayer().isFishAttack == true)
            {
                gui.AddEventToBox(Player.getPlayer().NickName + " Сход =(");
                Player.getPlayer().isFishAttack = false;
                StopGatheringTimer?.Invoke(this, EventArgs.Empty);
            }
        }

        private void View_CountFishMoves(object sender, EventArgs e)
        {
            Player player = Player.getPlayer();
            Random fishMoving = new Random();
            if (player.isFishAttack)
            {
                player.CFish.Power = fishMoving.Next(-player.CFish.Power, Math.Abs(player.CFish.Power));
            }
        }

        private void View_KeyDOWN(object sender, KeyEventArgs e)
        {
            Player player = Player.getPlayer();
            for (int x = 0; x < 51; x++)
            {
                for (int y = 0; y < 18; y++)
                {
                    Point between = new Point(player.CurPoint.X - LVL.Deeparr[x, y].Location.X,
                                                player.CurPoint.Y - LVL.Deeparr[x, y].Location.Y);
                    float distance = (float)Math.Sqrt(between.X * between.X + between.Y * between.Y);
                    if (distance < 20)
                    {
                        gui.DeepValue = Convert.ToInt32(LVL.Deeparr[x, y].Tag);
                        Sounder.setY(x);
                        Sounder.setX(y);
                    }
                    player.CurrentDeep = Convert.ToInt32(gui.DeepValue);
                }
            }
            switch (e.KeyCode)
            {
                case Keys.G:
                    player.IsBaitMoving = true;
                    if (player.isFishAttack)
                        player.WindingSpeed = player.Reel.Power;
                    else
                        player.WindingSpeed = gui.SpeedValue;

                    player.CurPoint.Y += player.WindingSpeed;

                    if (player.RoadY < 477)
                        player.RoadY += 7;
                    if (player.isFishAttack)
                    {
                        if (gui.FLineBarValue < 100)
                            gui.IncrementFLineBarValue(player.CFish.Weight * 20 / 
                                (player.Fline.Power));
                        if (gui.RoadBarValue > 0)
                            gui.IncrementRoadBarValue(-(player.CFish.Weight * 20 / 
                                (player.Road.Power)));
                    }
                    break;
                case Keys.H:
                    if (player.isFishAttack)
                    {
                        if (gui.RoadBarValue < 100)
                            gui.IncrementRoadBarValue(player.CFish.Weight * 20 / 
                                (player.Road.Power));
                        if (gui.FLineBarValue > 0)
                            gui.IncrementFLineBarValue(-(player.CFish.Weight * 20 
                                / (player.Fline.Power)));
                    }
                    break;
                case Keys.Space:
                    if (player.CurPoint.Y > 620)
                    {
                        player.NettingY = 550;
                    }
                    break;
                case Keys.T:
                    player.CurPoint = player.isFishAttack == false ? player.LastCastPoint : Point.Empty;
                    break;
            }
        }

        private void View_KeyUP(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.G:
                    Player.getPlayer().IsBaitMoving = false;
                    Player.getPlayer().WindingSpeed = 0;
                    Player.getPlayer().RoadY -= 7;
                    break;
                case Keys.H:

                    break;
            }
        }

        private void View_MouseLeftClick(object sender, EventArgs e)
        {
            Player player = Player.getPlayer();
            if (!player.isFishAttack && player.Road != null)
            {
                player.CurPoint = view.CurPoint;
                player.LastCastPoint = view.CurPoint;
            }
             for (int x = 0; x < 51; x++)
             {
                for (int y = 0; y < 18; y++)
                {
                    Point between = new Point(player.CurPoint.X - LVL.Deeparr[x, y].Location.X,
                                                player.CurPoint.Y - LVL.Deeparr[x, y].Location.Y);
                    float distance = (float)Math.Sqrt(between.X * between.X + between.Y * between.Y);
                    if (distance < 20)
                    {
                        if (player.Lure != null)
                        {
                            gui.DeepValue = Convert.ToInt32(LVL.Deeparr[x, y].Tag);
                            Sounder.setY(x);
                            Sounder.setX(y);
                        }
                    }
                    player.CurrentDeep = Convert.ToInt32(gui.DeepValue);
                }
             }
            if (!player.isFishAttack)
            {
                if (player.Road != null)
                {
                    StartBaitTimer?.Invoke(this, EventArgs.Empty);
                    player.RoadY = 470;
                    gui.FLineBarValue = 0;
                    gui.RoadBarValue = 0;
                    player.WindingSpeed = 0;
                }
                if (!(player.Lure is null))
                {
                    StartBaitTimer?.Invoke(this, EventArgs.Empty);
                }
                try
                {
                    if (player.Lure is null && player.Road.Type == ROAD_TYPE.Spinning)
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

        private void View_RepaintScreen(object sender, PaintEventArgs e)
        {
            Player player = Player.getPlayer();
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
            if(player.CFish != null)
                g.DrawImage(Pictures.netting, Netting);

            if (!player.isFishAttack && player.Road != null)
            {
                g.DrawImage(Pictures.road, NormalRoad);
                player.RoadX = player.CurPoint.X;
            }
            if (player.isFishAttack && player.Road != null)
            {
                g.DrawImage(Pictures.roadMaxBend, BrokenRoad);
            }
            if (player.CurPoint.Y > 350 && player.Road != null)
            {
                g.DrawEllipse(new Pen(sbrush), player.CurPoint.X, player.CurPoint.Y, 4, 4);
                g.FillEllipse(sbrush, player.CurPoint.X, player.CurPoint.Y, 4, 4);
            }
            else if (player.CurPoint.Y < 350 && player.CurPoint.Y != 0 && player.Road != null)
            {
                player.CurPoint.Y = 349;
                g.DrawEllipse(new Pen(sbrush), player.CurPoint.X, player.CurPoint.Y, 4, 4);
                g.FillEllipse(sbrush, player.CurPoint.X, player.CurPoint.Y, 4, 4);
            }

        }
        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }
  
    }
}
