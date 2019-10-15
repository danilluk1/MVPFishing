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
    public class GUIPresenter : BasePresenter
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
            view.EventBarClick += View_EventBarClick;
           
        }

        private void View_EventBarClick(object sender, EventArgs e)
        {
           
        }

        private void View_SettingsButtonClick(object sender, EventArgs e)
        {
        }

        private void View_MenuButtonClick(object sender, EventArgs e)
        {
        }

        private void View_MapButtonClick(object sender, EventArgs e)
        {
        }

        private void View_InventoryButtonClick(object sender, EventArgs e)
        {
        }

        private void View_FPondClick(object sender, EventArgs e)
        {
        }

        private void View_BaitPicClick(object sender, EventArgs e)
        {
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }
    }
}
