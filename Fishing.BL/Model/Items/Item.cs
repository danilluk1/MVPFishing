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

        protected Item(string name, int price, Bitmap pict) {
            Name = name;
            Price = price;
            Pict = pict;
        }

        public static Item SelectItemType(Item item) {
            switch (item)
            {
                case Road road:
                    return road;
                case Reel reel:
                    return reel;
                case FLine line:
                    return line;
                default:
                    return item;
            }
        }
    }
}