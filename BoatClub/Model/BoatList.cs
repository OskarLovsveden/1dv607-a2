using System.Collections.Generic;

namespace Model
{
    public class BoatList
    {
        private List<Boat> _boats = new List<Boat>();

        public int Count
        {
            get => _boats.Count;
        }

        public void Add(Boat boat) 
        {
            _boats.Add(boat);
        }

        public override string ToString() => string.Join("\n", _boats);
    }
}