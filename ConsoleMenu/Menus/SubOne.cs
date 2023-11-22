using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleMenu.Menus
{
    internal class SubOne
    {
        Menu _mnu = new Menu();
        bool _exit = false;

        public SubOne()
        {
            _mnu = new Menu()
                .AddTitle("Sub Menu One")
                .AddOption("Sub Menu 1 - 1", () => Message.Write("Sub Menu 1 - 1"), false)
                .AddOption("Sub Menu 1 - 2", () => Message.Write("Sub Menu 1 - 2"), false)
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
