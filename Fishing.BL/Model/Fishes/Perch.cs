using System;
using System.Collections.Generic;
using System.Drawing;
using Fishing.BL.Resources.Images;
using Fishing.BL.Resources.Messages;

namespace Fishing
{
    [Serializable]
    public class Perch : Fish
    {
        private readonly static HashSet<Size> lures = new HashSet<Size>()
        {
          Size.Small,
          Size.Large,
        };
        private readonly static int power = 3;
        private readonly static string name = "Окунь";
        private readonly static int price = 1;
        private readonly static string description = Messages.PERCH_DESCRIPTION;
        private readonly static Bitmap bit = Images.okyn;
        public Perch() : base(name, randWigth.Next(200, 1700), power, price, 1300, lures, description, bit)
        {

        }
    }
}
