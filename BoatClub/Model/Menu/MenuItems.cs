using System;
using System.Collections.Generic;

namespace Model.Menu
{
    public class MenuItems
    {
        public List<MenuItem> AllMenuItems { get; set; }
        public string Title { get; set; }

        public MenuItems(string title)
        {
            Title = title;
            AllMenuItems = new List<MenuItem>();
        }

        public void Add(MenuItem menuItem)
        {
            AllMenuItems.Add(menuItem);
        }

        public MenuItem Find(string selectedItem)
        {
            return AllMenuItems.Find(item => item.ActionKey == selectedItem);
        }

        public bool Exists(string selectedItem)
        {
            return AllMenuItems.Exists(item => item.ActionKey == selectedItem);
        }

    }
}