using System;
using System.Linq;
using System.Text.RegularExpressions;
using Model.Menu;

namespace View
{
    public class Register
    {
        private Model.MemberList _memberList;
        private View.Prompt _prompt = new View.Prompt();

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
            return _prompt.PromptQuestion(
                    "Enter members name",
                    "Name can only contain 1-100 letters",
                    (string name) =>
                    {
                        Regex rgx = new Regex("^[a-zA-Z]{1,100}$");
                        return !rgx.IsMatch(name);
                    }
                );
        }
        private Model.PersonalID SetMemberPid()
        {
            string PID = _prompt.PromptQuestion(
                    "Enter members Personal ID",
                    "Valid format: YYMMDD-XXXX",
                    (string pid) =>
                    {
                        Regex rgx = new Regex(@"^[0-9]{6}[-]{1}[0-9]{4}$");
                        return !rgx.IsMatch(pid);
                    }
                );

            return new Model.PersonalID(PID);
        }
    }
}