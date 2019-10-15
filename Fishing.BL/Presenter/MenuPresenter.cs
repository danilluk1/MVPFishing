using Fishing.BL.Model.Eating;
using Fishing.BL.Model.Game;
using Fishing.View;
using Fishing.View.Menu;
using Saver.BL.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.Presenter
{
    public class MenuPresenter : BasePresenter
    {
        private readonly IMenu view;
        public MenuPresenter(IMenu view)
        {
            
            this.view = view;
            view.Presenter = this;
            view.ExitButtonClick += View_ExitButtonClick;
            view.MenuLoad += Menu_Load;
            BaseController.GetController().Initiallize();
        }

        private void View_ExitButtonClick(object sender, EventArgs e)
        {
            BaseController.GetController().SavePlayer();
            Application.Exit();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            view.lowerLValue = Player.GetPlayer().NickName + " " + Player.GetPlayer().Money + "рублей.";
            Item.RoadShop.Add(Road.Titanium);
            Item.RoadShop.Add(Road.Achilles);
            Item.RoadShop.Add(Road.YSuperCarp);
            Item.RoadShop.Add(Road.SuperFisher);
            Item.ReelShop.Add(Reel.Hydra);
            Item.ReelShop.Add(Reel.SYBERIA_LT_2);
            Item.ReelShop.Add(Reel.Quest_Reel);
            Item.LeskaShop.Add(FLine.Quest_Fishers);
            Item.LeskaShop.Add(FLine.Colorado);
            Item.LeskaShop.Add(FLine.Indiana1500);
            Item.LeskaShop.Add(FLine.Atlantic);
            Item.ReelShop.Add(Reel.SYBERIA_4);
            Item.ReelShop.Add(Reel.Zymix);
            Item.ReelShop.Add(Reel.Syberia_1);
            Item.ReelShop.Add(Reel.TBR_4000);
            BaseFood.FoodShop.Add(BaseFood.blackcaviar);
            BaseFood.FoodShop.Add(BaseFood.caviar);
            BaseFood.FoodShop.Add(BaseFood.bread);
            BaseFood.FoodShop.Add(BaseFood.cheese);
            Player.GetPlayer().FoodInv.Add(BaseFood.bread);
            Player.GetPlayer().FoodInv.Add(BaseFood.caviar);
            Player.GetPlayer().FoodInv.Add(BaseFood.blackcaviar);
            Player.GetPlayer().FoodInv.Add(BaseFood.cheese);

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
