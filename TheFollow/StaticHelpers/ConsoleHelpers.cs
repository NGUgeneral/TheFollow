using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFollow.StaticHelpers
{
    internal static class ConsoleHelpers
    {
        internal static void LogMessage(string s, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null)
        {
            ConsoleWithForeground(s, ConsoleColor.DarkGray, arg0, arg1, arg2, arg3);
        }

        internal static void LogUserMessage(string s, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null)
        {
            ConsoleWithForeground(s, ConsoleColor.DarkGreen, arg0, arg1, arg2, arg3);
        }

        internal static void UserMessage(string s, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null)
        {
            ConsoleWithForeground(s, ConsoleColor.Green, arg0, arg1, arg2, arg3);
        }

        internal static void LogEnemyMessage(string s, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null)
        {
            ConsoleWithForeground(s, ConsoleColor.DarkRed, arg0, arg1, arg2, arg3);
        }

        internal static void EnemyMessage(string s, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null)
        {
            ConsoleWithForeground(s, ConsoleColor.Red, arg0, arg1, arg2, arg3);
        }

        internal static void ConsoleWithForeground(string s, ConsoleColor c, object arg0, object arg1, object arg2, object arg3)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(s, arg0, arg1, arg2, arg3);
            Console.ResetColor();
        }
    }
}
