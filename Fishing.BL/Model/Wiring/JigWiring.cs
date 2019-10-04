using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.BL.Model.Wiring
{
    class JigWiring : Wiring
    {
        public Timer JigTimer;

        public Timer MaxPauseTimer = new Timer()
        {
            Interval = 5000,
        };
        public JigWiring(int height, bool bottom) : base(height, bottom)
        {
            JigTimer = new Timer()
            {
                Interval = 3000
            };
            JigTimer.Tick += JigTimer_Tick;

            MaxPauseTimer.Tick += MaxPauseTimer_Tick;
        }

        private void MaxPauseTimer_Tick(object sender, EventArgs e)
        {
            Player.GetPlayer().IsJigging = false;
            MaxPauseTimer.Stop();
        }

        private void JigTimer_Tick(object sender, EventArgs e)
        {
            if (this.IsBottomTouched)
            {
                Player.GetPlayer().IsJigging = true;
            }
            else
            {
                Player.GetPlayer().IsJigging = false;
            }
            JigTimer.Stop();
            MaxPauseTimer.Start();
        }

        public override void DoWiring()
        {
            JigTimer.Start();
            Player.GetPlayer().CurrentDeep -= this.HeightOverBottom;
            IsBottomTouched = false;
        }
    }
}
