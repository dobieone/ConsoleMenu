using System;
using System.Collections.Generic;

namespace ConsoleMenu
{
    public class Menu
    {
        private List<MenuOption> _options = new List<MenuOption>();
        private static int _index = 0;
        private string _title;
        private bool _underline;

        private const string SelectedIndicator = "> ";
        private const string NotSelectedIndicator = "  ";

        public Menu AddOption(string name, Action onSelected, bool exit, bool spacer = false)
        {
            _options.Add(new MenuOption(name, onSelected, exit, spacer));
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
                        _index++;
                        DrawMenu();
                    }
                    return false;
                case ConsoleKey.UpArrow:
                    if (_index - 1 >= 0)
                    {
                        _index--;
                        DrawMenu();
                    }
                    return false;
                case ConsoleKey.Enter:
                    _options[_index].OnSelect?.Invoke();
                    var rtn = _options[_index].Exit;
                    if (!rtn)
                        DrawMenu();
                    return rtn;
                default:
                    return false;
            }
        }
    }
}
