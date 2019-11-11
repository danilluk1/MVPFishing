using Fishing.BL.Presenter;
using Fishing.BL.View;
using System;
using System.Windows.Forms;

namespace Fishing {

    public partial class CurrentFish : Form, ICurrentFishF {
        private readonly CurrentFishPresenter presenter;
        private Fish fish;

        public CurrentFish(Fish fish) {
            InitializeComponent();
            presenter = new CurrentFishPresenter(this);
            this.fish = fish;
            SetCurrentFish(fish);
        }

        private void Presenter_CreateNewCurrentFish(object sender, EventArgs e) {
        }

        private void CurrentFish_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Space:
                Player.GetPlayer().AddFish(fish);
                this.Close();
                break;

                case Keys.F:
                if (PriceButton.Text.Length > 0) {
                    Player.GetPlayer().SellFish(fish);
                    UI.gui.MoneyLabel.Text = Player.GetPlayer().Money.ToString();
                    MessageBox.Show("Продано");
                    this.Close();
                }
                break;
            }
        }

        public void SetCurrentFish(Fish fish) {
            FishImage.Image = fish.Bitmap;
            this.NameLabel.Text = fish.Name;
            this.WeightLabel.Text = fish.Weight.ToString();
            this.PriceButton.Text = (fish.Price * fish.Weight).ToString();
            this.Show();
            Player.GetPlayer().EquipedRoad.IsFishAttack = false;
        }
    }
}