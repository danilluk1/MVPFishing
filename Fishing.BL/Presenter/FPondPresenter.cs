using Fishing.BL;
using Fishing.View.FPond;
using Fishing.View.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                if (Player.getPlayer().GetFishByIndex(view.SelectedIndex) is ArcticChar)
                    view.RightImage = Images.golec;
                if (Player.getPlayer().GetFishByIndex(view.SelectedIndex) is Perch)
                    view.RightImage = Images._1040;
                if (Player.getPlayer().GetFishByIndex(view.SelectedIndex) is PinkSalmon)
                    view.RightImage = Images.gorbusha;
                if (Player.getPlayer().GetFishByIndex(view.SelectedIndex) is Pike)
                    view.RightImage = Images.pike;

                view.DescriptionText = Player.getPlayer().GetFishByIndex(view.SelectedIndex).Description;
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
            Player.getPlayer().SellFish(Player.getPlayer().GetFishByIndex(view.SelectedIndex));
            gui.MoneyLValue = Player.getPlayer().Money;
            view.DescriptionText = " ";
            view.RightImage = null;
        }
    }
}
