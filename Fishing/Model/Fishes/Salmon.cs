using Fishing.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    class Salmon : Fish
    {
        private static HashSet<LureType> lures = new HashSet<LureType>() { LureType.DeepLarge, LureType.FlyingLarge, LureType.Large, LureType.TopLarge, LureType.DeepXL, LureType.FlyingXL, LureType.TopXL, LureType.XL};
        private static int power = 7;
        private static string name = "Сёмга";
        private static int price = 6;
        private static int trophyWeight = 25000;
        private static string description = Messages.SALMON_DESCRIPTION;
        public Salmon() : base(name, randWigth.Next(500, 30000), power, price, trophyWeight, lures, description)
        {

        }
    }
}
