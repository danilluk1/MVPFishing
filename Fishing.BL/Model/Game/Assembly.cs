using Fishing.BL.Model.Baits;
using System;

namespace Fishing
{
    [Serializable]
    public class Assembly
    {
        public Road Road { get; set; }
        public Reel Reel { get; set; }
        public FLine FLine { get; set; }
        public FishBait FishBait { get; set; }
        public string Name { get; set; }

        public bool IsEquiped;

        public Assembly(string name, Road road, Reel reel, FLine fLine, FishBait fb)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("message", nameof(name));
            }

            Road = road;
            Reel = reel;
            FLine = fLine;
            FishBait = fb;
            Name = name;
        }     
        public Assembly(string name)
        {
            Name = name;
        }
        public bool IsAssemblyFull()
        {
            if (Road != null)
            {
                if (Reel != null)
                {
                    if (FLine != null)
                    {
                        if (FishBait != null)
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