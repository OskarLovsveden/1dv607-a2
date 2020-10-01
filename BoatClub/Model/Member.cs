using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Model
{
    public class Member
    {
        private string _name;
        private ID _ID;
        private string _PID;

        public string Name
        {
            get => _name;
            set
            {
                Regex rgx = new Regex(@"^[a-zA-Z\u00c0-\u017e]{1,100}$");

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

        public string PID
        {
            get => _PID;
            set
            {
                Regex rgx = new Regex(@"^[0-9]{6}[-]{1}[0-9]{4}$");
                if (!rgx.IsMatch(value))
                {
                    throw new ArgumentException("Personal Identification Number must be this format: YYMMDD-XXXX");
                }
                _PID = value;
            }
        }

        public List<Boat> BoatList { get; private set; }

        public int BoatCount { get => BoatList.Count; }
        public Member(string name, string pid)
        {
            Name = name;
            PID = pid;
            _ID = new ID();
            BoatList = new List<Boat>();
        }

        public string BoatListToString()
        {
            return string.Join("\n", BoatList);
        }

        public string ToString(string format)
        {
            switch (format)
            {
                // “Verbose List”; name, personal number, member id and boats with boat information
                case "verbose":
                    return $"\nName: {Name}\nPersonal Identification Number: {PID}\nMember ID: {ID}\nBoats:\n{BoatListToString()}\n";
                // “Compact List”; name, member id and number of boats
                case "compact":
                    return $" Name: {Name}\tMember ID: {ID}\tNumber of boats: {BoatCount}";
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
