using System.Text.RegularExpressions;
using Model.Menu;

namespace View.Pages
{
    public class Register
    {
        private Model.MemberList _memberList;
        private View.Prompt _prompt = new View.Prompt();
        public MenuCollection MenuCollection { get; set; }
        public Register(Model.MemberList memberList)
        {
            _memberList = memberList;
            SetMainMenu();
        }

        public void SetMainMenu()
        {
            MenuCollection mc = new MenuCollection("Register");

            mc.Add(new MenuItem($"{mc.CurrentActionKey}) New Member", () => Add(), mc.CurrentActionKey, ViewType.Register));
            mc.AddGoBackMenuItem(() => { }, ViewType.Member);

            MenuCollection = mc;
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
                    // TODO Remove string dependency
                    "Name can only contain 1-40 letters",
                    (string name) =>
                    {
                        // TODO Remove string dependency
                        Regex rgx = new Regex(@"^[a-zA-Z\u00c0-\u017e]{1,40}$");
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
                        // TODO Remove string dependency
                        Regex rgx = new Regex(@"^[0-9]{6}[-]{1}[0-9]{4}$");
                        return !rgx.IsMatch(pid);
                    }
                );

            return PID;
        }
    }
}