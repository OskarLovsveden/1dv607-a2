using System.Collections.Generic;

namespace Model
{
    public class BoatList
    {
        private List<Boat> _boats = new List<Boat>();

        public IReadOnlyList<Boat> All
        {
            get => _boats.AsReadOnly();
        }

        public int Count
        {
            get => _boats.Count;
        }

        public void Add(Boat boat)
        {
            _boats.Add(boat);
        }

        public void Delete(Boat boat)
        {
            _boats.Remove(boat);
        }

        public override string ToString() => _boats.Count < 1 ? "No boats." : string.Join("\n\n", _boats);
    }
}