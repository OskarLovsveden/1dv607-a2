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

            Model.MemberList MemberList = new Model.MemberList();
            Member memberView = new Member(MemberList);
            Boat boatView = new Boat(MemberList);
            Register registerView = new Register(MemberList);

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
                        Menu.MenuItems = registerView.MenuItems;
                        break;
                    case ViewType.Member:
                        Menu.MenuItems = memberView.MenuItems;
                        break;
                    case ViewType.Boat:
                        boatView.Member = memberView.CurrentMember;
                        Menu.MenuItems = boatView.MenuItems;
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