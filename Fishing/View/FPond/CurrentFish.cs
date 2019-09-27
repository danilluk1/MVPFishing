using Fishing.BL;
using Fishing.BL.Presenter;
using Fishing.BL.View;
using Fishing.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing
{
    public partial class CurrentFish : Form, ICurrentFishF
    {
        CurrentFishPresenter presenter;
        public CurrentFish()
        {
            InitializeComponent();
            presenter = new CurrentFishPresenter(this);
            presenter.CreateNewCurrentFish += Presenter_CreateNewCurrentFish;
            setCurrentFish(Player.getPlayer().CFish);
        }

        private void Presenter_CreateNewCurrentFish(object sender, EventArgs e)
        {
        }

        private void CurrentFish_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    Player.getPlayer().addFish(Player.getPlayer().CFish);
                    this.Close();
                    break;

                case Keys.F:
                    if (PriceButton.Text.Length > 0)
                    {
                        Player.getPlayer().SellFish(Player.getPlayer().CFish);
                        GUI.gui.MoneyLabel.Text = Player.getPlayer().Money.ToString();
                        MessageBox.Show("Продано");
                        this.Close();
                    }
                    break;
            }           
        }

        private void PriceButton_Click(object sender, EventArgs e)
        {

        }

        private void CurrentFish_Load(object sender, EventArgs e)
        {

        }
        public void setCurrentFish(Fish fish)
        {
            Player player = Player.getPlayer();

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
            Player.getPlayer().isFishAttack = false;
        }
    }
}
