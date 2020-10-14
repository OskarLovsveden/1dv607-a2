using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Menu
{
    public class MenuCollection
    {
        private readonly string _exitCode = "0";
        private string _title;
        private List<MenuItem> _allMenuItems;
        public List<MenuItem> AllMenuCollection { get => _allMenuItems; }
        public string Title { get => _title; }

        public string ExitCode { get => _exitCode; }

        public string CurrentActionKey
        {
            get => (AllMenuCollection.Count() + 1).ToString();
        }

        public MenuCollection(string title)
        {
            _title = title;
            _allMenuItems = new List<MenuItem>();
        }

        public void Add(MenuItem menuItem)
        {
            _allMenuItems.Add(menuItem);
        }

        public void AddGoBackMenuItem(Action action, ViewType viewType)
        {
            _allMenuItems.Add(new MenuItem($"{_exitCode}) Go back", action, _exitCode, viewType));
        }

        public void AddExitMenuItem(Action action, ViewType viewType)
        {
            _allMenuItems.Add(new MenuItem($"{_exitCode}) Exit", action, _exitCode, viewType));
        }

        public MenuItem Find(string selectedItem)
        {
            return AllMenuCollection.Find(item => item.ActionKey == selectedItem);
        }

        public bool Exists(string selectedItem)
        {
            return AllMenuCollection.Exists(item => item.ActionKey == selectedItem);
        }

    }
}