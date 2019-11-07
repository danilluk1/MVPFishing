﻿using Fishing.BL.Resources.Images;
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
        
        public LVLRealisation()
        {
        }
        public override void AddFishes()
        {
            string p = @"C:\Users\Programmer\Desktop\Projects\MVPFish — копия — копия\Fishing.BL\Model\Waters" + "\\" + Game.Game.GetGame().CurrentWater.Name + "\\" + Name;
            string line;
            System.IO.StreamReader file =
                    new System.IO.StreamReader(p + "\\" + "FishesList");
            while ((line = file.ReadLine()) != null)
            {
                FishString fs = new FishString(line);
                var fish = fs.GetFishByStr(line);
                Fishes.Add(fish);
            }
        }

        public override void SetDeep()
        {
            string p = @"C:\Users\Programmer\Desktop\Projects\MVPFish — копия — копия\Fishing.BL\Model\Waters" + "\\" + Game.Game.GetGame().CurrentWater.Name + "\\" + Name;
            Deeparr = new Label[Widgth, Height];
            SerializeDataSaver saver = new SerializeDataSaver();
            LabelInfo[,] deep = saver.Load<LabelInfo[,]>(p + "\\" + "DeepField.dat");
            for (int x = 0; x < Widgth; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    this.Deeparr[x, y] = new Label()
                    {
                        Left = LabelStartX + 5 + x * 40,
                        Top = LabelStartY + y * 23,
                        Height = 23,
                        TextAlign = ContentAlignment.MiddleLeft,
                        ForeColor = Color.White,
                        Width = 40,
                        Visible = true,
                        Font = new Font("Arial", 8, FontStyle.Regular),
                        BorderStyle = BorderStyle.FixedSingle,
                        Text = deep[x, y].Deep,                      
                        Tag = deep[x, y].IsSnag
                    };
                }
            }
        }
        
        public LVL GetLVLData(string path)
        {
            Name = path;
            string p = @"C:\Users\Programmer\Desktop\Projects\MVPFish — копия — копия\Fishing.BL\Model\Waters" + "\\" + Game.Game.GetGame().CurrentWater.Name + "\\" + path;
            SerializeDataSaver s = new SerializeDataSaver();
            Image = Image.FromFile(p+ "\\BackImg.jpg");
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
