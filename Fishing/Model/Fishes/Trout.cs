using Fishing.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    [Serializable]
    class Trout : Fish
    {
        private static HashSet<LureType> lures = new HashSet<LureType>() { LureType.TopSmall, LureType.Small, LureType.DeepSmall, LureType.FlyingSmall, LureType.DeepLarge, LureType.FlyingLarge, LureType.Large, LureType.TopLarge };     
        private static int power = 4;
        private static string name = "Форель";
        private static int price = 2;
        private static int trophyWeight = 11000;
        private static string description = Messages.TROUT_DESCRIPTION;
        public Trout() : base(name, randWigth.Next(500, 15000), power, price, trophyWeight, lures, description)
        {
        }
    }
}
