using Fishing.BL.Resources.Images;
using System;

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