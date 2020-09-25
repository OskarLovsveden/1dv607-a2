using System;

namespace Model.Menu
{
    public class MenuItem
    {
        private string _title;
        private Action _action;
        private string _actionKey;
        private ViewType _viewType;

        public String Title
        {
            get => _title;
            set => _title = value;
        }
        public Action Action
        {
            get => _action;
            set => _action = value;
        }
        public String ActionKey
        {
            get => _actionKey;
            set => _actionKey = value;
        }

        public ViewType ViewType
        {
            get => _viewType;
            set => _viewType = value;
        }

        public MenuItem(string title, Action action, string actionKey, ViewType viewType)
        {
            _title = title;
            _action = action;
            _actionKey = actionKey;
            _viewType = viewType;
        }
    }
}