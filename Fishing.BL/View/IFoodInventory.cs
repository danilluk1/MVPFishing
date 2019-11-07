﻿using Fishing.BL.Model.Eating;
using System;
using System.Drawing;

namespace Fishing.BL.View
{
    public interface IFoodInventory : IView
    {
        string FoodsSelectedItem { get; set; }
        string FoodProductivityTextBox { get; set; }
        void ShowFood(Food food);

        event EventHandler ListSelectedIndexChanged;

        event EventHandler ListDoubleClick;
    }
}