using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Model
{
    public class Member
    {
        private string _name;
        private ID _ID;

        public string Name
        {
            get => _name;
            set
            {
                Regex rgx = new Regex("^[a-zA-Z]{1,100}$");

                if (value.Any(c => !char.IsLetter(c)))
                {
                    throw new ArgumentException("A members name can only contain characters.");
                }
                if (!rgx.IsMatch(value))
                {
                    throw new ArgumentOutOfRangeException("A members name must be between 1-100 characters.");
                }
                _name = value;
            }
        }
        public string ID
        {
            get => _ID.Value;
        }
        public PersonalID PID { get; set; }
        public BoatList BoatList { get; private set; }
        public int BoatCount { get => BoatList.Count; }
        public Member(string name, PersonalID pid)
        {
            Name = name;
            PID = pid;
            _ID = new ID();
            BoatList = new BoatList();
        }

        public string ToString(string format)
        {
            switch (format)
            {
                // “Verbose List”; name, personal number, member id and boats with boat information
                case "verbose":
                    return $"Name: {Name}\nPersonal Identification Number: {PID}\nMember ID: {ID}\nBoats:\n{BoatList}";
                // “Compact List”; name, member id and number of boats
                case "compact":
                    return $"Name: {Name}\nMember ID: {ID}\nNumber of boats: {BoatCount}";
                case null:
                case "":
                    throw new FormatException("Could not format the text representation.");
                default:
                    throw new FormatException("Could not format the text representation.");
            }
        }

        public override string ToString() => ToString("verbose");
    }
}
