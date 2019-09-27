using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Fishing.BL;

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
        public static Wobbler vob1 = new Wobbler("Составник", LureType.FlyingLarge, 1, 3000, Images.Vob_3001);
        public static Wobbler vob2 = new Wobbler("Воблер 2", LureType.FlyingSmall, 1, 3000, Images.Vob_3002);
        public static Wobbler vob3 = new Wobbler("Воблер 3", LureType.FlyingSmall, 1, 3000, Images.Vob_3003);
        public static Wobbler vob4 = new Wobbler("Воблер 4", LureType.FlyingXL, 1, 3000, Images.Vob_3015);
        public static Iron jelezo2 = new Iron("Вертушка 2", LureType.Small, 1, 500, Images.Circl_5103);
        public static Iron jelezo3 = new Iron("Колебалка 1", LureType.XL, 1, 500, Images.Vib_6000);
        public static Iron jelezo4 = new Iron("Колебалка 1", LureType.XL, 1, 500, Images.Vib_6012);
    }
}
