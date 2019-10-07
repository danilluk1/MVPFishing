using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing.BL.Model.Eating
{
    [Serializable]
    public abstract class BaseFood : Item 
    {
        public int Productivity { get; set; }

        public BaseFood(string name, int price, int productivity, Bitmap bit) : base (name, price, bit)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Wrong Name", nameof(name));
            }
            Productivity = productivity;
        }

        public override string ToString()
        {
            return Name;
        }

        public static Bread bread = new Bread();
        public static Cheese cheese = new Cheese();
        public static Caviar caviar = new Caviar();
        public static BlackCaviar blackcaviar = new BlackCaviar();
    }
}
