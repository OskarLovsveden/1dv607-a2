using System;


namespace Model
{
    public class Boat
    {
        private BoatType _boatType;
        private int _length;
        private string _name;

        public BoatType BoatType
        {
            get => _boatType;
            set
            {
                if (!Enum.IsDefined(typeof(BoatType), (BoatType)value))
                {
                    throw new InvalidOperationException("The provided value is not defined in the enum BoatType");
                }
                _boatType = value;
            }
        }

        public int Length
        {
            get => _length;

            set
            {
                if (value < 1 || value > 20)
                {
                    throw new ArgumentOutOfRangeException("Length has to be between 1-20");
                }
                _length = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 1 || value.Length > 100)
                {
                    throw new ArgumentOutOfRangeException("name has to be between 1-100 characters");
                }
                _name = value;
            }
        }

        public Boat(BoatType boatType, int length, string name)
        {
            BoatType = boatType;
            Length = length;
            Name = name;
        }

        public override string ToString() => $"Name: {Name}\tType: {BoatType}\tLength: {Length}";
    }
}