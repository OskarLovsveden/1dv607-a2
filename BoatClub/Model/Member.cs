namespace Model
{
    class Member
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
    }
}
