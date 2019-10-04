using Fishing.BL.Resources.Images;
using Fishing.BL.Resources.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Fishes
{
    [Serializable]
    class Zander : Fish
    {
        private readonly static HashSet<Size> lures = new HashSet<Size>()
        {
            Size.Small,
            Size.Large,
        };
        private readonly static int power = 6;
        private readonly static string name = "Судак";
        private readonly static int price = 5;
        private readonly static int trophyWeight = 8000;
        private readonly static string description = Messages.ZANDER_DESCRIPTION;
        private readonly static Bitmap bit = Images.sudak;
        public Zander() : base(name, randWigth.Next(1, 10000), power, price, trophyWeight, lures, description, bit)
        {
        }
    }
}
