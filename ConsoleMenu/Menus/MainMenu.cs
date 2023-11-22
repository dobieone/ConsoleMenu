using System;

namespace ConsoleMenu.Menus
{
    internal class MainMenu
    {
        Menu _mnu = new Menu();
        bool _exit = false;

        public MainMenu()
        {
            _mnu = new Menu()
                .AddTitle("Main Menu")
                .AddOption("Sub Menu 1", () => ShowSubMenuOne(), false)
                .AddOption("Sub Menu 2", () => ShowSubMenuTwo(), false)
                .AddOption("Exit", () => Environment.Exit(0), false, true);
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
