using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.View
{
    public interface IDeepField
    {
        void Open(LVL lvl);
        void Down();
    }
}
