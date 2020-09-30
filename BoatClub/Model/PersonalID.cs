using System;
using System.Text.RegularExpressions;

namespace Model
{
    public class PersonalID
    {
        private string _pid;

        public string Value
        {
            get => _pid;
            set
            {
                Regex rgx = new Regex(@"^[0-9]{6}[-]{1}[0-9]{4}$");
                if (!rgx.IsMatch(value))
                {
                    throw new ArgumentException("Personal Identification Number must be this format: YYMMDD-XXXX");
                }
                _pid = value;
            }
        }
        public PersonalID(string pid)
        {
            Value = pid;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}