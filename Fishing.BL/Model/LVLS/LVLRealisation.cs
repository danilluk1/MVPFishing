using Fishing.BL.Resources.Images;
using Saver.BL.Controller;
using System;
using Fishing.BL.Model.Game;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Fishing.BL.Model.LVLS
{
    public class LVLRealisation : LVL
    {
        static LabelInfo[,] list;
        static string path = @"C:\Users\Programmer\Desktop\Projects\MVPFish — копия — копия\Fishing.BL\Model\Waters" + "\\" + Game.Game.GetGame().CurrentWater.Name + "\\" + "boloto";
        public LVLRealisation(string name)
        {
            Name = name;
            GetLVLData(name);
            SetDeep();
            AddDeep();
            AddFishes();
        }
        public override void AddFishes()
        {
            string p = @"C:\Users\Programmer\Desktop\Projects\MVPFish — копия — копия\Fishing.BL\Model\Waters" + "\\" + Game.Game.GetGame().CurrentWater.Name + "\\" + "boloto";
            string line;
            System.IO.StreamReader file =
                    new System.IO.StreamReader(p + "\\" + "FishesList");
            while ((line = file.ReadLine()) != null)
            {
                switch (line)
                {
                    case "Голец аркт":
                        break;
                }
            }
        }

        public override void SetDeep()
        {
            Deeparr = new Label[Widgth, Height];
            SerializeDataSaver saver = new SerializeDataSaver();
            LabelInfo[,] deep = saver.Load<LabelInfo[,]>(path + "\\" + "DeepField.dat");
            for(int y = 0; y < Height; y++) 
            {
                for(int x = 0; x < Widgth; x++)
                {
                    Deeparr[x, y] = new Label();
                    Deeparr[x, y].Text = deep[x, y].Deep;
                    Deeparr[x, y].Tag = deep[x, y].IsSnag;
                }
            }
        }
        
        public LVL GetLVLData(string path)
        {
            string p = @"C:\Users\Programmer\Desktop\Projects\MVPFish — копия — копия\Fishing.BL\Model\Waters" + "\\" + Game.Game.GetGame().CurrentWater.Name + "\\" + "boloto";
            SerializeDataSaver s = new SerializeDataSaver();
            Image = Image.FromFile(p+ "\\BackImg.png");
            string sb = File.ReadAllText(p + "\\" + "LVLInfo");
            string[] ar = sb.Split(' ');
            Widgth = Convert.ToInt32(ar[0]);
            Height = Convert.ToInt32(ar[1]);
            LabelStartX = Convert.ToInt32(ar[2]);
            LabelStartY = Convert.ToInt32(ar[3]);
            return this;
        }
    }
}
