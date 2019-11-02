using Fishing.BL.Resources.Images;
using Saver.BL.Controller;
using System;
using Fishing.BL.Model.Game;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace Fishing.BL.Model.LVLS
{
    class LVLRealisation : LVL
    {
        Images image;
        static string Name;
        public LVLRealisation(string name) : base (Images.MesheraLVL1, 49, 18, 10, 310)
        {

        }
        public override void AddFishes()
        {
            string line;
            var path = @"C:\Users\Programmer\Desktop\Projects\MVPFish — копия — копия\Fishing.BL\Model\Waters" + "\\" + Game.Game.GetGame().CurrentWater.Name + "\\" + Name;
            System.IO.StreamReader file =
                    new System.IO.StreamReader(@"c:\test.txt");
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
            var path = @"C:\Users\Programmer\Desktop\Projects\MVPFish — копия — копия\Fishing.BL\Model\Waters" + "\\" + Game.Game.GetGame().CurrentWater.Name + "\\" + Name;
            SerializeDataSaver saver = new SerializeDataSaver();
            LabelInfo[,] deep = saver.Load<LabelInfo[,]>(path + "\\" + "DeepField.dat");
            for(int i = 0; i < deep.Length; i++) 
            {
                for(int y = 0; y < deep.Length; i++)
                {
                    Deeparr[i, y].Text = deep[i, y].Deep;
                    Deeparr[i, y].Tag = deep[i, y].IsSnag;
                }
            }
        }
        
        public void GetLVLData(string path)
        {

        }
    }
}
