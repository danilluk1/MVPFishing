using Fishing.View.GUI;
using Fishing.View.Inventory;
using Fishing.View.LureSelector.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.View.LureSelector.Presenter
{
    class SelectorPresenter
    {
        ISelector view;
        IGUIPresenter gui;
        public SelectorPresenter(ISelector view, IGUIPresenter gui)
        {
            this.view = view;
            this.gui = gui;
            view.LureListDoubleClick += View_LureListDoubleClick;
            view.LureListIndexChanged += View_LureListIndexChanged;
        }

        private void Inv_BaitPicChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_LureListIndexChanged(object sender, EventArgs e)
        {
            view.Picture = view.Lure.Pict;
            view.NameBoxText = view.Lure.Name;
            view.TypeBoxText = view.Lure.Type.ToString();
        }

        private void View_LureListDoubleClick(object sender, EventArgs e)
        {
            Player.getPlayer().Assembly.Lure = view.Lure;
            Player.getPlayer().setAssembly(Player.getPlayer().Assembly);
            (sender as LureSelector).Close();
            gui.BaitPicture = Player.getPlayer().Lure.Pict;
        }
    }
}
