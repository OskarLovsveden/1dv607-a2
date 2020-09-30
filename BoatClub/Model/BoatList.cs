using System.Collections.Generic;

namespace Model
{
    public class BoatList
    {
        private List<Boat> _boats = new List<Boat>();

        public List<Boat> All
        {
            get => _boats;
        }

        public int Count
        {
            get => _boats.Count;
        }
        private List<Boat> GetBoatList()
        {
            throw new System.NotImplementedException("GetBoatList");
        }

        public void UpdateBoatList()
        {
            throw new System.NotImplementedException("UpdateBoatList");
        }

        public List<Boat> GetMembersBoats(Model.Member member)
        {
            throw new System.NotImplementedException("GetMembersBoats");
        }

        public void Add(Boat boat)
        {
            _boats.Add(boat);
        }

        public override string ToString() => _boats.Count < 1 ? "No boats." : string.Join("\n\n", _boats);
    }
}