using Fishing.BL;
using Fishing.BL.Presenter;
using Fishing.BL.Resources.Images;
using Fishing.BL.View;
using System;
using System.Windows.Forms;

namespace Fishing
{
    public partial class CurrentFish : Form, ICurrentFishF
    {
        readonly CurrentFishPresenter presenter;
        public CurrentFish()
        {
            InitializeComponent();
            presenter = new CurrentFishPresenter(this);
            SetCurrentFish(Player.GetPlayer().CFish);
        }

        private void Presenter_CreateNewCurrentFish(object sender, EventArgs e)
        {
        }

        private void CurrentFish_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    Player.GetPlayer().AddFish(Player.GetPlayer().CFish);
                    this.Close();
                    break;

                case Keys.F:
                    if (PriceButton.Text.Length > 0)
                    {
                        Player.GetPlayer().SellFish(Player.GetPlayer().CFish);
                        GUI.gui.MoneyLabel.Text = Player.GetPlayer().Money.ToString();
                        MessageBox.Show("Продано");
                        this.Close();
                    }
                    break;
            }           
        }

        public void SetCurrentFish(Fish fish)
        {
            if (fish is Pike)
            {
                this.FishImage.Image = Images.pike;
            }
            if (fish is Perch)
            {
                this.FishImage.Image = Images._1040;
            }
            if (fish is PinkSalmon)
            {
                this.FishImage.Image = Images.gorbusha;
            }
            if (fish is ArcticChar)
            {
                this.FishImage.Image = Images.golec;
            }
            if (fish is Grayling)
            {
                this.FishImage.Image = Images._1081;
            }
            if (fish is Salmon)
            {
                this.FishImage.Image = Images._1039;
            }
            if (fish is Trout)
            {
                this.FishImage.Image = Images._1052;
            }
            this.NameLabel.Text = fish.Name;
            this.WeightLabel.Text = fish.Weight.ToString();
            this.PriceButton.Text = (fish.Price * fish.Weight).ToString();
            this.Show();
            Player.GetPlayer().isFishAttack = false;
        }
    }
}
