namespace Model
{
    public class PersonalID
    {
        private string _pid;

        public string Pid
        {
            get => _pid;
            set => _pid = value; // TODO: implement validation for format yymmdd-xxx
        }
        public PersonalID(string pid)
        {
            Pid = pid;
        }

        public override string ToString()
        {
            return Pid;
        }
    }
}