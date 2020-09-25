using Controller;
using View;

namespace BoatClub
{
    class Program
    {
        private static void Main(string[] args)
        {
            Menu menu = new Menu();
            MenuController menuController = new MenuController(menu);
            menuController.CheckMenuStateSetView();
        }
    }
}
