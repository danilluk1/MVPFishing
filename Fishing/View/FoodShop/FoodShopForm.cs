using Fishing.BL.Model.Eating;
using Fishing.Resources;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing.View.FishShop {
    public partial class FoodShopForm : Form {
        public FoodShopForm() {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, EventArgs e) {
            var food = (sender as PictureBox);
            food.Image = (Image)FoodButtons.ResourceManager.GetObject(food.Name.ToLower() + "_a");
            var f = Food.GetFoodByName((sender as PictureBox).Tag.ToString());
            foodDescriptionLabel.Text = f.Name + " Цена: " + f.Price + " Восполняет: " + f.Productivity + "%";
        }

        private void Button_MouseLeave(object sender, EventArgs e) {
            var food = (sender as PictureBox);
            food.Image = (Image)FoodButtons.ResourceManager.GetObject(food.Name.ToLower() + "_d");
        }

        private void Button_Click(object sender, EventArgs e) {
            var food = Food.GetFoodByName((sender as PictureBox).Tag.ToString());
            Player.GetPlayer().FoodInv.Add(food);
        }

        private void closeBox_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}