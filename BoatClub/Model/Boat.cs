namespace Model
{
    public class Boat
    {
        private BoatType _boatType;
        private int _length;
        private string _name;
        private int _id;

        public BoatType BoatType
        {
            get => _boatType;
            set => _boatType = value;
        }

        public int Length
        {
            get => _length;
            set => _length = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int ID
        {
            get => _id;
            set => _id = value;
        }
        public string Owner { get; set; }
        public Boat(BoatType boatType, int length, string name, string owner)
        {
            BoatType = boatType;
            Length = length;
            Name = name;
            ID = owner.GetHashCode();
            Owner = owner;
        }

        // public override string ToString() => $"Boat ID: {ID}\nBoat Name: {Name}\nBoat Type: {BoatType}\n" +
        //                                      $"Boat Length: {Length}";
        public override string ToString() => $"ID: {ID}\tName: {Name}\tType: {BoatType}\tLength: {Length}";
    }
}