using System;
using System.Drawing;

namespace Fishing.BL.Model.Waters
{
    [Serializable]
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