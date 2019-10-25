using System;

namespace Fishing.BL.Model.UserEvent
{
    [Serializable]
    internal class RoadBrokenEvent : BaseEvent
    {
        private static string text = Player.GetPlayer().NickName + " сломал удочку";

        public RoadBrokenEvent() : base(text, 0)
        {
        }
    }
}