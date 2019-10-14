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
