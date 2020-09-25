using System;
using Model.Menu;

namespace View
{
    public class Start
    {

        public MenuItems MenuItems { get; set; }

        public Start()
        {
            MenuItems = new MenuItems("Choose your own adventure");
            MenuItems.Add(new MenuItem("1) Register", () => Console.WriteLine("Register"), "1", ViewType.Register));
            MenuItems.Add(new MenuItem("2) List Members", () => Console.WriteLine("member list"), "2", ViewType.MemberList));
            MenuItems.Add(new MenuItem("0) Exit", () => Console.WriteLine("Exit"), "0", ViewType.Quit));
        }
    }
}