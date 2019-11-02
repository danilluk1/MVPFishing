using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    public class PicturesBoxInfo
    {
        public PicturesBoxInfo(int w, int h, Image img, int T, int L, string LocN)
        {
            Width = w;
            Height = h;
            Image = img;
            Top = T;
            Left = L;
            LocName = LocN;
        }
        public int Width { get; set; }
        public int Height { get; set; }
        public Image Image { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
        public string LocName { get; set; }
    }
}
