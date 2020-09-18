using System;
using View;

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
            
            

            while (show)
            {
                switch (currenView)
                {
                    case Views.Start:
                        currenView = StartView.Run();
                        break;
                    case Views.MemberList:
                        currenView = MemberListView.Run();
                        break;
                    case Views.Member:
                        currenView = MemberView.Run();
                        break;
                    case Views.BoatList:
                        currenView = BoatListView.Run();
                        break;
                    case Views.Boat:
                        currenView = BoatView.Run();
                        break;
                    default:
                        show = false;
                        break;
                }
            }

        }
    }
}
