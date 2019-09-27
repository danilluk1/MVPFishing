using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fishing;
using Fishing.View.Shop;

namespace Fishing.Presenter
{
    public class ShopPresenter
    {
        IShop view;
        public ShopPresenter(IShop view)
        {
            this.view = view;
            view.CloseButtonClick += CloseButton_Click;
            view.FLineSelectedIndexChanged += FLineList_SelectedIndexChanged;
            view.ReelSelectedIndexChanged += ReelsList_SelectedIndexChanged;
            view.RoadSelectedIndexChanged += RoadsList_SelectedIndexChanged;
            view.FLineDoubleClick += View_FLineDoubleClick;
            view.ReelDoubleClick += View_ReelDoubleClick;
            view.RoadDoubleClick += View_RoadDoubleClick;
        }

        private void View_RoadDoubleClick(object sender, EventArgs e)
        {
            if (isPlayerAbleToBuyItem(view.Road_P))
            {
                Player.getPlayer().RoadInv.Add(view.Road_P);
                Player.getPlayer().Money -= view.Road_P.Price;
                view.MoneyL = Player.getPlayer().Money.ToString();
            }
        }

        private void View_ReelDoubleClick(object sender, EventArgs e)
        {
            if (isPlayerAbleToBuyItem(view.Reel_P))
            {
                Player.getPlayer().ReelInv.Add(view.Reel_P);
                Player.getPlayer().Money -= view.Reel_P.Price;
                view.MoneyL = Player.getPlayer().Money.ToString();
            }
        }

        private void View_FLineDoubleClick(object sender, EventArgs e)
        {
            if (isPlayerAbleToBuyItem(view.FLine_P))
            {
                Player.getPlayer().FLineInv.Add(view.FLine_P);
                Player.getPlayer().Money -= view.FLine_P.Price;
                view.MoneyL = Player.getPlayer().Money.ToString();
            }
        }

        

        private bool isPlayerAbleToBuyItem(Item item)
        {
            bool result;
            result = item.Price <= Player.getPlayer().Money ? true : false;

            return result;
        }
       

        private void RoadsList_SelectedIndexChanged(object sender, EventArgs e)
        {         
            
        }

        private void ReelsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FLineList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
           
        }
    }
}
