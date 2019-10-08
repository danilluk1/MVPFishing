using Fishing.BL.Model;
using Fishing.BL.Model.Game;
using Fishing.BL.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.BL.Presenter
{
    public class SounderPresenter
    {
        private readonly ISounder view;
        public LVL CurLVL { get; set; }

        public SounderPresenter(ISounder view, LVL lvl)
        {
            CurLVL = lvl;
            this.view = view;
            view.SounderPaint += SounderPanel_Paint;
        }

        private void SounderPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            try
            {
                int drawX = 0;
                int drawX2;
                for (int i = 0; i < CurLVL.Height - 1; i++)
                {
                    drawX2 = drawX + 12;
                    g.DrawLine(new Pen(Color.White, 2), drawX, (int)CurLVL.Deeparr[Sounder.GetSounder().Row, i].Tag / 10, drawX2,
                                                                                (int)CurLVL.Deeparr[Sounder.GetSounder().Row, i + 1].Tag / 10);
                    drawX = drawX2;
                }
                drawPoint(g);
            }
            catch (NullReferenceException) { }
        }

        private void drawPoint(Graphics g)
        {
            Player player = Player.GetPlayer();
            int x = Convert.ToInt32((Math.Abs(player.CurPoint.Y - CurLVL.Deeparr[0, 0].Location.Y)) / 1.7);
            g.DrawEllipse(new Pen(Color.Black), x, Player.GetPlayer().CurrentDeep / 10 - 2, 4, 4);
        }
    }
}
