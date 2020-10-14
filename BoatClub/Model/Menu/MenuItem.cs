using System;

namespace Model.Menu
{
    public class MenuItem
    {
        private string _title;
        private Action _action;
        private string _actionKey;
        private ViewType _viewType;

        public string Title { get => _title; }
        public Action Action { get => _action; }
        public string ActionKey { get => _actionKey; }
        public ViewType ViewType { get => _viewType; }

        public MenuItem(string title, Action action, string actionKey, ViewType viewType)
        {
            _title = title;
            _action = action;
            _actionKey = actionKey;
            _viewType = viewType;
        }
    }
}