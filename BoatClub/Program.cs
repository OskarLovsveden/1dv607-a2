using System;

namespace BoatClub
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenus(Views.Start);
        }

        private static void ShowMenus(Views start)
        {
            bool show = true;
            Views currenView = start;
            
            // Instantiate all views
            View.Start startView = new View.Start();
            View.Boat boatView = new View.Boat();
            View.BoatList boatListView = new View.BoatList();
            View.Member memberView = new View.Member();
            View.MemberList memberListView = new View.MemberList();


            while (show)
            {
                switch (currenView)
                {
                    case Views.Start:
                        currenView = startView.Run();
                        break;
                    case Views.MemberList:
                        currenView = memberListView.Run();
                        break;
                    case Views.Member:
                        currenView = memberView.Run();
                        break;
                    case Views.BoatList:
                        currenView = boatListView.Run();
                        break;
                    case Views.Boat:
                        currenView = boatView.Run();
                        break;
                    default:
                        show = false;
                        break;
                }
            }

        }
    }
}
