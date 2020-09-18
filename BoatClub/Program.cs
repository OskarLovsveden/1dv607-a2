using System;
using Views;

namespace BoatClub
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenus(Views.Start);
        }
    }

    private void ShowMenus (enum Start)
    {
        boolean continue = true;
        enum currenView = Start;

        while (continue)
        {
            switch (currenView)
            {
                case Start:
                    currenView = StartView.Run();
                    Break;
                case MemberList:
                    currenView = MemberListView.Run();
                    Break;
                default:
                    continue = false;
            }
        }

    }
}
