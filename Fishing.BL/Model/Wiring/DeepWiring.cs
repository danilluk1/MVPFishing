using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Wiring
{
    class DeepWiring : Wiring
    {
        public DeepWiring(int height) : base(height, 5, false)
        {
            
        }

        public override void DoWiring()
        {
            if (Player.GetPlayer().CurrentDeep + Immersion <= Player.GetPlayer().CurrentDeep + HeightOverBottom)
            {
                Player.GetPlayer().CurrentDeep -= 5;
            }
        }
    }
}
