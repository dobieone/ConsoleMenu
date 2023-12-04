using ConsoleMenu;
using System;
using System.Collections.Generic;

namespace ConsoleMenu
{
    public class Menu
    {
        private List<MenuOption> _options = new List<MenuOption>();
        private int _index = 0;
        private string _title;
        private bool _underline;

        private const string SelectedIndicator = "> ";
        private const string NotSelectedIndicator = "  ";

        public Menu AddOption(MenuOption option)
        {
            _options.Add(option);
            return this;
        }

        public Menu AddTitle(string title, bool underline = true)
        {
            _title = title;
            _underline = underline;
            return this;
        }

        public bool OutputMenu()
        {
            DrawMenu();
            if (_options[0].TriggerType == MenuOptionTriggerType.OnSelect)
                _options[0].OnSelect?.Invoke();
            var exit = false;
            do
            {
                exit = HandleInput();
            }
            while (!exit);
            return exit;
        }

        private void DrawMenu()
        {
            Console.Clear();
            if (!string.IsNullOrEmpty(_title))
            {
                Console.WriteLine($"{NotSelectedIndicator}{_title}");
                if (_underline)
                {
                    Console.WriteLine($"{NotSelectedIndicator}{new string('-', _title.Length)}");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < _options.Count; i++)
            {
                if (_options[i].Spacer)
                    Console.WriteLine();
                var prefix = i == _index ? SelectedIndicator : NotSelectedIndicator;
                Console.WriteLine($"{prefix}{_options[i].Name}");
            }
            Console.WriteLine();
        }

        private bool HandleInput()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.DownArrow:
                    if (_index + 1 < _options.Count)
                    {
                        HandleOptionChange(1);
                    }
                    return false;
                case ConsoleKey.UpArrow:
                    if (_index - 1 >= 0)
                    {
                        HandleOptionChange(-1);
                    }
                    return false;
                case ConsoleKey.Enter:
                    if (_options[_index].TriggerType == MenuOptionTriggerType.EnterKey)
                    {
                        var rtn = _options[_index].Exit;
                        _options[_index].OnSelect?.Invoke();
                        if (!rtn)
                        {
                            _index = 0;
                            DrawMenu();
                        }
                        return rtn;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }

        private void HandleOptionChange(int amount)
        {
            _index += amount;
            DrawMenu();
            if (_options[_index].TriggerType == MenuOptionTriggerType.OnSelect)
            {
                _options[_index].OnSelect?.Invoke();
            }
        }
    }
}
