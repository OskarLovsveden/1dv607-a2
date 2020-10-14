using System.Collections.Generic;
using Model.Menu;
using System.Text.RegularExpressions;

namespace View.Pages
{
    public class Member
    {
        private string _memberListFormat;
        private View.Prompt _prompt = new View.Prompt();
        private Model.MemberList _memberList;
        public MenuItems MenuItems { get; set; }

        public Model.Member CurrentMember { get; set; }
        public Member(Model.MemberList memberList)
        {
            _memberList = memberList;
            StartMenu();
        }
        public void StartMenu()
        {
            MenuItems = new MenuItems("BoatClub\nWhat would you like to do?");
            MenuItems.Add(new MenuItem("1) Register", () => { }, "1", ViewType.Register));
            MenuItems.Add(new MenuItem("2) List Members", () => ChooseListType(), "2", ViewType.Member));
            MenuItems.Add(new MenuItem("0) Exit", () => { }, "0", ViewType.Quit));
        }
        public void ChooseListType()
        {
            MenuItems = new MenuItems("Choose type of list:");
            MenuItems.Add(new MenuItem("1) Verbose", () => ShowMembers("verbose"), "1", ViewType.Member));
            MenuItems.Add(new MenuItem("2) Compact", () => ShowMembers("compact"), "2", ViewType.Member));
            MenuItems.Add(new MenuItem("0) Go Back", () => StartMenu(), "0", ViewType.Member));
        }

        public void ShowMembers(string format)
        {
            _memberListFormat = format;
            IReadOnlyList<Model.Member> members = _memberList.All;
            MenuItems = new MenuItems("\n\nSelect member to manage by entering the corresponding number.\n\n");
            for (int i = 0; i < members.Count; i++)
            {
                int copyIndex = i;
                MenuItems.Add(new MenuItem(
                    $"{copyIndex + 1}){MemberToString(members[copyIndex], _memberListFormat)}",
                    () => ManageMember(members[copyIndex]),
                    $"{copyIndex + 1}",
                    ViewType.Member
                ));
            }

            MenuItems.Add(new MenuItem("0) Go Back", () => ChooseListType(), "0", ViewType.Member));
        }

        private void ManageMember(Model.Member member)
        {
            MenuItems = new MenuItems($"Member\n{member.Name} - {member.ID}");

            MenuItems.Add(new MenuItem("1) Show member info", () => ShowMember(member), "1", ViewType.Member));
            MenuItems.Add(new MenuItem("2) Change info", () => UpdateMemberMenu(member), "2", ViewType.Member));
            MenuItems.Add(new MenuItem("3) Manage boats", () => CurrentMember = member, "3", ViewType.Boat));
            MenuItems.Add(new MenuItem("4) Delete member", () => DeleteMember(member), "4", ViewType.Member));
            MenuItems.Add(new MenuItem("0) Go back", () => ShowMembers(_memberListFormat), "0", ViewType.Member));
        }

        private void ShowMember(Model.Member member)
        {
            _prompt.PromptShowTilClick(VerboseMember(member));
        }

        private void DeleteMember(Model.Member member)
        {
            _memberList.Delete(member);
            ShowMembers(_memberListFormat);
        }

        private void UpdateMemberMenu(Model.Member member)
        {
            MenuItems = new MenuItems($"Change member info\n{member.Name} - {member.ID}");

            MenuItems.Add(new MenuItem($"1) Name: ({member.Name})", () => UpdateName(member), "1", ViewType.Member));
            MenuItems.Add(new MenuItem($"2) PID: ({member.PID})", () => UpdatePID(member), "2", ViewType.Member));
            MenuItems.Add(new MenuItem("0) Go back", () => ManageMember(member), "0", ViewType.Member));
        }


        private void UpdateName(Model.Member member)
        {

            _prompt.SetPromptMessage("Enter name", member.Name);
            member.Name = _prompt.PromptQuestion(
                    "Name can only contain 1-100 letters",
                    (string name) =>
                    {
                        Regex rgx = new Regex(@"^[a-zA-Z\u00c0-\u017e]{1,100}$");
                        return !rgx.IsMatch(name);
                    }
                );

            _memberList.UpdateMemberList();
            UpdateMemberMenu(member);
        }
        private void UpdatePID(Model.Member member)
        {
            _prompt.SetPromptMessage("Enter PID", member.PID.ToString());
            member.PID = _prompt.PromptQuestion(
                    "Valid format: YYMMDD-XXXX",
                    (string pid) =>
                    {
                        Regex rgx = new Regex(@"^[0-9]{6}[-]{1}[0-9]{4}$");
                        return !rgx.IsMatch(pid);
                    }
                );

            _memberList.UpdateMemberList();
            UpdateMemberMenu(member);
        }
        private string MemberToString(Model.Member member, string format)
        {
            switch (format)
            {
                case "verbose":
                    return VerboseMember(member);
                default:
                    return CompactMember(member);
            }

        }


        private string VerboseMember(Model.Member member)
        {
            return $"\nName: {member.Name}\nPersonal Identification Number: {member.PID}\nMember ID: {member.ID}\nBoats:\n{BoatListToString(member)}\n";

        }

        private string CompactMember(Model.Member member)
        {
            return $" Name: {member.Name}\tMember ID: {member.ID}\tNumber of boats: {member.BoatCount}";
        }
        private string BoatListToString(Model.Member member)
        {
            string boats = "";

            if (member.BoatCount == 0) return "Member has no boats yet";

            foreach (Model.Boat boat in member.BoatList)
            {
                boats += $"Name: {boat.Name}, Type: {boat.BoatType}, Length: {boat.Length}\n";
            }

            return boats;
        }
    }
}