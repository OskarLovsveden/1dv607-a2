namespace Model
{
    public class Boat
    {
        private BoatType _boatType;
        private int _length;
        private string _name;
        private string _id;

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
        public string ID 
        {
            get => _id;
            set => _id = value;
        }
        public Boat(BoatType boatType, int length, string name, string id)
        {
            BoatType = boatType;
            Length = length;
            Name = name;
            ID = id;
        }

        public override string ToString() => $"Boat ID: {ID}\nBoat Name: {Name}\nBoat Type: {BoatType}\n" +
                                             $"Boat Length: {Length}";
    }
}