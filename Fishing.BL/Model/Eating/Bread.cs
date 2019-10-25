using Fishing.BL.Resources.Images;
using System;

namespace Fishing.BL.Model.Eating
{
    [Serializable]
    public class Bread : BaseFood
    {
        public Bread() : base("Хлеб", 10, 10, Images.hleb)
        {
        }
    }
}