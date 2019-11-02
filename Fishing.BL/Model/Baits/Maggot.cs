using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Baits
{
    [Serializable]
    public class Maggot : Bait
    {
        public Maggot() : base("Опарыш", 30, 50, Images.oparysh)
        {
        }
    }
}
