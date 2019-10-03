using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.UserEvent
{
    [Serializable]
    class FishEvent : BaseEvent
    {
        public FishEvent(Fish f, int i) : base(Player.GetPlayer().NickName + " поймал " + f.ToString(), i)
        {
        }
    }
}
