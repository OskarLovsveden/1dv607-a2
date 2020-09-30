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
            string id = "ID";
            Model.PersonalID pid = SetMemberPid();

            Model.Member newMember = new Model.Member(name, id, pid);

            _memberList.Add(newMember);
        }

        private string SetMemberName()
        {
            System.Console.WriteLine("Enter members name");
            string name;
            do
            {
                name = Console.ReadLine();
            } while (name.Any(c => !char.IsLetter(c)));

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