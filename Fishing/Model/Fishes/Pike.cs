using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Fishing.Resources;

namespace Fishing
{
    class Pike : Fish
    {
        private static HashSet<LureType> lures = new HashSet<LureType>() { LureType.DeepLarge, LureType.FlyingLarge, LureType.Large, LureType.TopLarge, LureType.DeepXL, LureType.FlyingXL, LureType.TopXL, LureType.XL};
        private static int power = 6;
        private static string name = "Щука";
        private static int price = 1;
        private static int trophyWeight = 8000;
        private static string description = Messages.PIKE_DESCRIPTION;
        public Pike() : base(name, randWigth.Next(1, 10000), power, price, trophyWeight, lures, description)
        {
        }
    }
}
