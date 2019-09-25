using Fishing.View.GUI;
using Fishing.View.LureSelector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.Presenter
{
    class GUIPresenter : Presenter
    {
        IGUI view;
        public GUIPresenter(IGUI view)
        {
            this.view = view;
            view.BaitPicClick += View_BaitPicClick;
            view.FPondClick += View_FPondClick;
            view.InventoryButtonClick += View_InventoryButtonClick;
            view.MapButtonClick += View_MapButtonClick;
            view.MenuButtonClick += View_MenuButtonClick;
            view.SettingsButtonClick += View_SettingsButtonClick;
           
        }

        private void View_SettingsButtonClick(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.Show();
        }

        private void View_MenuButtonClick(object sender, EventArgs e)
        {
            GUI.gui.Close();
            Ozero.ozero.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        private void View_MapButtonClick(object sender, EventArgs e)
        {
            Ozero map = new Ozero();
            map.Show();
        }

        private void View_InventoryButtonClick(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.Show();
        }

        private void View_FPondClick(object sender, EventArgs e)
        {
            fishesForm form = new fishesForm();
            form.Show();
        }

        private void View_BaitPicClick(object sender, EventArgs e)
        {
            LureSelector selector = new LureSelector();
            selector.Show();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

       
    }
}
