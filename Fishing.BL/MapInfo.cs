using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing.BL {

    [Serializable]
    public class MapInfo {
        public string WaterName { get; set; }
        public List<PicturesBoxInfo> Locations { get; set; }
        public Image BackImg { get; set; }

        public MapInfo(Image img, string name, List<PicturesBoxInfo> l) {
            BackImg = img;
            Locations = l;
            WaterName = name;
            MessageBox.Show(l.Count.ToString());
        }
    }
}