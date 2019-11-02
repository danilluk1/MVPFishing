using Fishing.BL.Resources.Images;
using Saver.BL.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Fishing.BL.Model.Waters
{
    [Serializable]
    public class WaterRealisation : Water
    {
        static Image backimg;
        static int dp = 0;
        static int km = 0;
        static int minlvl = 0;
        static List<PicturesBoxInfo> locs;
        public WaterRealisation(string name) : base(name, Images.ozero1f, 0, 0, locs)
        {
            this.Name = name;
            GetLVL(name);
            Locs = locs;
            MessageBox.Show(Name, KmFromNearestStation.ToString());
        }

        public void GetLVL(string name)
        {
            var path = @"C:\Users\Programmer\Desktop\Projects\MVPFish — копия — копия\Fishing.BL\Model\Waters" + "\\" + name;
            SerializeDataSaver s = new SerializeDataSaver();
            string sb = File.ReadAllText(path + "\\" +"WaterInfo");           
            string[] ar = sb.Split(' ');
            MapImage = Image.FromFile(path + "\\" + "MapImg.png");
            Name = ar[0];
            MinLVL = Convert.ToInt32(ar[1]);
            DailyPrice = Convert.ToInt32(ar[2]);
            KmFromNearestStation = Convert.ToInt32(ar[3]);
            locs = s.Load<List<PicturesBoxInfo>>(path + "\\" + "Map.dat");

        }
    }
}
