using Fishing.View;
using Fishing.View.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.Presenter
{
    class MenuPresenter : Presenter
    {
        private readonly IMenu view;
        public MenuPresenter(IMenu view)
        {
            this.view = view;
            view.InventoryButtonClick += View_InventoryButtonClick;
            view.SettingsButtonClick += View_SettingsButtonClick;
            view.ShopButtonClick += View_ShopButtonClick;
            view.ExitButtonClick += View_ExitButtonClick;
            view.MapButtonClick += View_MapButtonClick;
        }

        private void View_MapButtonClick(object sender, EventArgs e)
        {
            Ozero map = new Ozero();
            map.Show();
        }

        private void View_ExitButtonClick(object sender, EventArgs e)
        {
            (sender as Menu).Close();
            Player.getPlayer().Save("user.dat", Player.getPlayer());
        }

        private void View_ShopButtonClick(object sender, EventArgs e)
        {
            Shop shop = new Shop();
            shop.Show();
        }

        private void View_SettingsButtonClick(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.Show();
        }

        private void View_InventoryButtonClick(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.Show();
        }

        public void Load()
        {          
        }

        public void Close()
        {
            Application.Exit();
        }

        public void MapButtonClick()
        {
            Ozero ozero = new Ozero();
            ozero.Show();
        }

        public void ShopButtonClick()
        {
            Shop shop = new Shop();
            shop.Show();
        }

        public void SettingsButtonClick()
        {
            SettingsForm sf = new SettingsForm();
            sf.Show();
        }

        public void InventoryButtonClick()
        {
            Inventory inv = new Inventory();
            inv.Show();
        }
        private void MapButton_Click(object sender, EventArgs e)
        {
            MapButtonClick();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsButtonClick();
        }

        private void ShopButton_Click(object sender, EventArgs e)
        {
            ShopButtonClick();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Player.getPlayer().LureInv = Player.getPlayer().Load<BindingList<Lure>>("user.dat");
            MessageBox.Show(Player.getPlayer().LureInv.Count.ToString());
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            InventoryButtonClick();
        }

    }
}
