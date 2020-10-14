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

            _menu.MenuCollection = memberView.MenuCollection;
            bool shouldContinue = true;
            while (shouldContinue)
            {
                _menu.Start();
                switch (_menu.ViewType)
                {
                    case ViewType.Member:
                        _menu.MenuCollection = memberView.MenuCollection;
                        break;
                    case ViewType.Register:
                        _menu.MenuCollection = registerView.MenuCollection;
                        break;
                    case ViewType.Boat:
                        boatView.Member = memberView.CurrentMember;
                        _menu.MenuCollection = boatView.MenuCollection;
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