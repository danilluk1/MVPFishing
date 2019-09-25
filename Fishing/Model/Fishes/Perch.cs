using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Fishing.Resources;

namespace Fishing
{
    class Perch : Fish
    {
        private static HashSet<LureType> lures = new HashSet<LureType>() { LureType.TopSmall, LureType.Small, LureType.DeepSmall, LureType.FlyingSmall };
        private static int power = 3;
        private static string name = "Окунь";
        private static int price = 1;
        private static string description = Messages.PERCH_DESCRIPTION;
        public Perch() : base(name, randWigth.Next(200, 1700), power, price, 1300, lures, description)
        {

        }
    }
}
