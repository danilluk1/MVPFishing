using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Eating
{
    [Serializable]
    public class Cheese : BaseFood
    {
        public Cheese() : base("Сыр", 1000, 50, Images.sir)
        {

        }
    }
}
