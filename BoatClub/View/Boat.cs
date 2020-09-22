using System;
using System.IO;

namespace View
{
    public class Boat
    {
        private string _menuItems = "Manage Boat\n1) Change Type\n2) Change Length\n3) Delete";
        private Model.Boat _boatModel;

        public ViewType NextView { get; set; }
        public Boat(Model.Boat boatModel) 
        {
            _boatModel = boatModel;
            NextView = ViewType.Start;
        }

        public void ShowMenu()
        {
            bool show = true;

            while (show)
            {
                PrintMenuMessages();
                show = GetMenuChoice(); 
            }
        }

        private bool GetMenuChoice()
        {
            bool show = true;
            switch (Console.ReadLine())
                {
                    case "1":
                        ChangeType();
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

        private void PrintMenuMessages()
        {
            Console.ResetColor();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_menuItems);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0) Exit");
            Console.ResetColor();
        }


        private void ChangeType()
        {
            Console.ResetColor();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintPossibleBoatTypes();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0) Exit");
            Console.ResetColor();
        }

        private void PrintPossibleBoatTypes()
        {

            for (int i = 0; i < Enum.GetNames(typeof(BoatType)).Length; i++)
            {
                Console.WriteLine($"{i}) {Enum.GetNames(typeof(BoatType))[i]}");
            }
        }

        public ViewType Run()
        {

            return NextView;
        }
        
    }

}