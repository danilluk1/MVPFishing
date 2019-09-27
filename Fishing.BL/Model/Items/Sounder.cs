using Fishing.BL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing
{
    public class Sounder : Item
    {
        private Timer sounderUpdater;
        private Panel sounder;
        private static int Y = 0;
        private static int X = 0;

        public static void setY(int y)
        {
            Y = y;
        }
        public static void setX(int x)
        {
            X = x;
        }
        public Sounder(Panel sounder, Timer timer) : base ("Эхолот", 100000, Images.layer10)
        {
            this.sounder = sounder;
            this.sounderUpdater = timer;
            timer.Tick += SounderUpdater_Tick;
            sounder.Paint += SounderPanel_Paint;
            sounder.BackColor = Color.Gray;
        }

        private void SounderUpdater_Tick(object sender, EventArgs e)
        {
            sounder.Refresh();
        }

        private void SounderPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                int drawX = 0;
                int drawX2;
                for (int i = 0; i < 17; i++)
                {
                    drawX2 = drawX + 10;
                    g.DrawLine(new Pen(Color.White, 2), drawX, (int)LVL.Deeparr[Y, i].Tag / 10, drawX2,
                                                                                (int)LVL.Deeparr[Y, i + 1].Tag / 10);
                    drawX = drawX2;
                }
                drawPoint(g);
            }
            catch (NullReferenceException) { }
        }

        private static void drawPoint(Graphics g)
        {
            Player player = Player.getPlayer();
            try
            {
                if (player.Lure.Type == LureType.FlyingLarge
                                || player.Lure.Type == LureType.FlyingSmall
                                            || player.Lure.Type == LureType.FlyingXL)
                {
                    g.DrawEllipse(new Pen(Color.Black), X * 10, Player.getPlayer().CurrentDeep / 20, 3, 3);
                }
                else if (player.Lure.Type == LureType.TopLarge
                                || player.Lure.Type == LureType.TopSmall
                                            || player.Lure.Type == LureType.TopXL)
                {
                    g.DrawEllipse(new Pen(Color.Black), X * 10, 5, 3, 3);
                }
                else if (player.Lure.Type == LureType.XL
                                || player.Lure.Type == LureType.Small
                                            || player.Lure.Type == LureType.Large)
                {
                    g.DrawEllipse(new Pen(Color.Black), X * 10, Player.getPlayer().CurrentDeep / 10 - 5, 3, 3);
                }
                else if (player.Lure.Type == LureType.DeepXL
                                || player.Lure.Type == LureType.DeepSmall
                                            || player.Lure.Type == LureType.DeepLarge)
                {
                    g.DrawEllipse(new Pen(Color.Black), X * 10, Player.getPlayer().CurrentDeep / 10 - 5, 3, 3);
                }
            }
            catch (NullReferenceException) { }
        }
    }
}
