using Fishing.BL.Presenter;
using Fishing.BL.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.View.DeepField
{
    public partial class DeepField : Form
    {
        private LVL lvl;
        public DeepField(LVL lvl)
        {
            InitializeComponent();
            this.lvl = lvl;
            for (int x = 0; x < lvl.Widgth; x++)
            {
                for (int y = 0; y < lvl.Height; y++)
                {
                    Controls.Add(lvl.Deeparr[x, y]);
                }
            }
        }

        private void DeepField_Load(object sender, EventArgs e)
        {

        }
    }
}
