using System;

namespace BoatClub
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenus(ViewType.Start);
        }

        private static void ShowMenus(ViewType start)
        {
            bool show = true;
            ViewType currentView = start;
            ViewType previousView = start;
            
            // Instantiate all views
            View.Start startView = new View.Start();
            View.Boat boatView = new View.Boat();
            View.BoatList boatListView = new View.BoatList();
            View.Member memberView = new View.Member();
            View.MemberList memberListView = new View.MemberList();


            while (show)
            {
                switch (currentView)
                {
                    case ViewType.Start:
                        currentView = startView.Run();
                        break;
                    case ViewType.MemberList:
                        currentView = memberListView.Run();
                        break;
                    case ViewType.Member:
                        currentView = memberView.Run();
                        break;
                    case ViewType.BoatList:
                        currentView = boatListView.Run();
                        break;
                    case ViewType.Boat:
                        currentView = boatView.Run();
                        break;
                    default:
                        show = false;
                        break;
                }
            }

        }
    }
}
