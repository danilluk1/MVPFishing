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

        void AddEventToBox(string s);
        void ClearEvents();
        void IncrementRoadBarValue(int value);
        void IncrementFLineBarValue(int value);
        void CheckNeedsAndClearEventBox();
        void AddLabels(Label[,] l);


    }
}
