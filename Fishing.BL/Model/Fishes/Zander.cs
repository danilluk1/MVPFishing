﻿using Fishing.BL.Model.Game;
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
        private readonly static HashSet<PartsOfDay> activParts = new HashSet<PartsOfDay>()
        {
            PartsOfDay.Evening,
            PartsOfDay.Morning,
            PartsOfDay.Night,
        };
        private readonly static int power = 6;
        private readonly static string name = "Судак";
        private readonly static int price = 5;
        private readonly static int trophyWeight = 8000;
        private readonly static string description = Messages.ZANDER_DESCRIPTION;
        private readonly static Bitmap bit = Images.sudak;
        public Zander(int minD, int maxD, double maxSizeCoef, HashSet<Lure> lu)
            : base(name, randWigth.Next(100, Convert.ToInt32(10000 * maxSizeCoef)), power, price, trophyWeight, lures, activParts, description, bit)
        {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;
        }
    }
}
