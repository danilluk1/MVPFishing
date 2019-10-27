using Fishing.BL.Model.Waters;
using Fishing.View.LVLS.Ozero;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Fishing.BL.Model.Game
{
    public enum PartsOfDay
    {
        Morning,
        Day,
        Evening,
        Night
    }

    [Serializable]
    public class Game
    {
        private static Game game;
        public BindingList<Water> Waters = new BindingList<Water>();

        public event EventHandler HoursInc;

        public IGameForm View { get; set; }

        public Timer HoursTimer { get; set; }
        public Water CurrentWater { get; set; } = Ozero.GetWater();
        public Time Time { get; set; }

        private Game()
        {
            Time = new Time();
            HoursTimer = new Timer()
            {
                Interval = 30000
            };
            HoursTimer.Tick += HoursTimer_Tick;
            HoursTimer.Start();
            Waters.Add(Ozero.GetWater());
            Waters.Add(Meshera.GetWater());
        }

        public static Game GetGame()
        {
            if (game == null)
            {
                game = new Game();
            }
            return game;
        }

        private void HoursTimer_Tick(object sender, EventArgs e)
        {
            Time.IncHours(1);
            HoursInc?.Invoke(this, EventArgs.Empty);
        }
    }
}