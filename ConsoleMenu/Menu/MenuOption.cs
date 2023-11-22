using System;

namespace ConsoleMenu
{
    public class MenuOption
    {
        public string Name { get; }
        public Action OnSelect { get; }
        public bool Exit { get; }
        public bool Spacer { get; }

        public MenuOption(string name, Action onSelect, bool exit, bool spacer)
        {
            Name = name;
            OnSelect = onSelect;
            Exit = exit;
            Spacer = spacer;
        }
    }
}
