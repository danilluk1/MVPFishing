using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Hooks
{
    [Serializable]
    public class FeederHook : BaseHook
    {
        public FeederHook(string name, int gathch, int price, Bitmap bit) : base(name, gathch, price, bit)
        {
        }
        public static FeederHook feeder1 = new FeederHook("Фидер 1", 20, 800, HooksImg.Fider);
        public static FeederHook feeder2 = new FeederHook("Фидер 2", 10, 1800, HooksImg.Fider_2);
        public static FeederHook feeder3 = new FeederHook("Фидер 3", 5, 2800, HooksImg.Fider_3);
    }
}
