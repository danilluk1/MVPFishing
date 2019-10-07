using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Eating
{
    [Serializable]
    public class Caviar : BaseFood
    {
        public Caviar() : base("Икра", 1000, 50, Images.red)
        {

        }
    }
}
