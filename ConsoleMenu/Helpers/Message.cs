using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    public static class Message
    {
        public static void Write(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
        }
    }
}
