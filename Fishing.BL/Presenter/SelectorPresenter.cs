using Fishing.BL.Model.Baits;
using Fishing.Presenter;
using Fishing.View.GUI;
using Fishing.View.LureSelector.View;
using System;

namespace Fishing.View.LureSelector.Presenter
{
    public class SelectorPresenter<T> : BasePresenter where T : FishBait
    {
        private ISelector<T> view;
        private IGUIPresenter gui;

        public SelectorPresenter(ISelector<T> view, IGUIPresenter gui)
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
            view.Picture = view.FishBait.Pict;
            if (view.FishBait is Lure l)
            {
                view.DeepBoxText = l.DeepType.ToString();
                view.SizeBoxText = l.Size.ToString();
            }
            if (view.FishBait is Bait b)
            {
                view.SizeBoxText = b.Count.ToString();
                view.DeepBoxText = b.Name.ToString();
            }
        }

        private void View_LureListDoubleClick(object sender, EventArgs e)
        {
            try
            {
                Player.GetPlayer().EquipedRoad.Assembly.FishBait = view.FishBait;                
                gui.BaitPicture = Player.GetPlayer().EquipedRoad.Assembly.FishBait.Pict;
                view.Down();
            }
            catch (NullReferenceException)
            {
            }
        }

        public override void Run()
        {
            view.Open();
        }

        public override void End()
        {
            view.Down();
        }
    }
}