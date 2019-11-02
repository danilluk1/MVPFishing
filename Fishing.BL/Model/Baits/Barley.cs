using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Baits
{
    [Serializable]
    public class Barley : Bait
    {
        public Barley() : base("Перловка", 30, 50, Images.perlovka)
        {
        }
    }
}
