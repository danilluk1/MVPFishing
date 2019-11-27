using Saver.BL.Controller;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Fishing.BL.Model.LVLS {

    public class LvlImplementation : LVL {

        public override void AddFishes() {
            var p = @"C:\Users\Programmer\Desktop\Projects\MVPFish — копия — копия\Fishing.BL\Model\Waters"
                       + Path.DirectorySeparatorChar
                       + Game.Game.GetGame().CurrentWater.Name
                       + Path.DirectorySeparatorChar + Name;
            string line;
            var file =
                    new StreamReader(p + "Болото\\" + "FishesList");
            while ((line = file.ReadLine()) != null) {
                var fs = new FishString(line);
                Fishes.Add((Fish)fs);
            }
            file.Close();
        }

        public override void SetDeep() {
            var saver = new SerializeDataSaver();
            var p = @"C:\Users\Programmer\Desktop\Projects\MVPFish — копия — копия\Fishing.BL\Model\Waters"
                    + Path.DirectorySeparatorChar
                    + Game.Game.GetGame().CurrentWater.Name
                    + Path.DirectorySeparatorChar + "Болото";

            var deepField = saver.Load<LabelInfo[,]>(p + "\\" + "DeepField.dat");
            DeepArray = new Label[Widgth, Height];
            for (var y = 0; y < Height; y++) {
                for (var x = 0; x < Widgth; x++) {
                    DeepArray[x, y] = new Label() {
                        Left = DeepTiesStartX + 5 + x * 40,
                        Top = DeepTiesStartY + y * 23,
                        Height = 23,
                        TextAlign = ContentAlignment.MiddleLeft,
                        ForeColor = Color.White,
                        Width = 40,
                        Visible = true,
                        Font = new Font("Arial", 8, FontStyle.Regular),
                        BorderStyle = BorderStyle.FixedSingle,
                        Text = deepField[x, y].Deep,
                        Tag = deepField[x, y].IsSnag
                    };
                }
            }
        }

        public LVL GetLVLData(string path) {
            Name = path;
            string p = @"C:\Users\Programmer\Desktop\Projects\MVPFish — копия — копия\Fishing.BL\Model\Waters" + "\\" + Game.Game.GetGame().CurrentWater.Name + "\\" + path;

            Image = Image.FromFile(p + "Болото\\BackImg.jpg");

            string sb = File.ReadAllText(p + "\\Болото\\" + "LVLInfo");
            string[] ar = sb.Split(' ');

            Widgth = Convert.ToInt32(ar[0]);
            Height = Convert.ToInt32(ar[1]);

            DeepTiesStartX = Convert.ToInt32(ar[2]);
            DeepTiesStartY = Convert.ToInt32(ar[3]);

            return this;
        }
    }
}