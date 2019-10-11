using Fishing.BL.Model.LVLS;
using Fishing.BL.Model.LVLS.Ozero;
using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.BL.Model.Waters
{
    public class Ozero : Water
    {
        private static Ozero water;
        public static Ozero GetWater()
        {
            if (water == null)
            {
                water = new Ozero();
            }
            return water;
        }
        private Ozero() : base("Озеро", Images.ozero1f, 0, 0)
        {
            Labels = new List<Label>();
            Labels.Add
            (
                new Label()
                {
                    Image = Images.blackkrug,
                    Top = 500,
                    Left = 800,
                    Width = 28,
                    Height = 29,
                    BackColor = Color.Transparent,
                    
                }               
            );
            Labels.Add
            (
                new Label()
                {
                    Image = Images.blackkrug,
                    Top = 700,
                    Left = 220,
                    Width = 28,
                    Height = 29,
                    BackColor = Color.Transparent,

                }
            );
            Labels.Add //LVL2
            (
                new Label()
                {
                    Image = Images.blackkrug,
                    Top = 450,
                    Left = 350,
                    Width = 28,
                    Height = 29,
                    BackColor = Color.Transparent,
                }
            );
            Labels[0].Click += Ozero_Click1;
            Labels[1].Click += Ozero_Click2;
            Labels[2].Click += Ozero_Click3;
        }

        private void Ozero_Click3(object sender, EventArgs e)
        {
            LVL3 lvl1 = new LVL3();
        }

        private void Ozero_Click2(object sender, EventArgs e)
        {
            LVL2 lvl1 = new LVL2();
        }

        private void Ozero_Click1(object sender, EventArgs e)
        {
            LVL1 lvl1 = new LVL1();
        }

        private void Ozero_Click(object sender, EventArgs e)
        {
        }

    }
}
