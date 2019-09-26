using Fishing.Presenter;
using Fishing.View;
using Fishing.View.Menu;
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
            GUI.gui = new GUI();
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
            SettingsButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            MapButtonClick?.Invoke(this, EventArgs.Empty);

        }

        private void ShopButton_Click(object sender, EventArgs e)
        {
            ShopButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            InventoryButtonClick?.Invoke(this, EventArgs.Empty);
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
    }
}
