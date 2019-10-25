using System;
using System.Drawing;

namespace Fishing.BL.View
{
    public interface IFoodInventory : IView
    {
        int SelectedIndex { get; set; }
        Image FoodImage { get; set; }
        string FoodProductivityTextBox { get; set; }

        event EventHandler ListSelectedIndexChanged;

        event EventHandler ListDoubleClick;
    }
}