using Fishing.BL.Model.Lures;
using Fishing.BL.Resources.Images;
using System;
using System.Drawing;

namespace Fishing
{
    [Serializable]
    public enum Size
    {
        XL,
        Small,
        Large,
    }

    [Serializable]
    public enum DeepType
    {
        Deep,
        Flying,
        Top,
        Jig,
    }

    [Serializable]
    public class Lure : Item
    {
        public Size Size { get; set; }
        public DeepType DeepType { get; set; }

        public Lure(string name, Size size, DeepType dt, int price, Bitmap pic) : base(name, price, pic)
        {
            Size = size;
            DeepType = dt;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public static Wobbler vob1 = new Wobbler("Составник", Size.Large, DeepType.Flying, 3000, Images.Vob_3015);
        public static Wobbler vob2 = new Wobbler("Воблер 2", Size.XL, DeepType.Flying, 3000, Images.Vob_3002);
        public static Wobbler vob3 = new Wobbler("Воблер 3", Size.Small, DeepType.Top, 3000, Images.Vob_3003);
        public static Wobbler vob4 = new Wobbler("Воблер 4", Size.Large, DeepType.Deep, 3000, Images.Vob_3001);
        public static Wobbler vob5 = new Wobbler("Воблер 1 Дип", Size.Large, DeepType.Deep, 3000, Images.Deep_112);
        public static Wobbler vob6 = new Wobbler("Воблер 2 Дип", Size.Large, DeepType.Deep, 3000, Images.Deep_115);

        public static Pinwheel vert1 = new Pinwheel("Вертушка 1", Size.Small, DeepType.Deep, 500, Images.Circl_5103);
        public static Pinwheel vert2 = new Pinwheel("Вертушка 2", Size.Small, DeepType.Deep, 500, Images.Circl_5113);

        public static Shaker jelezo1 = new Shaker("Колебалка 1", Size.XL, DeepType.Deep, 500, Images.Vib_6000);
        public static Shaker jelezo2 = new Shaker("Колебалка 2", Size.Large, DeepType.Deep, 500, Images.Vib_6012);

        public static Jig jig1 = new Jig("Виброхвост 1", Size.Small, DeepType.Jig, 500, Images.Tvis_103);
        public static Jig jig2 = new Jig("Виброхвост 2", Size.Small, DeepType.Jig, 500, Images.Tvis_105);
        public static Jig jig3 = new Jig("Виброхвост 3", Size.Large, DeepType.Jig, 500, Images.Tvis_104);
        public static Jig jig4 = new Jig("Виброхвост 4", Size.XL, DeepType.Jig, 500, Images.Tvis_119);
    }
}