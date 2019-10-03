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
    public class SnakeHead : Fish
    {
        private readonly static HashSet<Size> lures = new HashSet<Size>()
        {
            Size.XL,
            Size.Large,
        };
        private readonly static int power = 8;
        private readonly static string name = "Змееголов";
        private readonly static int price = 5;
        private readonly static int trophyWeight = 6000;
        private readonly static string description = Messages.SNAKEHEAD_DESCRIPTION;
        private readonly static Bitmap bit = Images.zmeegolov;
        public SnakeHead() : base(name, randWigth.Next(1, 10000), power, price, trophyWeight, lures, description, bit)
        {
        }
    }
}
