using Fishing.BL.Resources.Images;
using System;
using System.Drawing;

namespace Fishing
{
    [Serializable]
    public class Reel : Item
    {
        public int Power;

        public Reel(string name, int power, int price, Bitmap pic) : base(name, price, pic)
        {
            Power = power;
        }

        public static Reel Hydra = new Reel("Hydra", 3, 100000, Images.Hydra);
        public static Reel SYBERIA_LT_2 = new Reel("SYBERIA_LT_2", 6, 200000, Images.Syberia_LT_2);
        public static Reel Quest_Reel = new Reel("Quest_Reel", 6, 400000, Images.Quest_Reel);
        public static Reel SYBERIA_4 = new Reel("SYBERIA 4", 8, 600000, Images.Syberia_HD_4);
        public static Reel Zymix = new Reel("Zymix", 9, 400000, Images.Zymix);
        public static Reel Syberia_1 = new Reel("Syberia 1", 4, 300000, Images.Syberia_HD_1);
        public static Reel TBR_4000 = new Reel("TBR 4000", 5, 450000, Images.TBR_4000);

        public override string ToString()
        {
            return Name;
        }
    }
}