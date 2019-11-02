using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Game;
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
    class Roach : Fish
    {
        private readonly static HashSet<PartsOfDay> activParts = new HashSet<PartsOfDay>()
        {
            PartsOfDay.Evening,
            PartsOfDay.Morning,
            PartsOfDay.Night,
            PartsOfDay.Day
        };

        private readonly static string name = "Плотва";
        private readonly static int price = 1;
        private readonly static int trophyWeight = 1200;
        private readonly static string description = Messages.ROACH_DESCRIPTION;
        private readonly static Bitmap bit = Images.plotva;

        public Roach(int minD, int maxD, double maxSizeCoef, HashSet<FishBait> lu) : base(name, randWigth.Next(50, Convert.ToInt32(1800 * maxSizeCoef)), Power.SetPower(6, 2), price, trophyWeight, activParts, description, bit)
        {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;
        }
    }
}
