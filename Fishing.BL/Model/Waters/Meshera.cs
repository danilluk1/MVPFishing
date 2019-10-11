using Fishing.BL.Model.LVLS;
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
    public class Meshera : Water
    {
        private static Meshera water;

        private Meshera() : base("Мещёра", Images.MesheraMap, 1200, 1600)
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
                    Tag = "LVL2"
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
                    Tag = "LVL2"
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
                    Tag = "LVL2"
                }
            );
        }

        public static Meshera GetWater()
        {
            if (water == null)
            {
                water = new Meshera();
            }
            return water;
        }
    }
}
