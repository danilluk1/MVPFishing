using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fishing
{
    [Serializable]
    public enum LureType
    {
        DeepXL,
        DeepSmall,
        DeepLarge,
        FlyingXL,
        FlyingSmall,
        FlyingLarge,
        TopXL,
        TopSmall,
        TopLarge,
        XL,
        Small,
        Large

    }
    [Serializable]
    public class Lure : Item
    {
        public int Count { get; set; }
        public LureType Type { get; set; }

        public Lure(string name, LureType type, int count, int price, Bitmap pic) : base(name, price, pic)
        {           
            Type = type;
            Count = count;
        }
        public override string ToString()
        {
            return this.Name;
        }
        public static Wobbler vob1 = new Wobbler("Составник", LureType.FlyingLarge, 1, 3000, Resource1.VOB1);
        public static Wobbler vob2 = new Wobbler("Воблер 2", LureType.FlyingSmall, 1, 3000, Resource1.VOB3);
        public static Wobbler vob3 = new Wobbler("Воблер 3", LureType.FlyingSmall, 1, 3000, Resource1.VOB2);
        public static Wobbler vob4 = new Wobbler("Воблер 4", LureType.FlyingXL, 1, 3000, Resource1.VOB4);
        public static Iron jelezo2 = new Iron("Вертушка 2", LureType.Small, 1, 500, Resource1.CIRCLE1);
        public static Iron jelezo3 = new Iron("Колебалка 1", LureType.XL, 1, 500, Resource1.VIB1);
        public static Iron jelezo4 = new Iron("Колебалка 1", LureType.XL, 1, 500, Resource1.VIB2);
    }
}
