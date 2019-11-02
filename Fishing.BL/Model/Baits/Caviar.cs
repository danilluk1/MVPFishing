using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Baits
{
    [Serializable]
    public class Caviar : Bait
    {
        public Caviar() : base("Икра", 30, 5000, Images.ikra)
        {
        }
    }
}
