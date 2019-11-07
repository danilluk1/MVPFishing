using Fishing.BL.Model.Eating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.UserEvent
{
    [Serializable]
    class FoodEvent : BaseEvent
    {
        public FoodEvent(Food food) : base(Player.GetPlayer().NickName + " Съел " + food.Name, 8)
        {
        }
    }
}
