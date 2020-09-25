using System;
using System.Collections.Generic;
using Model.Menu;
using Model;

namespace View
{
    public class Member
    {
        private Model.MemberList _memberList = new Model.MemberList();
        public MenuItems MenuItems { get; set; }

        public Member()
        {
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
                    () => ShowMember(members[copyIndex]),
                    $"{copyIndex + 1}",
                    ViewType.Member
                ));
            }

            MenuItems.Add(new MenuItem("0) Go Back", () => ChooseListType(), "0", ViewType.Member));
        }

        public void ShowMember(Model.Member member)
        {
            MenuItems = new MenuItems($"Member\n{member.Name} - {member.ID}");
        }
    }
}