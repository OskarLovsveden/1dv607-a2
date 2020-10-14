using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Model
{
    public class Member
    {
        private List<Boat> _boatList;
        private string _name;
        private ID _ID;
        private string _PID;
        private static int _minNameLength = 1;
        private static int _maxNameLength = 40;
        private readonly string _validNameFormat = @"^[a-zA-Z\u00c0-\u017e]{" + _minNameLength + "," + _maxNameLength + "}$";
        private readonly string _validPIDFormat = @"^[0-9]{6}[-]{1}[0-9]{4}$";

        public int MinNameLength { get => _minNameLength; }
        public int MaxNameLength { get => _maxNameLength; }
        public string ValidNameFormat { get => _validNameFormat; }
        public string ValidPIDFormat { get => _validPIDFormat; }
        public string Name
        {
            get => _name;
            set
            {
                Regex rgx = new Regex(_validNameFormat);

                if (value.Any(c => !char.IsLetter(c)))
                {
                    throw new ArgumentException("A members name can only contain characters and no blank spaces.");
                }
                if (!rgx.IsMatch(value))
                {
                    throw new ArgumentOutOfRangeException($"A members name must be between {_minNameLength}-{_maxNameLength} characters.");
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
                Regex rgx = new Regex(_validPIDFormat);
                if (!rgx.IsMatch(value))
                {
                    throw new ArgumentException("Personal Identification Number must be this format: YYMMDD-XXXX");
                }
                _PID = value;
            }
        }
        public List<Boat> BoatList { get => _boatList; }
        public int BoatCount { get => BoatList.Count; }

        public Member(string name, string pid)
        {
            Name = name;
            PID = pid;
            _ID = new ID();
            _boatList = new List<Boat>();
        }

    }
}
