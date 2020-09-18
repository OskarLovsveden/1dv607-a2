using System;

namespace View
{
    public class Start
    {
        private string errorMessage = "";
        public ViewType NextView { get; set; }
        public Start()
        {
            NextView = ViewType.Start;
        }

        private void ShowMenu() {
            bool show = true;

            while (show)
            {
                PrintMenuMessgae();
                show = GetMenuChoice(); 
            }

        }

        private void PrintMenuMessgae()
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

        public ViewType Run()
        {
            ShowMenu();
            return NextView;
        }
    }
}