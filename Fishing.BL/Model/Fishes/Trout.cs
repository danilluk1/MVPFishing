﻿using Fishing.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fishing.BL.Resources.Messages;
using System.Drawing;
using Fishing.BL.Resources.Images;
using Fishing.BL.Model.Game;

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
        private readonly static HashSet<PartsOfDay> activParts = new HashSet<PartsOfDay>()
        {
            PartsOfDay.Evening,
            PartsOfDay.Morning,
            PartsOfDay.Night
        };
        private readonly static int power = 4;
        private readonly static string name = "Форель";
        private readonly static int price = 2;
        private readonly static int trophyWeight = 11000;
        private readonly static string description = Messages.TROUT_DESCRIPTION;
        private readonly static Bitmap bit = Images.forel;
        public Trout(int minD, int maxD, double maxSizeCoef, HashSet<Lure> lu) : base(name, randWigth.Next(500, 15000), power, price, trophyWeight, lures, activParts, description, bit)
        {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;

        }
    }
}
