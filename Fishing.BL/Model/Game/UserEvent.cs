using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Game
{
    [Serializable]
    public enum MessageType
    {
        RoadIsBroken,
        FLineIsTorn,
        NewFish,
        NewTrophyFish,
        Gathering,
    }
    [Serializable]
    public class UserEvent
    {
        public string Text { get; set; }
        public MessageType Type { get; set; }

        public UserEvent(string text, MessageType type)
        {
            Text = text;
            Type = type;
        }
        
    }
}
