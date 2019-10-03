using System;
using System.Drawing;
using Fishing.BL.Resources.Images;

namespace Fishing
{
    [Serializable]
    public enum ROAD_TYPE
    {
        Spinning,
        Feeder,
        Float,
        Jigging,
    }
    [Serializable]
    public class Road : Item
    {
        public static Road Titanium = new Road("Titanium", ROAD_TYPE.Spinning, 40000, 300000, Images.Titanium);
        public static Road Achilles = new Road("Achilles", ROAD_TYPE.Spinning, 20000, 3000, Images.Achilles_233);
        public static Road YSuperCarp = new Road("Yellow super Carp", ROAD_TYPE.Feeder, 100000, 600000, Images.Yellow_SuperCarp);
        public static Road SuperFisher = new Road("Hearty Rose Jigging", ROAD_TYPE.Jigging, 95000, 700000, Images.SuperFisher_950);
        public int Power { get; set; }
        public ROAD_TYPE Type { get; set; }
        public Road(string name, ROAD_TYPE type, int power, int price, Bitmap pic) : base(name, price, pic)
        {
            Power = power;
            Type = type;
        }
        
        public override string ToString() {
            return this.Name;
        }
    }
}
