using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Baits
{
    [Serializable]
    public class Cheese : Bait
    {
        public Cheese() : base("Сыр", 30, 300, Images.cheeze)
        {
        }
    }
}
