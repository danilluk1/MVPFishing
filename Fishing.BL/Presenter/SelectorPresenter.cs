using Fishing.Presenter;
using Fishing.View.GUI;
using Fishing.View.LureSelector.View;
using System;

namespace Fishing.View.LureSelector.Presenter
{
    public class SelectorPresenter : BasePresenter
    {
        private ISelector<Lure> view;
        private IGUIPresenter gui;

        public SelectorPresenter(ISelector<Lure> view, IGUIPresenter gui)
        {
            this.view = view;
            this.gui = gui;
            view.Presenter = this;
            view.Open();
            view.LureListDoubleClick += View_LureListDoubleClick;
            view.LureListIndexChanged += View_LureListIndexChanged;
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
                Player.GetPlayer().EquipedRoad.Assembly.FishBait = view.Lure;                
                gui.BaitPicture = Player.GetPlayer().EquipedRoad.Assembly.FishBait.Pict;
                view.Down();
            }
            catch (NullReferenceException)
            {
            }
        }
    }
}