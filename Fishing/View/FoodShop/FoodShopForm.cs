using Fishing.BL.Model.Eating;
using Fishing.Resources;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Fishing.BL.Resources.Sounds;

namespace Fishing.View.FoodShop {
    public partial class FoodShopForm : Form {
        private readonly SoundPlayer _sp = new SoundPlayer(SoundsRes.kassa);
        public FoodShopForm() {
            InitializeComponent();
            moneyLabel.Text = "Деньги: " + Player.GetPlayer().Money;
        }

        private void Button_MouseEnter(object sender, EventArgs e) {
            if (sender is PictureBox food) food.Image = (Image) FoodButtons.ResourceManager.GetObject(food.Name.ToLower() + "_a");
            var f = Food.GetFoodByName((sender as PictureBox)?.Tag.ToString());
            foodDescriptionLabel.Text = f.Name + @" Цена: " + f.Price + @" Восполняет: " + f.Productivity + @"%";
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is PictureBox food) 
                food.Image = (Image) FoodButtons.ResourceManager.GetObject(food.Name.ToLower() + "_d");
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var food = Food.GetFoodByName((sender as PictureBox)?.Tag.ToString());
            if (Player.GetPlayer().Money < food.Price) return;
            Player.GetPlayer().Money -= food.Price;
            moneyLabel.Text = "Деньги: " + Player.GetPlayer().Money;
            Player.GetPlayer().FoodInv.Add(food);
            _sp.Play();
        }

        private void CloseBox_Click(object sender, EventArgs e) {
            Close();
        }
    }
}