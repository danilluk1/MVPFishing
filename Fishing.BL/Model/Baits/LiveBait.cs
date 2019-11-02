using Fishing.BL.Resources.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.BL.Model.Baits
{
    [Serializable]
    public class LiveBait : Bait
    {
        public LiveBait() : base("Живец", 30, 5000, Images.zhivec)
        {
        }
    }
}
