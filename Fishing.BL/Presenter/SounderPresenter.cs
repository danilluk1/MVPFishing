using Fishing.BL.Model.Game;
using Fishing.BL.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing.BL.Presenter {

    public class SounderPresenter {
        private const float SOUNDERWIDTH = 372f;
        private readonly ISounder view;
        public LVL CurLVL { get; set; }

        public SounderPresenter(ISounder view, LVL lvl) {
            CurLVL = lvl;
            this.view = view;
            view.SounderPaint += SounderPanel_Paint;
        }

        private void SounderPanel_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            try {
                float drawX = 0;
                float drawX2;
                for (int i = 0; i < CurLVL.Height - 1; i++) {
                    drawX2 = drawX + (SOUNDERWIDTH / (CurLVL.Height - 1));
                    g.DrawLine(new Pen(Color.White, 2), drawX, Convert.ToInt32(CurLVL.Deeparr[Sounder.GetSounder().Row, i].Text) / 10, drawX2,
                                                                                Convert.ToInt32(CurLVL.Deeparr[Sounder.GetSounder().Row, i + 1].Text) / 10);
                    drawX = drawX2;
                }
                DrawPoint(g);
            }
            catch (NullReferenceException) { }
        }

        private void DrawPoint(Graphics g) {
            Player player = Player.GetPlayer();
            float coef = 0;
            int height = 23 * CurLVL.Height;
            if (height >= SOUNDERWIDTH) {
                coef = SOUNDERWIDTH / height;
            }
            if (height < SOUNDERWIDTH) {
                coef = height / SOUNDERWIDTH;
            }
            float x = Sounder.GetSounder().Column * (SOUNDERWIDTH / CurLVL.Height);
            g.DrawEllipse(new Pen(Color.Black), x, Player.GetPlayer().EquipedRoad.CurrentDeep / 10 - 4, 4, 4);
        }
    }
}