using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Wiring
{
    public abstract class Wiring
    {
        public bool IsBottomTouched { get; set; }
        public int HeightOverBottom { get; set; }
        public int Immersion { get; set; }

        public Wiring(int heightoverbottom, int immersion, bool isbottomtouched)
        {
            this.HeightOverBottom = heightoverbottom;
            this.IsBottomTouched = isbottomtouched;
            this.Immersion = immersion;
        }
        public abstract void DoWiring();

    }
}
