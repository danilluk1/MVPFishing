using Fishing.BL.Model.Game;
using Fishing.BL.Model.MapFactory;
using Fishing.Presenter;
using Fishing.View;
using Fishing.View.Menu;
using Fishing.View.Trip;
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
    public partial class Menu : Form, IMenu
    {
        public Menu()
        {
            InitializeComponent();
            presenter = new MenuPresenter(this);
        }
        MenuPresenter presenter;

        public string NickNameL { get => label2.Text; set => label2.Text = value; }
        public string lowerLValue { get => label2.Text; set => label2.Text = value; }

        public event EventHandler SettingsButtonClick;
        public event EventHandler InventoryButtonClick;
        public event EventHandler ShopButtonClick;
        public event EventHandler ExitButtonClick;
        public event EventHandler MapButtonClick;
        public event EventHandler MenuLoad;

        private void SettingButton_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.Show();
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            MFactory f = new MFactory(Game.GetGame().CurrentWater);
            f.CreateMap();
        }

        private void ShopButton_Click(object sender, EventArgs e)
        {
            Shop shop = new Shop();
            shop.Show();
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.Show();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            ExitButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            MenuLoad?.Invoke(this, EventArgs.Empty);
        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TripForm form = new TripForm();
            form.Show();
        }
    }
}
