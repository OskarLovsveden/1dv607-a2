using View;

namespace Controller
{
    public class MenuController
    {
        private Menu _menu;

        public Menu Menu
        {
            get => _menu;
            set => _menu = value;
        }

        public MenuController(Menu menu)
        {
            Menu = menu;
            Menu.ViewType = ViewType.Start;
        }

        public void CheckMenuStateSetView()
        {
            Start startView = new Start();
            Menu.MenuItems = startView.MenuItems;

            MemberList memberListView = new MemberList();

            bool shouldContinue = true;
            while (shouldContinue)
            {
                System.Console.WriteLine("while");
                Menu.Start();
                switch (Menu.ViewType)
                {
                    case ViewType.Start:
                        Menu.MenuItems = startView.MenuItems;
                        break;
                    case ViewType.Register:
                        System.Console.WriteLine("Register");
                        break;
                    case ViewType.MemberList:
                        Menu.MenuItems = memberListView.MenuItems;
                        break;
                    case ViewType.BoatList:
                        break;
                    case ViewType.Boat:
                        break;
                    case ViewType.Member:
                        break;
                    case ViewType.Quit:
                        shouldContinue = false;
                        Menu.ShowMenu = false;
                        return;
                    default:
                        break;
                }
                Menu.ShowMenu = true;
            }
        }
    }
}