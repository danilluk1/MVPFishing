using Fishing.BL.Model.UserEvent;
using Fishing.View.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.EventHelper
{
    public class EventHelper
    {
        Player player = Player.GetPlayer();
        IGUIPresenter Gui;
        public EventHelper(IGUIPresenter gui)
        {
            Gui = gui;
        }

        public void AddEventToPlayer(BaseEvent ev)
        {
            if(ev != null)
            {
                player.EventHistory.Push(ev);
            }
        }

        public void ShowLastEvent()
        {
            Gui.AddEventToBox(player.EventHistory.Peek());
        }
    }
}
