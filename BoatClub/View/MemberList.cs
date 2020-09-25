using System;
using System.Collections.Generic;
using Model.Menu;

namespace View
{
    public class MemberList
    {

        public MenuItems MenuItems { get; set; }

        public MemberList()
        {
            ChooseListType();
        }

        public void ChooseListType()
        {
            MenuItems = new MenuItems("Choose type of list:");
            MenuItems.Add(new MenuItem("1) Verbose", () => ShowMembersVerbose(), "1", ViewType.MemberList));
            MenuItems.Add(new MenuItem("2) Compact", () => ShowMembersCompact(), "2", ViewType.MemberList));
            MenuItems.Add(new MenuItem("0) Go Back", () => { }, "0", ViewType.Start));
        }

        public void ShowMembersVerbose()
        {
            List<string> members = new List<string>() {
                "Verbose1",
                "Verbose2",
                "Verbose3",
                "Verbose4",
                "Verbose5"
            };

            MenuItems = new MenuItems("Members:");
            for (int i = 0; i < members.Count; i++)
            {
                int copyIndex = i;
                MenuItems.Add(new MenuItem(members[copyIndex], () => Console.WriteLine(members[copyIndex]), $"{copyIndex + 1}", ViewType.Member));
            }

            MenuItems.Add(new MenuItem("0) Go Back", () => ChooseListType(), "0", ViewType.MemberList));
        }

        public void ShowMembersCompact()
        {
            List<string> members = new List<string>() {
                "Compact1",
                "Compact2",
                "Compact3",
                "Compact4",
                "Compact5"
            };

            MenuItems = new MenuItems("Members:");
            for (int i = 0; i < members.Count; i++)
            {
                int copyIndex = i;
                MenuItems.Add(new MenuItem(members[copyIndex], () => Console.WriteLine(members[copyIndex]), $"{copyIndex + 1}", ViewType.Member));
            }

            MenuItems.Add(new MenuItem("0) Go Back", () => ChooseListType(), "0", ViewType.MemberList));
        }
    }
}