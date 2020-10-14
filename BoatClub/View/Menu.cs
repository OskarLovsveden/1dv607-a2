using System;
using Model.Menu;

namespace View
{
    public class Menu
    {
        private ViewType _viewType;
        private bool _showMenu = true;

        public MenuCollection MenuCollection { get; set; }

        public bool ShowMenu
        {
            private get => _showMenu;
            set => _showMenu = value;
        }

        public ViewType ViewType
        {
            get => _viewType;
            set => _viewType = value;
        }

        public void Start()
        {
            while (ShowMenu)
            {
                PrintMenuCollection();
                string selectedMenuItem = GetSelectedItem();
                if (MenuCollection.Exists(selectedMenuItem))
                {
                    DoItemAction(selectedMenuItem);
                    ShowMenu = !ShowMenu;
                }
                else
                {
                    // Default block
                }
            }
        }
        private void DoItemAction(string selectedItem)
        {
            MenuItem m = MenuCollection.Find(selectedItem);
            Action action = m.Action;
            action();
            ViewType = m.ViewType;
        }

        private void PrintMenuCollection()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine(MenuCollection.Title);
            foreach (MenuItem item in MenuCollection.AllMenuCollection)
            {
                if (item.ActionKey == "0")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(item.Title);
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.ResetColor();

        }

        private string GetSelectedItem()
        {
            return Console.ReadKey(true).KeyChar.ToString();
        }

    }
}