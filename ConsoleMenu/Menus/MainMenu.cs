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
                .AddOption(new MenuOption("Sub Menu 1", () => ShowSubMenuOne()))
                .AddOption(new MenuOption("Sub Menu 2", () => ShowSubMenuTwo()))
                .AddOption(new MenuOption("Exit", () => Environment.Exit(0)).SetExits().AddSpacer());
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
