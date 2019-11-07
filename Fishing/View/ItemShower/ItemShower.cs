using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.View.ItemShower
{
    public partial class ItemShower : Form
    {
        public ItemShower()
        {
            InitializeComponent();
            Location = PointToClient(Cursor.Position);
        }
    }
}
