﻿using System.Drawing;
using Fishing.BL.Resources.Images;

namespace Fishing.BL.Model.Game
{
    public class Netting
    {
        public Image Image { get; set; } = Images.podsak1;
        public int X { get; set; }
        public int Y { get; set; }
        public void HideNetting()
        {
            Y = 800;
        }

        public void ShowNetting()
        {
            Y = 550;
            X = Player.GetPlayer().RoadX;
        }
    }
}
