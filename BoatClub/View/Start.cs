using Model.Menu;

namespace View
{
    public class Start
    {

        public MenuItems MenuItems { get; set; }

        public Start()
        {
            MenuItems = new MenuItems("Choose your own adventure");
            MenuItems.Add(new MenuItem("1) Register", () => { }, "1", ViewType.Register));
            MenuItems.Add(new MenuItem("2) List Members", () => { }, "2", ViewType.Member));
            MenuItems.Add(new MenuItem("0) Exit", () => { }, "0", ViewType.Quit));
        }
    }
}