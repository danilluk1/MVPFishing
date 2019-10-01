using Fishing.BL.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.BL.Model.Game
{
    public sealed class Sounder
    {
        private static Sounder sounder;
        public int Column { get; set; }
        public int Row { get; set; }

        private Sounder()
        {
        }
        public static Sounder getSounder()
        {
            if (sounder == null)
            {
                sounder = new Sounder();
            }

            return sounder;
        }
    }
}
