using Fishing.BL.Model.Items;
using Fishing.BL.Resources.Images;
using System;
using System.Drawing;

namespace Fishing
{
    [Serializable]
    public enum ROAD_TYPE
    {
        Spinning,
        Feeder,
        Float,
    }

    [Serializable]
    public abstract class Road : Item
    {
        public static Road Titanium = new Spinning("Titanium", ROAD_TYPE.Spinning, 40000, 300000, Images.Titanium);
        public static Road Achilles = new Spinning("Achilles", ROAD_TYPE.Spinning, 5000, 3000, Images.Achilles_233);
        public static Road YSuperCarp = new Feeder("Yellow super Carp", ROAD_TYPE.Feeder, 100000, 600000, Images.Yellow_SuperCarp);
        public static Road SuperFisher = new Spinning("Hearty Rose Jigging", ROAD_TYPE.Spinning, 95000, 700000, Images.SuperFisher_950);
        public static Road Vesta276 = new Feeder("Vesta 276", ROAD_TYPE.Feeder, 7000, 15000, Images.Vesta_276);
        public int Power { get; set; }
        public ROAD_TYPE Type { get; set; }

        public Road(string name, ROAD_TYPE type, int power, int price, Bitmap pic) : base(name, price, pic)
        {
            Power = power;
            Type = type;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}