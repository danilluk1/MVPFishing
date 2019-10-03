using Fishing.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fishing.BL.Resources.Messages;
using System.Drawing;
using Fishing.BL.Resources.Images;

namespace Fishing
{
    [Serializable]
    public class Trout : Fish
    {
        private readonly static HashSet<Size> lures = new HashSet<Size>()
        {
          Size.Small,
          Size.Large,
        };
        private readonly static int power = 4;
        private readonly static string name = "Форель";
        private readonly static int price = 2;
        private readonly static int trophyWeight = 11000;
        private readonly static string description = Messages.TROUT_DESCRIPTION;
        private readonly static Bitmap bit = Images.forel;
        public Trout() : base(name, randWigth.Next(500, 15000), power, price, trophyWeight, lures, description, bit)
        {
        }
    }
}
