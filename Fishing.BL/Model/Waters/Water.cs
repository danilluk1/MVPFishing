using System;
using System.Collections.Generic;
using System.Drawing;
using WindowsFormsApp1;

namespace Fishing.BL.Model.Waters
{
    [Serializable]
    public abstract class Water
    {
        public Image MapImage { get; set; }
        public List<PicturesBoxInfo> Locs { get; set; }
        public int DailyPrice { get; set; }
        public int KmFromNearestStation { get; set; }
        public string Name { get; set; }

        public int MinLVL { get; set; }

        public Water(string name, Image mi, int dp, int km, List<PicturesBoxInfo> list)
        {
            MapImage = mi;
            DailyPrice = dp;
            KmFromNearestStation = km;
            Name = name;
            Locs = list;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}