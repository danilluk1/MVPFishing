using Fishing.BL.Model.Waters;
using Saver.BL.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Timer HoursTimer { get; set; }
        public Water CurrentWater { get; set; } = Meshera.GetWater();
        public Time Time;

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
            if(game == null)
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
