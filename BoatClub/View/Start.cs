using System;
using Model;
using Newtonsoft.Json;
using System.IO;

namespace View
{
    public class Start
    {
        public ViewType NextView { get; set; }
        public Start()
        {
            NextView = ViewType.Start;
        }

        private void ShowMenu()
        {
            bool show = true;

            while (show)
            {
                PrintMenuMessgae();
                show = GetMenuChoice();
            }

        }

        private void PrintMenuMessage()
        {
            Console.ResetColor();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Choose something");
            Console.WriteLine("1) Register");
            Console.WriteLine("2) List members");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0) Exit");
            Console.ResetColor();
        }

        private bool GetMenuChoice()
        {
            bool show = true;
            switch (Console.ReadLine())
            {
                case "1":
                    NextView = ViewType.Register;
                    show = false;
                    break;
                case "2":
                    NextView = ViewType.MemberList;
                    show = false;
                    break;

                case "0":
                    NextView = ViewType.Quit;
                    show = false;
                    break;

                default:
                    break;
            }
            return show;
        }

        private void RegisterMemberForm()
        {
            //TODO: add code for recieving userinput.
        }
        private void RegisterMember(string name, string id, PersonalID pid)
        {
            Model.Member newMember = new Model.Member(name, id, pid);
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter("../Registry/MemberRegistry/MemberRegistry.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //TODO: Check that code works
                serializer.Serialize(writer, newMember);
            }
        }

        public ViewType Run()
        {
            ShowMenu();
            return NextView;
        }
    }
}