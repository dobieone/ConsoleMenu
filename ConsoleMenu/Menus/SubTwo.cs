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
            _mnu = new Menu()
                .AddTitle("Sub Menu Two")
                .AddOption("Sub Menu 2 - 1", () => Message.Write("Sub Menu 2 - 1"), false)
                .AddOption("Sub Menu 2 - 2", () => Message.Write("Sub Menu 2 - 2"), false)
                .AddOption("Back", null, true, true);
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
