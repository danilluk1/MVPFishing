using System;
using System.Collections.Generic;
using System.Drawing;
using Fishing.BL.Resources.Images;
using Fishing.BL.Resources.Messages;

namespace Fishing
{
    [Serializable]
    public class Pike : Fish
    {
        private readonly static HashSet<Size> lures = new HashSet<Size>()
        {
            Size.XL,
            Size.Large,
        };
        private readonly static int power = 6;
        private readonly static string name = "Щука";
        private readonly static int price = 1;
        private readonly static int trophyWeight = 8000;
        private readonly static string description = Messages.PIKE_DESCRIPTION;
        private readonly static Bitmap bit = Images.pike;
        public Pike() : base(name, randWigth.Next(1, 10000), power, price, trophyWeight, lures, description, bit)
        {
        }
    }
}
