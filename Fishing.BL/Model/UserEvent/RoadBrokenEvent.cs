using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.UserEvent
{
    [Serializable]
    class RoadBrokenEvent : BaseEvent
    {
        private static string text = Player.GetPlayer().NickName + " сломал удочку";
        public RoadBrokenEvent() : base(text, 0)
        {
        }
    }
}
