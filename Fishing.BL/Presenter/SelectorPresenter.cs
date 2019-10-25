using Fishing.Presenter;
using Fishing.View.GUI;
using Fishing.View.LureSelector.View;
using System;

namespace Fishing.View.LureSelector.Presenter
{
    public class SelectorPresenter : BasePresenter
    {
        private ISelector view;
        private IGUIPresenter gui;

        public SelectorPresenter(ISelector view, IGUIPresenter gui)
        {
            this.view = view;
            this.gui = gui;
            view.Presenter = this;
            view.Open();
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
            view.DeepBoxText = view.Lure.DeepType.ToString();
            view.SizeBoxText = view.Lure.Size.ToString();
        }

        private void View_LureListDoubleClick(object sender, EventArgs e)
        {
            try
            {
                Player.GetPlayer().Assembly.Lure = view.Lure;
                Player.GetPlayer().SetAssembly(Player.GetPlayer().Assembly);
                gui.BaitPicture = Player.GetPlayer().Assembly.Lure.Pict;
                view.Down();
            }
            catch (NullReferenceException)
            {
            }
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