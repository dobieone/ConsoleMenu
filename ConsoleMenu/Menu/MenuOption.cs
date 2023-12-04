using System;

namespace ConsoleMenu
{
    public class MenuOption
    {
        public string Name { get; }
        public Action OnSelect { get; }
        public bool Exit { get; protected set; }
        public bool Spacer { get; protected set; }
        public MenuOptionTriggerType TriggerType { get; protected set; }

        public MenuOption(string name, Action onSelect)
        {
            Name = name;
            OnSelect = onSelect;
        }

        public MenuOption SetExits()
        {
            Exit = true;
            return this;
        }

        public MenuOption AddSpacer()
        {
            Spacer = true;
            return this;
        }

        public MenuOption SetTriggerType(MenuOptionTriggerType triggerType)
        {
            TriggerType = triggerType;
            return this;
        }
    }
}
