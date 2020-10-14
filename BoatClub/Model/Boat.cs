using System;


namespace Model
{
    public class Boat
    {
        private BoatType _boatType;
        private int _length;
        private string _name;
        private readonly int _minBoatLength = 1;
        private readonly int _maxBoatLength = 20;
        private readonly int _minBoatNameLength = 1;
        private readonly int _maxBoatNameLength = 40;

        public int MinBoatLength { get => _minBoatLength; }
        public int MaxBoatLength { get => _maxBoatLength; }
        public int MinBoatNameLength { get => _minBoatNameLength; }
        public int MaxBoatNameLength { get => _maxBoatNameLength; }

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
                if (value < _minBoatLength || value > _maxBoatLength)
                {
                    throw new ArgumentOutOfRangeException($"Length has to be between {_minBoatLength}-{_maxBoatLength}");
                }
                _length = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < _minBoatNameLength || value.Length > _maxBoatNameLength)
                {
                    throw new ArgumentOutOfRangeException($"name has to be between {_minBoatNameLength}-{_maxBoatNameLength} characters");
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
    }
}