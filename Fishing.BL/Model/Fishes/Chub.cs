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
    public class Chub : Fish
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
        private readonly static int power = 3;
        private readonly static string name = "Голавль";
        private readonly static int price = 4;
        private readonly static int trophyWeight = 3000;
        private readonly static string description = Messages.CHUB_DESCRIPTION;
        private readonly static Bitmap bit = Images.golavl;

        public Chub(int minD, int maxD, double maxSizeCoef, HashSet<Lure> lu) : base(name, randWigth.Next(200, Convert.ToInt32(4000 * maxSizeCoef)), power, price, trophyWeight, lures, activParts, description, bit)
        {
            MinDeep = minD;
            MaxDeep = maxD;
            MaxSizeCoef = maxSizeCoef;
            WorkingLures = lu;
        }
    }
}
