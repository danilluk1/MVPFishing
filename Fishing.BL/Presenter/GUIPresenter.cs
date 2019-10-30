using Fishing.View.GUI;
using System;

namespace Fishing.Presenter
{
    public class GUIPresenter : BasePresenter
    {
        private IGUI view;

        public GUIPresenter(IGUI view)
        {
            this.view = view;
        }
    }
}