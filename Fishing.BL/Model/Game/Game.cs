using System;
using System.Collections.Generic;
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
        public event EventHandler HoursInc;
        public Timer HoursTimer { get; set; }
        public Time Time;
        public Player player;

        private Game(Player player)
        {
            this.player = player;
            Time = new Time();
            HoursTimer = new Timer()
            {
                Interval = 30000
            };
            HoursTimer.Tick += HoursTimer_Tick;
            HoursTimer.Start();
        }

        public static Game GetGame()
        {
            if(game == null)
            {
                game = new Game(Player.GetPlayer());
            }
            return game;
        }
        private void HoursTimer_Tick(object sender, EventArgs e)
        {
            if(Time.Hours <= 23)
            {
                Time.Hours++;
            }
            else if(Time.Hours == 24)
            {
                Time.Hours = 0;
                Time.Day++;
                
            }

            if(Time.Hours >= 0 && Time.Hours <= 4)
            {
                Time.Part = PartsOfDay.Night;
            }
            if (Time.Hours > 4 && Time.Hours <= 10)
            {
                Time.Part = PartsOfDay.Morning;
            }
            if (Time.Hours > 10 && Time.Hours <= 16)
            {
                Time.Part = PartsOfDay.Day;
            }
            if (Time.Hours > 16 && Time.Hours <= 24)
            {
                Time.Part = PartsOfDay.Evening;
            }
            HoursInc?.Invoke(this, EventArgs.Empty);
        }
    }
}
