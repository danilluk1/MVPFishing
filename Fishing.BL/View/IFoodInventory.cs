using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.View
{
    public interface IFoodInventory
    {
        int SelectedIndex { get; set; }
        Image FoodImage { get; set; }
        string FoodProductivityTextBox { get; set; }
        event EventHandler ListSelectedIndexChanged;
        event EventHandler ListDoubleClick;
        
    }
}
