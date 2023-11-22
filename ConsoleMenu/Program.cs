using ConsoleMenu.Menus;
using System;

namespace ConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            var m = new MainMenu();
            m.Show();
        }
    }

}
