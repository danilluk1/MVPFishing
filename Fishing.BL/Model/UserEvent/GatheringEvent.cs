using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.UserEvent
{
    [Serializable]
    class GatheringEvent : BaseEvent
    {
        private static string text = Player.GetPlayer().NickName + " сход =(";
        public GatheringEvent() : base(text, 5)
        {
        }
    }
}
