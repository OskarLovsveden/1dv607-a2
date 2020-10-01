using View;
using View.Pages;

namespace Controller
{
    public class MenuController
    {
        private Menu _menu;

        public MenuController(Menu menu)
        {
            _menu = menu;
            _menu.ViewType = ViewType.Member;
        }

        public void CheckMenuStateSetView()
        {
            Model.MemberList MemberList = new Model.MemberList();
            Member memberView = new Member(MemberList);
            Boat boatView = new Boat(MemberList);
            Register registerView = new Register(MemberList);

            _menu.MenuItems = memberView.MenuItems;
            bool shouldContinue = true;
            while (shouldContinue)
            {
                _menu.Start();
                switch (_menu.ViewType)
                {
                    case ViewType.Member:
                        _menu.MenuItems = memberView.MenuItems;
                        break;
                    case ViewType.Register:
                        _menu.MenuItems = registerView.MenuItems;
                        break;
                    case ViewType.Boat:
                        boatView.Member = memberView.CurrentMember;
                        _menu.MenuItems = boatView.MenuItems;
                        break;
                    case ViewType.Quit:
                        shouldContinue = false;
                        _menu.ShowMenu = false;
                        return;
                    default:
                        break;
                }
                _menu.ShowMenu = true;
            }
        }
    }
}