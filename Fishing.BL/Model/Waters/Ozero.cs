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
        }
    }
}
