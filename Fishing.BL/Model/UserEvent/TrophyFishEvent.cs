using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Fishing.BL.Model.UserEvent
{
    [Serializable]
    public sealed class TrophyFishEvent : BaseEvent
    {
        public TrophyFishEvent(Fish f, int i) : base("Трофей! " + Player.GetPlayer().NickName + " поймал " + f.ToString(), i)
        {
        }
    }
}
