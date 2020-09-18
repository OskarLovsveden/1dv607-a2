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
            ViewType currenView = start;
            
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
                    case ViewType.Start:
                        currenView = startView.Run();
                        break;
                    case ViewType.MemberList:
                        currenView = memberListView.Run();
                        break;
                    case ViewType.Member:
                        currenView = memberView.Run();
                        break;
                    case ViewType.BoatList:
                        currenView = boatListView.Run();
                        break;
                    case ViewType.Boat:
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
