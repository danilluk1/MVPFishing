using Fishing.View.Shop;
using System;

namespace Fishing.Presenter
{
    public class ShopPresenter : BasePresenter
    {
        private IShop view;

        public ShopPresenter(IShop view)
        {
            this.view = view;
            view.Presenter = this;
            view.Open();
            view.FLineDoubleClick += View_FLineDoubleClick;
            view.ReelDoubleClick += View_ReelDoubleClick;
            view.RoadDoubleClick += View_RoadDoubleClick;
            view.ProductDoubleClick += View_ProductDoubleClick;
            view.LureDoubleClick += View_LureDoubleClick;
            view.BaitDoubleClick += View_BaitDoubleClick;
        }

        private void View_BaitDoubleClick(object sender, EventArgs e)
        {
            if (IsPlayerAbleToBuyItem(view.Bait_P))
            {
                Player.GetPlayer().BaitInv.Add(view.Bait_P);
                Player.GetPlayer().Money -= view.Bait_P.Price;
                view.MoneyL = Player.GetPlayer().Money.ToString();
                view.LowerL = "Куплено...";
            }
        }

        private void View_LureDoubleClick(object sender, EventArgs e)
        {
            if (IsPlayerAbleToBuyItem(view.Lure_P))
            {
                Player.GetPlayer().LureInv.Add(view.Lure_P);
                Player.GetPlayer().Money -= view.Lure_P.Price;
                view.MoneyL = Player.GetPlayer().Money.ToString();
                view.LowerL = "Куплено...";
            }
        }

        private void View_ProductDoubleClick(object sender, EventArgs e)
        {
            if (IsPlayerAbleToBuyItem(view.Road_P))
            {
                Player.GetPlayer().FoodInv.Add(view.Food_P);
                Player.GetPlayer().Money -= view.Food_P.Price;
                view.MoneyL = Player.GetPlayer().Money.ToString();
                view.LowerL = "Куплено...";
            }
        }

        private void View_RoadDoubleClick(object sender, EventArgs e)
        {
            if (IsPlayerAbleToBuyItem(view.Road_P))
            {
                Player.GetPlayer().RoadInv.Add(view.Road_P);
                Player.GetPlayer().Money -= view.Road_P.Price;
                view.MoneyL = Player.GetPlayer().Money.ToString();
                view.LowerL = "Куплено...";
            }
        }

        private void View_ReelDoubleClick(object sender, EventArgs e)
        {
            if (IsPlayerAbleToBuyItem(view.Reel_P))
            {
                Player.GetPlayer().ReelInv.Add(view.Reel_P);
                Player.GetPlayer().Money -= view.Reel_P.Price;
                view.MoneyL = Player.GetPlayer().Money.ToString();
                view.LowerL = "Куплено...";
            }
        }

        private void View_FLineDoubleClick(object sender, EventArgs e)
        {
            if (IsPlayerAbleToBuyItem(view.FLine_P))
            {
                Player.GetPlayer().FLineInv.Add(view.FLine_P);
                Player.GetPlayer().Money -= view.FLine_P.Price;
                view.MoneyL = Player.GetPlayer().Money.ToString();
                view.LowerL = "Куплено...";
            }
        }

        private bool IsPlayerAbleToBuyItem(Item item)
        {
            bool result;
            result = item.Price <= Player.GetPlayer().Money ? true : false;

            return result;
        }
    }
}