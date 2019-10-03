using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.UserEvent
{
    [Serializable]
    class FLineTornEvent : BaseEvent
    {
        private static string text = Player.GetPlayer().NickName + " порвал леску";
        public FLineTornEvent() : base(text, 0)
        {
        }
    }
}
