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
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("message", nameof(name));
            }

            Proad = road;
            Reel = reel;
            FLine = fLine;
            Lure = lure;
            Name = name;
        }     
        public Assembly(string name)
        {
            Name = name;
        }
        public bool IsAssemblyFull()
        {
            if (Proad != null)
            {
                if (Reel != null)
                {
                    if (FLine != null)
                    {
                        if (Lure != null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}