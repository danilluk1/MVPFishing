using Fishing.BL.View;
using System;
using System.Windows.Forms;

namespace Fishing.View.DeepField
{
    public partial class DeepField : Form, IDeepField
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

        public void Down()
        {
            this.Close();
        }

        public void Open(LVL lvl)
        {
            DeepField df = new DeepField(lvl);
        }

        private void DeepField_Load(object sender, EventArgs e)
        {
        }
    }
}