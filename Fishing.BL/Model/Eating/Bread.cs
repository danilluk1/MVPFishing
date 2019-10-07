using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Eating
{
    [Serializable]
    public class Bread : BaseFood
    {
        public Bread() : base ("Хлеб", 10, 10, Images.hleb)
        {

        }
    }
}
