using System;
using System.ComponentModel;
using System.Drawing;

namespace Fishing
{
    [Serializable]
    public abstract class Item
    {
        public static BindingList<Road> RoadShop = new BindingList<Road>();
        public static BindingList<Reel> ReelShop = new BindingList<Reel>();
        public static BindingList<FLine> LeskaShop = new BindingList<FLine>();
        public static BindingList<Lure> LureShop = new BindingList<Lure>();
        public string Name { get; }
        public int Price { get; }
        public Bitmap Pict { get; }

        public Item(string name, int price, Bitmap pict)
        {
            Name = name;
            Price = price;
            Pict = pict;
        }

        public void selectAndAddItemToInv(int i)
        {
            if (this is Road)
            {
                Road r = RoadShop[i];
                Player.GetPlayer().RoadInv.Add(r);
            }
            if (this is Reel)
            {
                Reel r = ReelShop[i];
                Player.GetPlayer().ReelInv.Add(r);
            }
            if (this is FLine)
            {
                FLine r = LeskaShop[i];
                Player.GetPlayer().FLineInv.Add(r);
            }
        }

        public static Item SelectItemType(Item item)
        {
            if (item is Road)
            {
                return (Road)item;
            }
            if (item is Reel)
            {
                return (Reel)item;
            }
            if (item is FLine)
            {
                return (FLine)item;
            }
            return item;
        }
    }
}