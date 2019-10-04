using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Fishing.BL;
using Fishing.BL.Resources.Images;
using Fishing.BL.Model.Lures;

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
        public DeepType DeepType{get; set; }

        public Lure(string name, Size size, DeepType dt, int price, Bitmap pic) : base(name, price, pic)
        {           
            Size = size;
            DeepType = dt;
        }
        public override string ToString()
        {
            return this.Name;
        }
        public static Wobbler vob1 = new Wobbler("Составник", Size.Large, DeepType.Flying, 3000, Images.Vob_3001);
        public static Wobbler vob2 = new Wobbler("Воблер 2", Size.XL, DeepType.Flying, 3000, Images.Vob_3002);
        public static Wobbler vob3 = new Wobbler("Воблер 3", Size.Small, DeepType.Top, 3000, Images.Vob_3003);
        public static Wobbler vob4 = new Wobbler("Воблер 4", Size.Large, DeepType.Deep, 3000, Images.Vob_3015);

        public static Pinwheel vert1 = new Pinwheel("Вертушка 1", Size.Small, DeepType.Deep, 500, Images.Circl_5103);

        public static Shaker jelezo1 = new Shaker("Колебалка 1", Size.XL, DeepType.Deep, 500, Images.Vib_6000);
        public static Shaker jelezo2 = new Shaker("Колебалка 2", Size.Large, DeepType.Deep, 500, Images.Vib_6012);

        public static Jig jig1 = new Jig("Виброхвост 1", Size.Small, DeepType.Jig, 500, Images.Tvis_103);
    }
}
