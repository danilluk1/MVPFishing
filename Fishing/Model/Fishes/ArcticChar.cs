using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Fishing.Resources;

namespace Fishing
{
    [Serializable]
    class ArcticChar : Fish
    {
        private static HashSet<LureType> lures = new HashSet<LureType>() {  LureType.TopSmall,
                                                                            LureType.Small,
                                                                            LureType.DeepSmall,
                                                                            LureType.FlyingSmall,
                                                                            LureType.DeepLarge,
                                                                            LureType.FlyingLarge,
                                                                            LureType.Large,
                                                                            LureType.TopLarge };
        private static int power = 6;
        private static string name = "Арктич. Голец";
        private static int price = 2;
        private static int trophyWeight = 16000;
        private static string description = Messages.ARCTICCHAR_DESCRIPTION;

        public ArcticChar() : base(name, randWigth.Next(200, 20000), power, price, trophyWeight, lures, description)
        {
        }
    }
}
