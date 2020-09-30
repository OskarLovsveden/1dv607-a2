using System;
using System.Linq;
using System.Text.RegularExpressions;
using Model.Menu;

namespace View
{
    public class Register
    {
        private Model.MemberList _memberList;

        public MenuItems MenuItems { get; set; }
        public Register(Model.MemberList memberList)
        {
            _memberList = memberList;
            SetMainMenu();
        }

        public void SetMainMenu()
        {
            MenuItems = new MenuItems("Register");
            MenuItems.Add(new MenuItem("1) New Member", () => Add(), "1", ViewType.Register));
            MenuItems.Add(new MenuItem("0) Go Back", () => { }, "0", ViewType.Start));
        }

        private void Add()
        {
            string name = SetMemberName();
            Model.PersonalID pid = SetMemberPid();

            Model.Member newMember = new Model.Member(name, pid);

            _memberList.Add(newMember);
        }

        private string SetMemberName()
        {
            System.Console.WriteLine("Enter members name");
            Regex rgx = new Regex("^[a-zA-Z]{1,100}$");
            string name;

            do
            {
                System.Console.WriteLine("Name can only contain 1-100 letters");
                name = Console.ReadLine();
            } while (!rgx.IsMatch(name));

            return name;
        }
        private Model.PersonalID SetMemberPid()
        {
            System.Console.WriteLine("Enter members Personal ID");
            Regex rgx = new Regex(@"^[0-9]{6}[-]{1}[0-9]{4}$");
            string PID;
            do
            {
                Console.WriteLine("\nValid format: YYMMDD-XXXX");
                PID = Console.ReadLine();

            } while (!rgx.IsMatch(PID));

            return new Model.PersonalID(PID);
        }
    }
}