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

        public SounderPresenter(ISounder view)
        {
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
                for (int i = 0; i < 17; i++)
                {
                    drawX2 = drawX + 10;
                    g.DrawLine(new Pen(Color.White, 2), drawX, (int)LVL2.GetLVL().Deeparr[Sounder.GetSounder().Row, i].Tag / 10, drawX2,
                                                                                (int)LVL2.GetLVL().Deeparr[Sounder.GetSounder().Row, i + 1].Tag / 10);
                    drawX = drawX2;
                }
                drawPoint(g);
            }
            catch (NullReferenceException) { }
        }

        private void drawPoint(Graphics g)
        {
            Player player = Player.GetPlayer();
            if (player.Assembly.Lure.DeepType == DeepType.Flying)
            {
                g.DrawEllipse(new Pen(Color.Black), Sounder.GetSounder().Column * 10, Player.GetPlayer().CurrentDeep / 20, 3, 3);
            }
            else if (player.Assembly.Lure.DeepType == DeepType.Top)
            {
                g.DrawEllipse(new Pen(Color.Black), Sounder.GetSounder().Column * 10, 5, 3, 3);
            }
            else if (player.Assembly.Lure.DeepType == DeepType.Deep)
            {
                g.DrawEllipse(new Pen(Color.Black), Sounder.GetSounder().Column * 10, Player.GetPlayer().CurrentDeep / 10 - 5, 3, 3);
            }
        }
    }
}
