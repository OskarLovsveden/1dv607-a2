using System;

namespace Model
{
    public class Member
    {
        private string _name;
        private string _ID;
        private PersonalID _PID;
        private BoatList _boatList = new BoatList();

        public Member(string name, string id, PersonalID pid)
        {
            Name = name;
            ID = id;
            PID = pid;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string ID
        {
            get => _ID;
            set => _ID = value;
        }
        public PersonalID PID
        {
            get => _PID;
            set => _PID = value;
        }
        public BoatList BoatList
        {
            get => _boatList;
            set => _boatList = value;
        }
        public int BoatCount { get => BoatList.Count; }

        public string ToString(string format)
        {
            switch (format)
            {
                // “Verbose List”; name, personal number, member id and boats with boat information
                case "Verbose":
                    return $"Name: {Name}\nPersonal Identification Number: {PID}\nMember ID: {ID}\nBoats:\n{BoatList.ToString()}";
                // “Compact List”; name, member id and number of boats
                case "Compact":
                    return $"Name: {Name}\nMember ID: {ID}\nNumber of boats: {BoatCount}";
                case null:
                case "":
                    throw new FormatException("Could not format the text representation.");
                default:
                    throw new FormatException("Could not format the text representation.");
            }
        }

        public override string ToString() => ToString("Verbose");
    }
}
