using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Eating
{
    [Serializable]
    public class BlackCaviar : BaseFood
    {
        public BlackCaviar() : base("Икра Чёрная", 10000, 80, Images.black)
        {

        }
    }
}
