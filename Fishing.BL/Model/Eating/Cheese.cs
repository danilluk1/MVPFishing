using Fishing.BL.Resources.Images;
using System;

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