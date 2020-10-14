using System.Collections.Generic;

namespace Model.Menu
{
    public class MenuCollection
    {
        public List<MenuItem> AllMenuCollection { get; private set; }
        public string Title { get; private set; }

        public MenuCollection(string title)
        {
            Title = title;
            AllMenuCollection = new List<MenuItem>();
        }

        public void Add(MenuItem menuItem)
        {
            AllMenuCollection.Add(menuItem);
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