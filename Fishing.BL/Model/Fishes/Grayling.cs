
using Fishing.BL;
using Fishing.BL.Resources.Images;
using Fishing.BL.Resources.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    [Serializable]
    public class Grayling : Fish
    {
        private readonly static HashSet<Size> lures = new HashSet<Size>()
        {
          Size.Small,
          Size.Large,
        };
        private readonly static int power = 4;
        private readonly static string name = "Хариус";
        private readonly static int price = 5;
        private readonly static int trophyWeight = 1600;
        private readonly static string description = Messages.GRAYLING_DESCRIPTION;
        private readonly static Bitmap bit = Images.xariys;
        public Grayling() : base(name, randWigth.Next(500, 2000), power, price, trophyWeight, lures, description, bit)
        {
        }
    }
}
