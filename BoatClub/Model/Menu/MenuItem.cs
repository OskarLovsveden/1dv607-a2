using System;

namespace Model.Menu
{
    public class MenuItem
    {
        public string Title { get; private set; }
        public Action Action { get; private set; }
        public string ActionKey { get; private set; }
        public ViewType ViewType { get; private set; }

        public MenuItem(string title, Action action, string actionKey, ViewType viewType)
        {
            Title = title;
            Action = action;
            ActionKey = actionKey;
            ViewType = viewType;
        }
    }
}