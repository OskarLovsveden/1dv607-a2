using System;

namespace Model.Menu
{
    public class MenuItem
    {
        public String Title { get; private set; }
        public Action Action { get; private set; }
        public String ActionKey { get; private set; }
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