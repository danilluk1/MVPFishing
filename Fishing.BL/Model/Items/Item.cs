using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Fishing
{
    [Serializable]
    public abstract class Item
    {
        public static BindingList<Road> RoadShop = new BindingList<Road>();
        public static BindingList<Reel> ReelShop = new BindingList<Reel>();
        public static BindingList<FLine> LeskaShop = new BindingList<FLine>();
        public static BindingList<Lure> LureShop = new BindingList<Lure>();
        public string Name;
        public int Price;
        public Bitmap Pict;

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

        public static Item selectItemType(Item item)
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
