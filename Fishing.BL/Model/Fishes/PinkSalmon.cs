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
    public class PinkSalmon : Fish
    {
        private static HashSet<LureType> lures = new HashSet<LureType>()
        {
          LureType.DeepLarge,
          LureType.FlyingLarge,
          LureType.Large,
          LureType.TopLarge,
          LureType.DeepXL,
          LureType.FlyingXL,
          LureType.TopXL,
          LureType.XL
        };
        private static int power = 7;
        private static string name = "Горбуша";
        private static int price = 3;
        private static int trophyWeight = 18000;
        private static string description = Messages.PINKSALMON_DESCRIPTION;
        public PinkSalmon() : base(name, randWigth.Next(500, 20000), power, price, trophyWeight, lures, description)
        {
        }
    }
}
