using Fishing.BL.Model.Game;
using Fishing.BL.Model.MapFactory;
using Fishing.Presenter;
using Fishing.View.Menu;
using Fishing.View.Trip;
using System;
using System.Windows.Forms;

namespace Fishing
{
    public partial class Menu : Form, IMenu
    {
        public Menu()
        {
            InitializeComponent();
        }

        public string NickNameL { get => label2.Text; set => label2.Text = value; }
        public string LowerLValue { get => label2.Text; set => label2.Text = value; }
        public BasePresenter Presenter { private get; set; }

        public event EventHandler ExitButtonClick;
        public event EventHandler MenuLoad;

        private void SettingButton_Click(object sender, EventArgs e)
        {
            var settings = new SettingsForm();
            settings.Show();
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            Map map = new Map();
            map.Show();
        }

        private void ShopButton_Click(object sender, EventArgs e)
        {
            var presenter = new ShopPresenter(new Shop());
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            var presenter = new InventoryPresenter(new Inventory());
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            ExitButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            MenuLoad?.Invoke(this, EventArgs.Empty);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var form = new TripForm();
            form.Show();
        }

        public void Open()
        {
            this.Show();
        }

        public void Down()
        {
            this.Close();
        }
    }
}