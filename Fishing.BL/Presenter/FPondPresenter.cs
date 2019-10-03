using Fishing.BL.Resources.Images;
using Fishing.View.FPond;
using Fishing.View.GUI;
using System;

namespace Fishing.Presenter
{
    public class FPondPresenter
    {
        IFPond view;
        IGUIPresenter gui;
        public FPondPresenter(IFPond view, IGUIPresenter gui)
        {
            this.view = view;
            this.gui = gui;
            view.SellButtonClick += View_SellButtonClick;
            view.SelectedIndexChanged += View_SelectedIndexChanged;
        }

        private void View_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Player.GetPlayer().GetFishByIndex(view.SelectedIndex) is ArcticChar)
                    view.RightImage = Images.golec;
                if (Player.GetPlayer().GetFishByIndex(view.SelectedIndex) is Perch)
                    view.RightImage = Images._1040;
                if (Player.GetPlayer().GetFishByIndex(view.SelectedIndex) is PinkSalmon)
                    view.RightImage = Images.gorbusha;
                if (Player.GetPlayer().GetFishByIndex(view.SelectedIndex) is Pike)
                    view.RightImage = Images.pike;
                if (Player.GetPlayer().GetFishByIndex(view.SelectedIndex) is Grayling)
                    view.RightImage = Images._1081;
                if (Player.GetPlayer().GetFishByIndex(view.SelectedIndex) is Trout)
                    view.RightImage = Images._1052;
                if (Player.GetPlayer().GetFishByIndex(view.SelectedIndex) is Salmon)
                    view.RightImage = Images._1039;

                view.DescriptionText = Player.GetPlayer().GetFishByIndex(view.SelectedIndex).Description;
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch (NullReferenceException)
            {
            }
        }

        private void View_SellButtonClick(object sender, EventArgs e)
        {
            Player.GetPlayer().SellFish(Player.GetPlayer().GetFishByIndex(view.SelectedIndex));
            gui.MoneyLValue = Player.GetPlayer().Money;
            view.DescriptionText = " ";
            view.RightImage = null;
        }
    }
}
