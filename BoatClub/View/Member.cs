using System;
using System.Collections.Generic;
using Model.Menu;
using Model;
using System.Linq;
using System.Text.RegularExpressions;

namespace View
{
    public class Member
    {
        private Model.MemberList _memberList;
        public MenuItems MenuItems { get; set; }
        public Model.Member CurrentMember { get; set; }
        public Member(Model.MemberList memberList)
        {
            _memberList = memberList;
            ChooseListType();
        }

        public void ChooseListType()
        {
            MenuItems = new MenuItems("Choose type of list:");
            MenuItems.Add(new MenuItem("1) Verbose", () => ShowMembers("verbose"), "1", ViewType.Member));
            MenuItems.Add(new MenuItem("2) Compact", () => ShowMembers("compact"), "2", ViewType.Member));
            MenuItems.Add(new MenuItem("0) Go Back", () => { }, "0", ViewType.Start));
        }

        public void ShowMembers(string format)
        {

            List<Model.Member> members = _memberList.All;
            MenuItems = new MenuItems("Members:");
            for (int i = 0; i < members.Count; i++)
            {
                int copyIndex = i;
                MenuItems.Add(new MenuItem(
                    $"{copyIndex + 1})\n{members[copyIndex].ToString(format)}",
                    () => ShowMember(members[copyIndex], format),
                    $"{copyIndex + 1}",
                    ViewType.Member
                ));
            }

            MenuItems.Add(new MenuItem("0) Go Back", () => ChooseListType(), "0", ViewType.Member));
        }

        private void ShowMember(Model.Member member, string format)
        {
            MenuItems = new MenuItems($"Member\n{member.Name} - {member.ID}");

            MenuItems.Add(new MenuItem("1) Change info", () => UpdateUser(member, format), "1", ViewType.Member));
            MenuItems.Add(new MenuItem("2) Manage boats", () => CurrentMember = member, "2", ViewType.Boat));
            MenuItems.Add(new MenuItem("3) Delete member", () => _memberList.Delete(member), "3", ViewType.Member));
            MenuItems.Add(new MenuItem("0) Go back", () => ShowMembers(format), "0", ViewType.Member));
        }

        private void UpdateUser(Model.Member member, string format)
        {
            MenuItems = new MenuItems($"Change member info\n{member.Name} - {member.ID}");

            MenuItems.Add(new MenuItem($"1) Name: ({member.Name})", () => UpdateName(member, format), "1", ViewType.Member));
            MenuItems.Add(new MenuItem($"2) PID: ({member.PID})", () => UpdatePID(member, format), "2", ViewType.Member));
            MenuItems.Add(new MenuItem("0) Go back", () => ShowMember(member, format), "0", ViewType.Member));
        }


        private void UpdateName(Model.Member member, string format)
        {
            SetPromptMessage("Enter name", member.Name);
            string name;
            do
            {
                name = Console.ReadLine();
            } while (name.Any(c => !char.IsLetter(c)));

            member.Name = name;
            _memberList.UpdateMemberList();

            UpdateUser(member, format);
        }
        private void UpdatePID(Model.Member member, string format)
        {
            SetPromptMessage("Enter PID", member.PID.ToString());
            Regex rgx = new Regex(@"^[0-9]{6}[-]{1}[0-9]{4}$");
            string PID;
            do
            {
                Console.WriteLine("\nValid format: YYMMDD-XXXX");
                PID = Console.ReadLine();

            } while (!rgx.IsMatch(PID));

            member.PID = new PersonalID(PID);

            _memberList.UpdateMemberList();
            UpdateUser(member, format);
        }

        private void SetPromptMessage(string promptTitle, string currentPropertyValue)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(promptTitle);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($" ({currentPropertyValue})");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(": ");
            Console.ResetColor();
        }
    }
}