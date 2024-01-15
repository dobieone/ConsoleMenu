using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Menus
{
    internal class SubTwo
    {
        Menu _mnu = new Menu();
        bool _exit = false;

        public SubTwo()
        {
            var back = new MenuOption("Back", null)
                .SetExits()
                .AddSpacer();

            _mnu = new Menu()
                .AddTitle("Sub Menu Two")
                .AddOption(new MenuOption("Sub Menu 2 - 1", () => Message.Write("Sub Menu 2 - 1")))
                .AddOption(new MenuOption("Sub Menu 2 - 2", () => Message.Write("Sub Menu 2 - 2")))
                .AddOption(back);
        }

        public void Show()
        {
            do
            {
                _exit = _mnu.OutputMenu();
            }
            while (!_exit);
        }
    }
}
