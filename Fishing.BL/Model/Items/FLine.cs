using Fishing.BL.Resources.Images;
using System;
using System.Drawing;

namespace Fishing
{
    [Serializable]
    public class FLine : Item
    {
        public int Power;

        public FLine(string name, int power, int price, Bitmap pic) : base(name, price, pic)
        {
            Power = power;
        }

        public static FLine Indiana1500 = new FLine("Indiana 4000", 4000, 500, Images.indiana);
        public static FLine Quest_Fishers = new FLine("Quest_fishers 90000", 90000, 200000, Images.Quest_Fishers);
        public static FLine Colorado = new FLine("Colorado 30000", 30000, 100000, Images.Colorado);
        public static FLine Atlantic = new FLine("Atlantic", 1000000, 1000000, Images.Atlantic);

        public override string ToString()
        {
            return this.Name;
        }
    }
}