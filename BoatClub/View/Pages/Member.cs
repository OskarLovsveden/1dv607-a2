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
        public MenuCollection MenuCollection { get; set; }

        public Model.Member CurrentMember { get; set; }
        public Member(Model.MemberList memberList)
        {
            _memberList = memberList;
            StartMenu();
        }
        public void StartMenu()
        {
            MenuCollection = new MenuCollection("BoatClub\nWhat would you like to do?");
            MenuCollection.Add(new MenuItem($"{MenuCollection.CurrentActionKey}) Register", () => { }, MenuCollection.CurrentActionKey, ViewType.Register));
            MenuCollection.Add(new MenuItem($"{MenuCollection.CurrentActionKey}) List Members", () => ChooseListType(), MenuCollection.CurrentActionKey, ViewType.Member));
            MenuCollection.AddExitMenuItem(() => { }, ViewType.Quit);
        }
        public void ChooseListType()
        {
            MenuCollection mc = new MenuCollection("Choose type of list:");
            mc.Add(new MenuItem($"{mc.CurrentActionKey}) Verbose", () => ShowMembers("verbose"), mc.CurrentActionKey, ViewType.Member));
            mc.Add(new MenuItem($"{mc.CurrentActionKey}) Compact", () => ShowMembers("compact"), mc.CurrentActionKey, ViewType.Member));
            mc.AddGoBackMenuItem(() => StartMenu(), ViewType.Member);

            MenuCollection = mc;
        }

        public void ShowMembers(string format)
        {
            _memberListFormat = format;
            IReadOnlyList<Model.Member> members = _memberList.All;

            MenuCollection mc = new MenuCollection("\n\nSelect member to manage by entering the corresponding number.\n\n");

            for (int i = 0; i < members.Count; i++)
            {
                int copyIndex = i;
                mc.Add(new MenuItem(
                    $"{mc.CurrentActionKey}){MemberToString(members[copyIndex], _memberListFormat)}",
                    () => ManageMember(members[copyIndex]),
                    mc.CurrentActionKey,
                    ViewType.Member
                ));
            }

            mc.AddGoBackMenuItem(() => ChooseListType(), ViewType.Member);

            MenuCollection = mc;
        }

        private void ManageMember(Model.Member member)
        {
            MenuCollection mc = new MenuCollection($"Member\n{member.Name} - {member.ID}");

            mc.Add(new MenuItem($"{mc.CurrentActionKey}) Show member info", () => ShowMember(member), mc.CurrentActionKey, ViewType.Member));
            mc.Add(new MenuItem($"{mc.CurrentActionKey}) Change info", () => UpdateMemberMenu(member), mc.CurrentActionKey, ViewType.Member));
            mc.Add(new MenuItem($"{mc.CurrentActionKey}) Manage boats", () => CurrentMember = member, mc.CurrentActionKey, ViewType.Boat));
            mc.Add(new MenuItem($"{mc.CurrentActionKey}) Delete member", () => DeleteMember(member), mc.CurrentActionKey, ViewType.Member));

            mc.AddGoBackMenuItem(() => ShowMembers(_memberListFormat), ViewType.Member);

            MenuCollection = mc;
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
            MenuCollection mc = new MenuCollection($"Change member info\n{member.Name} - {member.ID}");

            mc.Add(new MenuItem($"{mc.CurrentActionKey}) Name: ({member.Name})", () => UpdateName(member), mc.CurrentActionKey, ViewType.Member));
            mc.Add(new MenuItem($"{mc.CurrentActionKey}) PID: ({member.PID})", () => UpdatePID(member), mc.CurrentActionKey, ViewType.Member));
            mc.AddGoBackMenuItem(() => ManageMember(member), ViewType.Member);

            MenuCollection = mc;
        }


        private void UpdateName(Model.Member member)
        {

            _prompt.SetPromptMessage("Enter name", member.Name);
            member.Name = _prompt.PromptQuestion(
                    $"Name can only contain {member.MinNameLength}-{member.MaxNameLength} letters and no blank spaces",
                    (string name) =>
                    {
                        Regex rgx = new Regex(member.ValidNameFormat);
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
                        Regex rgx = new Regex(member.ValidPIDFormat);
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