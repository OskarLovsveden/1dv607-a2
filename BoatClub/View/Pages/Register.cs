using System.Text.RegularExpressions;
using Model.Menu;

namespace View.Pages
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
            MenuItems.Add(new MenuItem("0) Go Back", () => { }, "0", ViewType.Member));
        }

        private void Add()
        {
            string name = SetMemberName();
            string PID = SetMemberPid();

            Model.Member newMember = new Model.Member(name, PID);

            _memberList.Add(newMember);
        }

        private string SetMemberName()
        {
            _prompt.SetPromptMessage("Enter members name");
            return _prompt.PromptQuestion(
                    "Name can only contain 1-100 letters",
                    (string name) =>
                    {
                        Regex rgx = new Regex(@"^[a-zA-Z\u00c0-\u017e]{1,100}$");
                        return !rgx.IsMatch(name);
                    }
                );
        }
        private string SetMemberPid()
        {
            _prompt.SetPromptMessage("Enter members Personal ID");
            string PID = _prompt.PromptQuestion(
                    "Valid format: YYMMDD-XXXX",
                    (string pid) =>
                    {
                        Regex rgx = new Regex(@"^[0-9]{6}[-]{1}[0-9]{4}$");
                        return !rgx.IsMatch(pid);
                    }
                );

            return PID;
        }
    }
}