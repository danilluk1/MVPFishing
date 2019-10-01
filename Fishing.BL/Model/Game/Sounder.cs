using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.BL.Model.Game
{
    public sealed class Sounder
    {
        private static Sounder sounder;
        public int Column { get; set; }
        public int Row { get; set; }

        //public Label[,] Deeparr;

        private Sounder()
        {
            //Deeparr = deeparr;
        }
        public static Sounder getSounder()
        {
            if (sounder == null)
            {
                sounder = new Sounder();
            }

            return sounder;
        }

        private void SounderPanel_Paint(object sender, PaintEventArgs e)
        {
        //    try
        //    {
        //        Graphics g = e.Graphics;
        //        int drawX = 0;
        //        int drawX2;
        //        for (int i = 0; i < 17; i++)
        //        {
        //            drawX2 = drawX + 10;
        //            g.DrawLine(new Pen(Color.White, 2), drawX, (int)Deeparr[Row, i].Tag / 10, drawX2,
        //                                                                        (int)Deeparr[Row, i + 1].Tag / 10);
        //            drawX = drawX2;
        //        }
        //        drawPoint(g);
        //    }
        //    catch (NullReferenceException) { }
        }

        private void drawPoint(Graphics g)
        {
            Player player = Player.getPlayer();
            try
            {
                if (player.Assembly.Lure.Type == LureType.FlyingLarge
                                || player.Assembly.Lure.Type == LureType.FlyingSmall
                                            || player.Assembly.Lure.Type == LureType.FlyingXL)
                {
                    g.DrawEllipse(new Pen(Color.Black), Column * 10, Player.getPlayer().CurrentDeep / 20, 3, 3);
                }
                else if (player.Assembly.Lure.Type == LureType.TopLarge
                                || player.Assembly.Lure.Type == LureType.TopSmall
                                            || player.Assembly.Lure.Type == LureType.TopXL)
                {
                    g.DrawEllipse(new Pen(Color.Black), Column * 10, 5, 3, 3);
                }
                else if (player.Assembly.Lure.Type == LureType.XL
                                || player.Assembly.Lure.Type == LureType.Small
                                            || player.Assembly.Lure.Type == LureType.Large)
                {
                    g.DrawEllipse(new Pen(Color.Black), Column * 10, Player.getPlayer().CurrentDeep / 10 - 5, 3, 3);
                }
                else if (player.Assembly.Lure.Type == LureType.DeepXL
                                || player.Assembly.Lure.Type == LureType.DeepSmall
                                            || player.Assembly.Lure.Type == LureType.DeepLarge)
                {
                    g.DrawEllipse(new Pen(Color.Black), Column * 10, Player.getPlayer().CurrentDeep / 10 - 5, 3, 3);
                }
            }
            catch (NullReferenceException) { }
        }
    }
}
