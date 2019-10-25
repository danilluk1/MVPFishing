using Fishing.BL.Resources.Images;
using System;

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