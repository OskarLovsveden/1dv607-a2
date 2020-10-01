using System.Collections.Generic;

namespace Model
{
    public class BoatList
    {
        private List<Boat> _boats;

        public List<Boat> All
        {
            get => _boats;
        }

        public int Count
        {
            get => _boats.Count;
        }

        public BoatList()
        {
            _boats = new List<Boat>();
        }

        public void Add(Boat boat)
        {
            _boats.Add(boat);
        }

        public void Delete(Boat boat)
        {
            _boats.Remove(boat);
        }

        public override string ToString() => _boats.Count < 1 ? "No boats." : string.Join("\n", _boats);
    }
}