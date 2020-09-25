using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Model
{
    public class BoatList
    {
        private List<Boat> _boats;
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
            using (StreamReader r = new StreamReader(_registryPath))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Boat>>(json);
            }
        }

        // public List<string> GetVerboseList()
        // {
        //     List<Boat> boats = GetBoatList();
        //     List<string> verboseMembers = new List<string>();
        //     foreach (Boat boat in boats)
        //     {
        //         verboseMembers.Add(boats.ToString());
        //     }

        //     return verboseMembers;
        // }
        private void WriteListToRegistry(List<Boat> boats)
        {
            var j = JsonConvert.SerializeObject(boats, Formatting.Indented);
            File.WriteAllText(_registryPath, j);
        }
        public void Add(Boat boat) 
        {
            _boats.Add(boat);
        }

        public override string ToString() => string.Join("\n", _boats);
    }
}