using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.BL.View
{
    public interface IStatistic
    {
        event EventHandler LoadForm;
        string NameLText { get; set; }
        string MoneyLText { get; set; }
        string GatheringLText { get; set; }
        string BrokenRoadsLText { get; set; }
        string TornFLineLText { get; set; }
        string TakeFishesLText { get; set; }
        void addEventToView(ListViewItem i);

    }
}
