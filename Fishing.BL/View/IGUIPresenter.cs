using Fishing.BL.Model.UserEvent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.View.GUI
{
    public interface IGUIPresenter
    {
        int SpeedValue { get; set; }
        Bitmap BaitPicture { get; set; }
        int DeepValue { get; set; }
        int RoadBarValue { get; set; }
        int FLineBarValue { get; set; }
        int MoneyLValue { get; set; }
        int EventBoxItemsCount { get; set; }
        int LureDeepValue { get; set; }
        string WiringType { get; set; }
        int EatingBarValue { get; set; }
        

        void AddEventToBox(BaseEvent ev);
        void ClearEvents();
        void IncrementRoadBarValue(int value);
        void IncrementFLineBarValue(int value);
        void CheckNeedsAndClearEventBox();
    }
}
