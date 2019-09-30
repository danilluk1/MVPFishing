
using Fishing.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    [Serializable]
    public class Grayling : Fish
    {
        private static HashSet<LureType> lures = new HashSet<LureType>()
        {
          LureType.TopSmall,
          LureType.Small,
          LureType.DeepSmall,
          LureType.FlyingSmall
        };
        private static int power = 4;
        private static string name = "Хариус";
        private static int price = 5;
        private static int trophyWeight = 1600;
        private static string description = Messages.GRAYLING_DESCRIPTION;
        public Grayling() : base(name, randWigth.Next(500, 2000), power, price, trophyWeight, lures, description)
        {
        }
    }
}
