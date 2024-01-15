using System;
using System.Diagnostics;

namespace ConsoleMenu.Menus
{
    internal class MainMenu
    {
        Menu _mnu = new Menu();
        bool _exit = false;

        public MainMenu()
        {
            var exit = new MenuOption("Exit", () => Environment.Exit(0))
                .SetExits()
                .AddSpacer();

            _mnu = new Menu()
                .AddTitle("Main Menu")
                .AddHeader("Use arrow keys to select to move indicator, enter to select...")
                .AddCallback(ConsoleKey.Spacebar, () => Debug.WriteLine("Space Pressed..."))
                .AddOption(new MenuOption("Sub Menu 1", () => ShowSubMenuOne()))
                .AddOption(new MenuOption("Sub Menu 2", () => ShowSubMenuTwo()))
                .AddOption(exit);
        }

        public void Show()
        {
            do
            {
                _exit = _mnu.OutputMenu();
            }
            while (!_exit);
        }

        private void ShowSubMenuOne()
        {
            var m = new SubOne();
            m.Show();
        }

        private void ShowSubMenuTwo()
        {
            var m = new SubTwo();
            m.Show();
        }
    }
}
