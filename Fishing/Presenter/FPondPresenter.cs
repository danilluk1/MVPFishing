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
    class FPondPresenter
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
                    view.RightImage = Resource1.GOLEC;
                if (Player.getPlayer().GetFishByIndex(view.SelectedIndex) is Perch)
                    view.RightImage = Resource1.PERCH;
                if (Player.getPlayer().GetFishByIndex(view.SelectedIndex) is PinkSalmon)
                    view.RightImage = Resource1.GORBUSHA;
                if (Player.getPlayer().GetFishByIndex(view.SelectedIndex) is Pike)
                    view.RightImage = Resource1.PIKE;

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
