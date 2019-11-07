using Fishing.View.GUI;
using System;

namespace Fishing.Presenter
{
    public class GUIPresenter : BasePresenter
    {
        private IGUIPresenter view;

        public GUIPresenter(IGUIPresenter view)
        {
            this.view = view;
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