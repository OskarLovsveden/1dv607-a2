using System.Collections.Generic;

namespace Model
{
    public class BoatList
    {
        private List<Boat> _boats;

        public int Count
        {
            get => _boats.Count;
        }

        public void add(Boat boat) 
        {
            _boats.Add(boat);
        }

        public override string ToString() => string.Join("\n", _boats);
    }
}