using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Model
{
    public class BoatList
    {
        private Model.DAL.Registry _registry = new Model.DAL.Registry();
        private readonly byte FILE_MIN_LENGTH = 2;
        private List<Boat> _boats = new List<Boat>();
        private string _registryPath = "Registry/BoatRegistry/BoatRegistry.json";

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
            _boats = GetBoatList();

        }
        private List<Boat> GetBoatList()
        {
            return _registry.ReadListFromRegistry<Model.Boat>(_registryPath); 
        }
      
        public void WriteListToRegistry()
        {
            _registry.WriteListToRegistry<Boat>(_boats, _registryPath);
        }

        public List<Boat> GetMembersBoats(Model.Member member)
        {
            return _boats.FindAll(boat => boat.Owner == member);
        }
        public void Add(Boat boat) 
        {
            _boats.Add(boat);
        }

        public override string ToString() => _boats.Count < 1 ? "No boats." : string.Join("\n", _boats);
    }
}