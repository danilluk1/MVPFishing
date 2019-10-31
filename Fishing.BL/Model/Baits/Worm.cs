using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Baits
{
    [Serializable]
    public sealed class Worm : Bait
    {
        public Worm() : base("Червь", 30, 10, Images.worm)
        {
        }
    }
}
