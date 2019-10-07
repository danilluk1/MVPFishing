using Fishing.BL.Resources.Sounds;
using Fishing.BL.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Presenter
{
    public class FoodPresenter
    {
        private readonly IFoodInventory view;
        private readonly Player player;
        private SoundPlayer sp;
        public FoodPresenter(IFoodInventory view)
        {
            this.view = view;
            view.ListDoubleClick += View_ListDoubleClick;
            view.ListSelectedIndexChanged += View_ListSelectedIndexChanged;
            player = Player.GetPlayer();
            sp = new SoundPlayer(SoundsRes.eat);

        }

        private void View_ListSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                view.FoodImage = player.FoodInv[view.SelectedIndex].Pict;
                view.FoodProductivityTextBox = player.FoodInv[view.SelectedIndex].Productivity.ToString();
            }
            catch(NullReferenceException) { }
            catch (ArgumentOutOfRangeException) { }
        }

        private void View_ListDoubleClick(object sender, EventArgs e)
        {
            try
            {
                player.Eat(player.FoodInv[view.SelectedIndex]);
                sp.Play();
            }
            catch (NullReferenceException) { }
        }
    }
}
