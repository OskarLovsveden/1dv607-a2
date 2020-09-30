using System;
using System.Collections.Generic;
using Model.Menu;
using Model;
using System.Text.RegularExpressions;

namespace View
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
            _memberListFormat = format;
            IReadOnlyList<Model.Member> members = _memberList.All;
            MenuItems = new MenuItems("Members:");
            for (int i = 0; i < members.Count; i++)
            {
                int copyIndex = i;
                MenuItems.Add(new MenuItem(
                    $"{copyIndex + 1})\n{members[copyIndex].ToString(_memberListFormat)}",
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
            Console.Clear();
            System.Console.WriteLine(member);
            System.Console.WriteLine("Press any key to go back");
            Console.ReadKey();
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

            string name;
            _prompt.SetPromptMessage("Enter name", member.Name);
            Regex rgx = new Regex("^[a-zA-Z]{1,100}$");

            do
            {
                System.Console.WriteLine("Name can only contain 1-100 letters");
                name = Console.ReadLine();
            } while (!rgx.IsMatch(name));
            // !(minNumber > numberValue && maxNumber < numberValue)

            member.Name = name;
            _memberList.UpdateMemberList();

            UpdateMemberMenu(member);
        }
        private void UpdatePID(Model.Member member)
        {
            _prompt.SetPromptMessage("Enter PID", member.PID.ToString());
            Regex rgx = new Regex(@"^[0-9]{6}[-]{1}[0-9]{4}$");
            string PID;
            do
            {
                Console.WriteLine("\nValid format: YYMMDD-XXXX");
                PID = Console.ReadLine();

            } while (!rgx.IsMatch(PID));

            member.PID = new PersonalID(PID);

            _memberList.UpdateMemberList();
            UpdateMemberMenu(member);
        }

        // private void SetPromptMessage(string promptTitle, string currentPropertyValue)
        // {
        //     Console.Clear();
        //     Console.ForegroundColor = ConsoleColor.Yellow;
        //     Console.Write(promptTitle);
        //     Console.ForegroundColor = ConsoleColor.Green;
        //     Console.Write($" ({currentPropertyValue})");
        //     Console.ForegroundColor = ConsoleColor.Yellow;
        //     Console.Write(": ");
        //     Console.ResetColor();
        // }
    }
}