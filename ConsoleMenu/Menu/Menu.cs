using ConsoleMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ConsoleMenu
{
    public class Menu
    {
        private List<MenuOption> _options = new List<MenuOption>();
        private Dictionary<ConsoleKey, Action> _callbacks = new Dictionary<ConsoleKey, Action>();
        private int _index = 0;
        private string _title;
        private bool _underline;
        private string _header;
        private string _footer;
        private bool _clear = true;
        private bool _startOnExit = false;

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

        public Menu AddCallback(ConsoleKey key, Action onPress)
        {
            _callbacks[key] = onPress;
            return this;
        }

        public Menu SetClear(bool clear)
        {
            _clear = clear;
            return this;
        }

        public Menu SetStartOnExit(bool startOnExit)
        {
            _startOnExit = startOnExit;
            return this;
        }

        public Menu AddFooter(string footer)
        {
            _footer = footer;
            return this;
        }

        public Menu AddHeader(string header)
        {
            _header = header;
            return this;
        }

        public bool OutputMenu()
        {
            SetStartIndex();
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
            ClearConsole();
            if (!string.IsNullOrEmpty(_title))
            {
                Console.WriteLine($"{NotSelectedIndicator}{_title}");
                if (_underline)
                {
                    Console.WriteLine($"{NotSelectedIndicator}{new string('-', _title.Length)}");
                }
                Console.WriteLine();
            }
            if (!string.IsNullOrEmpty(_header))
            {
                Console.WriteLine($"{NotSelectedIndicator}{_header}");
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
            if (!string.IsNullOrEmpty(_footer))
            {
                Console.WriteLine($"{NotSelectedIndicator}{_footer}");
                Console.WriteLine();
            }
        }

        private bool HandleInput()
        {
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    if (_index + 1 < _options.Count)
                    {
                        HandleOptionChange(1);
                    }
                    CheckCallback(key);
                    return false;
                case ConsoleKey.UpArrow:
                    if (_index - 1 >= 0)
                    {
                        HandleOptionChange(-1);
                    }
                    CheckCallback(key);
                    return false;
                case ConsoleKey.Enter:
                    if (_options[_index].TriggerType == MenuOptionTriggerType.EnterKey)
                    {
                        var rtn = _options[_index].Exit;
                        _options[_index].OnSelect?.Invoke();
                        if (!rtn)
                        {
                            SetStartIndex();
                            DrawMenu();
                        }
                        return rtn;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    CheckCallback(key);
                    return false;
            }
        }

        private void CheckCallback(ConsoleKey key)
        {
            if (_callbacks.ContainsKey(key))
            {
                var cb = _callbacks[key];
                cb?.Invoke();
                HandleOptionChange(0);
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

        private void ClearConsole()
        {
            if (_clear)
            {
                Console.Clear();
            }
        }

        private void SetStartIndex()
        {
            var i = 0;
            if (_startOnExit)
            {
                var option = _options.Where(o => o.Exit == true).FirstOrDefault();
                i = _options.IndexOf(option);
            }
            _index = i;
        }

        public void Clear()
        {
            _options.Clear();
            _callbacks.Clear();
        }
    }
}
