using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Fishing.BL;
using Fishing.BL.Resources.Messages;
using Fishing.BL.Resources.Images;

namespace Fishing
{
    [Serializable]
    public class ArcticChar : Fish
    {
        private readonly static HashSet<Size> lures = new HashSet<Size>()
        {
            Size.Small,
            Size.Large,
        };
        private readonly static int power = 6;
        private readonly static string name = "Арктич. Голец";
        private readonly static int price = 2;
        private readonly static int trophyWeight = 16000;
        private readonly static string description = Messages.ARCTICCHAR_DESCRIPTION;
        private readonly static Bitmap bit = Images.golec;

        public ArcticChar() : base(name, randWigth.Next(200, 20000), power, price, trophyWeight, lures, description, bit)
        {
        }
    }
}
