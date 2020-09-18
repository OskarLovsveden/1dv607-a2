using System;

namespace View
{
    public class MemberList
    {
        private string _errorMessage = "";
        public ViewType NextView { get; set; }
        public MemberList()
        {
            NextView = ViewType.Start;
        }
        private void ShowMenu() {
            bool show = true;

            while (show)
            {
                PrintMenuMessage();
                show = GetMenuChoice();
            }
        }
        
        private void PrintMenuMessage ()
        {
                Console.Clear();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Choose List to view");
                Console.WriteLine("1) Verbose");
                Console.WriteLine("2) Compact");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0) Back");
                Console.ResetColor();
        }

        private bool GetMenuChoice()
        {
            bool show = true;
             switch (Console.ReadLine())
                {
                    case "1":
                        ShowVerboseList();
                        show = false;
                        break;
                    case "2":
                        ShowCompactList();
                        show = false;
                        break;
                    case "0":
                        NextView = ViewType.Start;
                        show = false;
                        break;
                    default:
                        break;
                }
            return show;
        }

        private void ShowVerboseList()
        {
            System.Console.WriteLine("Listing verbose files");
        }
        
        private void ShowCompactList()
        {
            System.Console.WriteLine("Listing compact files");
        }
        public ViewType Run( )
        {
            ShowMenu();
            return NextView;
        }
    }
}