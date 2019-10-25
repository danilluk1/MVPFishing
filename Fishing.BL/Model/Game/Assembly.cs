using System;

namespace Fishing
{
    [Serializable]
    public class Assembly
    {
        public Road Proad { get; set; }
        public Reel Reel { get; set; }
        public FLine FLine { get; set; }
        public Lure Lure { get; set; }
        public string Name { get; set; }

        public Assembly(string name, Road road, Reel reel, FLine fLine, Lure lure)
        {
            Proad = road;
            Reel = reel;
            FLine = fLine;
            Lure = lure;
            Name = name;
        }

        public Assembly(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}