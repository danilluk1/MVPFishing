using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.View.GUI
{
    public interface IGUI
    {
        event EventHandler MapButtonClick;
        event EventHandler InventoryButtonClick;
        event EventHandler MenuButtonClick;
        event EventHandler SettingsButtonClick;
        event EventHandler FPondClick;
        event EventHandler BaitPicClick;
        event EventHandler EventBarClick;
    }
}
