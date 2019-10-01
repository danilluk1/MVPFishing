using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.BL.View
{
    public interface ISounder
    {
        event PaintEventHandler SounderPaint;
        event EventHandler RefreshSounder;
    }
}
