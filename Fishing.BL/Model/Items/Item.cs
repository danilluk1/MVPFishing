using Fishing.BL.Model.Baits;
using Fishing.BL.Model.Hooks;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Fishing {

    [Serializable]
    public abstract class Item {
        public static BindingList<Road> Roads = new BindingList<Road>();
        public static BindingList<Reel> Reels = new BindingList<Reel>();
        public static BindingList<FLine> FLines = new BindingList<FLine>();
        public static BindingList<Lure> Lures = new BindingList<Lure>();
        public static BindingList<Bait> Baits = new BindingList<Bait>();
        public static BindingList<BaseHook> Hooks = new BindingList<BaseHook>();
        public string Name { get; }
        public int Price { get; }
        public Bitmap Pict { get; }

        public Item(string name, int price, Bitmap pict) {
            Name = name;
            Price = price;
            Pict = pict;
        }

        public void selectAndAddItemToInv(int i) {
            if (this is Road) {
                Road r = Roads[i];
                Player.GetPlayer().RoadInv.Add(r);
            }
            if (this is Reel) {
                Reel r = Reels[i];
                Player.GetPlayer().ReelInv.Add(r);
            }
            if (this is FLine) {
                FLine r = FLines[i];
                Player.GetPlayer().FLineInv.Add(r);
            }
        }

        public static Item SelectItemType(Item item) {
            if (item is Road) {
                return (Road)item;
            }
            if (item is Reel) {
                return (Reel)item;
            }
            if (item is FLine) {
                return (FLine)item;
            }
            return item;
        }
    }
}