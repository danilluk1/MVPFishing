using Fishing.BL.Model.Eating;
using Fishing.BL.Resources.Sounds;
using Fishing.BL.View;
using Fishing.Presenter;
using System;
using System.Media;
using System.Linq;

namespace Fishing.BL.Presenter
{
    public class FoodPresenter : BasePresenter
    {
        private IFoodInventory view;
        private readonly Player player;
        private SoundPlayer sp;
        private Food food;
        public FoodPresenter(IFoodInventory view)
        {
            this.view = view;
            view.Presenter = this;
            view.ListDoubleClick += View_ListDoubleClick;
            view.ListSelectedIndexChanged += View_ListSelectedIndexChanged;
            player = Player.GetPlayer();
            sp = new SoundPlayer(SoundsRes.eat);
        }

        private void View_ListSelectedIndexChanged(object sender, EventArgs e)
        {
            food = Food.GetFoodByName(view.FoodsSelectedItem);
            food = player.FoodInv.First(f => f.Name.Equals(food.Name));
            view.ShowFood(food);
        }

        private void View_ListDoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (player.Eat(food))
                {
                    sp.Play();
                }
            }
            catch (NullReferenceException) { }
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