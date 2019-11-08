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
        public int Power { get; set; }
        public int Wear { get; set; }
        public Road(string name, int wear, int power, int price, Bitmap pic) : base(name, price, pic)
        {
            Power = power;
            Wear = wear;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}