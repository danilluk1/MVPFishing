using Saver.BL.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using WindowsFormsApp1;

namespace Fishing.BL.Model.Waters {

    [Serializable]
    public class WaterRealisation : Water {

        public WaterRealisation() {
        }

        public override Water GetLVL(string name) {
            var path = @"C:\Users\Programmer\Desktop\Projects\MVPFish — копия — копия\Fishing.BL\Model\Waters" + "\\" + name;
            SerializeDataSaver s = new SerializeDataSaver();
            string sb = File.ReadAllText(path + "\\" + "WaterInfo");
            string[] ar = sb.Split(' ');
            MapImage = Image.FromFile(path + "\\" + "MapImg.png");
            Name = ar[0];
            MinLVL = Convert.ToInt32(ar[1]);
            DailyPrice = Convert.ToInt32(ar[2]);
            KmFromNearestStation = Convert.ToInt32(ar[3]);
            Locs = s.Load<List<PicturesBoxInfo>>(path + "\\" + "Map.dat");
            return this;
        }
    }
}