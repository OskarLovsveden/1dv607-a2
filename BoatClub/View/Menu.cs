using System;
using System.Collections.Generic;
using Model.Menu;

namespace View
{
    public class Menu
    {
        private ViewType _viewType;
        private bool _showMenu = true;

        public MenuItems MenuItems { get; set; }

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
                PrintMenuItems();
                string selectedMenuItem = GetSelectedItem();
                if (MenuItems.Exists(selectedMenuItem))
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
            MenuItem m = MenuItems.Find(selectedItem);
            Action action = m.Action;
            action();
            ViewType = m.ViewType;
        }

        private void PrintMenuItems()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine(MenuItems.Title);
            foreach (MenuItem item in MenuItems.AllMenuItems)
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
        }

        private string GetSelectedItem()
        {
            return Console.ReadKey(true).KeyChar.ToString();
        }

    }
}