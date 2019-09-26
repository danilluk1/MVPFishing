using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing
{
    abstract class LVL
    {
        private static CurrentFish currentFish = new CurrentFish();
        public static LVL2 lvl2 = new LVL2();
        public static Label[,] Deeparr = new Label[51, 18];
        protected List<Fish> fishes = new List<Fish>(1000);
        public abstract void addFishes();

        public abstract void getFish();

        public abstract void SetDeep();

        public static bool isFishAttackAbble(Fish fish)
        {
            try
            {
                var bait = fish.Lures.Single(b => b == Player.getPlayer().Lure.Type);
                bool ba = bait.ToString() == null ? false : true;
                return ba;
            }
            catch (InvalidOperationException){ return false; }
        }
        public static void setCurrentFish()
        {
            Player player = Player.getPlayer();
            currentFish = new CurrentFish();

            if (player.CFish is Pike)
            {
                currentFish.FishImage.Image = Resource1.PIKE;
            }
            if (player.CFish is Perch)
            {
                currentFish.FishImage.Image = Resource1.PERCH;
            }
            if (player.CFish is PinkSalmon)
            {
                currentFish.FishImage.Image = Resource1.GORBUSHA;
            }
            if (player.CFish is ArcticChar)
            {
                currentFish.FishImage.Image = Resource1.GOLEC1;
            }
            if(player.CFish is Grayling)
            {
                currentFish.FishImage.Image = Resource1.XARIYS;
            }
            if (player.CFish is Salmon)
            {
                currentFish.FishImage.Image = Resource1.SEMGA;
            }
            if (player.CFish is Trout)
            {
                currentFish.FishImage.Image = Resource1.FOREL;
            }       
            currentFish.NameLabel.Text = player.CFish.Name;
            currentFish.WeightLabel.Text = player.CFish.Weight.ToString();
            currentFish.PriceButton.Text = (player.CFish.Price * player.CFish.Weight).ToString();
            currentFish.Show();
            Player.getPlayer().isFishAttack = false;
        }

        public void MainTimertick()
        {
            if (GUI.gui.FLineBar.Value > 0)
                GUI.gui.FLineBar.Increment(-1);
            if (GUI.gui.ReelBar.Value > 0)
                GUI.gui.ReelBar.Increment(-1);
            if (GUI.gui.FLineBar.Value > 98)
            {
                GUI.gui.EventsBox.Items.Add(Player.getPlayer().NickName + " порвал леску");
                Player.getPlayer().isFishAttack = false;
                Player.getPlayer().CurPoint.Y = 0;
                Player.getPlayer().Assembly.Lure = null;
            }
            if (GUI.gui.ReelBar.Value > 98)
            {
                GUI.gui.EventsBox.Items.Add(Player.getPlayer().NickName + " сломал удочку");
                Pictures.road = Pictures.brokenRoad;
                Player.getPlayer().isFishAttack = false;
                Player.getPlayer().Assembly.Proad = null;
                Player.getPlayer().CurPoint.Y = 800;
            }
            Ozero.ozero.Refresh();
            if (Player.getPlayer().CurPoint.X > 1049) Player.getPlayer().CurPoint.X = 1048;
            if (Player.getPlayer().CurPoint.X < 0) Player.getPlayer().CurPoint.X = 1;
            if (Player.getPlayer().NettingY == 550 && Player.getPlayer().isFishAttack && Player.getPlayer().CurPoint.Y > 600)
            {
                if (GUI.gui.EventsBox.Items.Count > 5) GUI.gui.EventsBox.Items.Clear();
                GUI.gui.FLineBar.Value = 0;
                GUI.gui.ReelBar.Value = 0;
                Player.getPlayer().SavePlayer();
                LVL.setCurrentFish();
                string message = Player.getPlayer().NickName + " поймал " + Player.getPlayer().CFish.ToString();
                if (Player.getPlayer().CFish.isTrophy())
                {
                    message = "Трофей! " + Player.getPlayer().NickName + " поймал " + Player.getPlayer().CFish.ToString();
                }
                GUI.gui.AddEventToBox(message);
            }
            Player.getPlayer().NettingY = 800;
        }
    }
}
