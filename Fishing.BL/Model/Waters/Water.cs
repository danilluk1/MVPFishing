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
    public abstract class Water
    {
        public Image MapImage { get; set; }
        public int DailyPrice { get; set; }
        public int KmFromNearestStation { get; set; }
        public string Name { get; set; }
        
        public Water(string name, Image mi, int dp, int km)
        {
            MapImage = mi;
            DailyPrice = dp;
            KmFromNearestStation = km;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
