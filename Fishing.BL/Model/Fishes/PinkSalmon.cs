using System;
using System.Collections.Generic;
using System.Drawing;
using Fishing.BL.Model.Game;
using Fishing.BL.Resources.Images;
using Fishing.BL.Resources.Messages;

namespace Fishing
{
    [Serializable]
    public class PinkSalmon : Fish
    {
        private readonly static HashSet<Size> lures = new HashSet<Size>()
        {
          Size.XL,
          Size.Large,
        };
        private readonly static HashSet<PartsOfDay> activParts = new HashSet<PartsOfDay>()
        {
            PartsOfDay.Evening,
            PartsOfDay.Morning,
            PartsOfDay.Night
        };
        private readonly static int power = 7;
        private readonly static string name = "Горбуша";
        private readonly static int price = 3;
        private readonly static int trophyWeight = 18000;
        private readonly static string description = Messages.PINKSALMON_DESCRIPTION;
        private readonly static Bitmap bit = Images.gorbusha;
        public PinkSalmon(int minD, int maxD, double maxSizeCoef, HashSet<Lure> lu) : base(name, randWigth.Next(500, 20000), Power.SetPower(7, 4), price, trophyWeight, lures, activParts, description, bit)
        {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;
        }
    }
}
