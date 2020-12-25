
using System;

namespace PongUpgraded.Application.ConsoleKey
{
    public static class ConsoleKeyPress
    {
        public static void WaitFor(System.ConsoleKey key)
        {
            while (Console.ReadKey().Key != key)
            {

            }
        }
    }
}
