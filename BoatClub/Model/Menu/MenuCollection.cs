using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Menu
{
    public class MenuCollection
    {
        private readonly string _exitCode = "0";
        public List<MenuItem> AllMenuCollection { get; private set; }
        public string Title { get; private set; }

        public string ExitCode { get => _exitCode; }

        public string CurrentActionKey
        {
            get => (AllMenuCollection.Count() + 1).ToString();
        }

        public MenuCollection(string title)
        {
            Title = title;
            AllMenuCollection = new List<MenuItem>();
        }

        public void Add(MenuItem menuItem)
        {
            AllMenuCollection.Add(menuItem);
        }

        public void AddGoBackMenuItem(Action action, ViewType viewType)
        {
            AllMenuCollection.Add(new MenuItem($"{_exitCode}) Go back", action, _exitCode, viewType));
        }

        public void AddExitMenuItem(Action action, ViewType viewType)
        {
            AllMenuCollection.Add(new MenuItem($"{_exitCode}) Exit", action, _exitCode, viewType));
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