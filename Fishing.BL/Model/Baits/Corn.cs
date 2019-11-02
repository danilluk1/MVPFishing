using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Baits
{
    [Serializable]
    public class Corn : Bait
    {
        public Corn() : base("Кукуруза", 30, 150, Images.corn)
        {
        }
    }
}
