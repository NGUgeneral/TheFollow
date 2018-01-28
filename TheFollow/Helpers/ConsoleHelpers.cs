using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFollow.StaticHelpers
{
    internal static class ConsoleHelpers
    {
        internal static ConsoleKey FilterInput(string message, ConsoleKey[] keys)
        {
            Console.WriteLine(message);
            ConsoleKey input = Console.ReadKey().Key;

            while (!keys.Contains(input))
            {
                HandleMenuCommand(input);
                Console.WriteLine("\n" + message);
                input = Console.ReadKey().Key;
            }

            return input;
        }

        private static void HandleMenuCommand(ConsoleKey input)
        {
            if (input == ConsoleKey.OemMinus)
            {
                var menu = Console.ReadLine();
                switch (menu.ToLower())
                {
                    case "h":
                        PrintHelp();
                        break;
                    case "s":
                        PrintStat();
                        break;
                    case "i":
                        PrintInventory();
                        break;
                    case "e":
                        Handele_E();
                        break;
                    case "t":
                        TakeOff_E();
                        break;
                    default:
                        LogMessage("No such command: {0}", menu);
                        break;
                }
            }
        }

        private static void TakeOff_E()
        {
            LogMessage("Which slot would you like to take off?");
            var slot = Console.ReadLine();
            if (int.TryParse(slot, out int index))
            {
                if (index <= GameInstance.Instance.CurrentPlayer.Inventory.Count && index > 0)
                {
                    if (!GameInstance.Instance.CurrentPlayer.Inventory[index - 1].Equiped)
                    {
                        LogMessage("Item is not equiped.");
                    }
                    else
                    {
                        GameInstance.Instance.CurrentPlayer.TakeOffItem(index - 1);
                        LogMessage("You have removed item");
                    }
                }
                else
                {
                    LogMessage("Unavailiable inventory slot {0}", index);
                }
            }
        }

        private static void Handele_E()
        {
            LogMessage("Which slot would you like to equip?");
            var slot = Console.ReadLine();
            if (int.TryParse(slot, out int index))
            {
                if(index <= GameInstance.Instance.CurrentPlayer.Inventory.Count && index > 0)
                {
                    if(GameInstance.Instance.CurrentPlayer.Inventory[index - 1].Equiped)
                    {
                        LogMessage("Item already equiped.");
                    }
                    else
                    {
                        GameInstance.Instance.CurrentPlayer.EquipItem(index - 1);
                        LogMessage("You have equiped item");
                    }
                }
                else
                {
                    LogMessage("Unavailiable inventory slot {0}", index);
                }
            }
        }

        private static void PrintInventory()
        {
            foreach (var item in GameInstance.Instance.CurrentPlayer.Inventory)
            {
                LogMessage("Slot: " + (GameInstance.Instance.CurrentPlayer.Inventory.IndexOf(item) + 1).ToString());
                LogMessage(item.Description);
                LogMessage("Equiped - {0}", item.Equiped ? "yes" : "no");
                LogMessage("-----");
            }
        }

        private static void PrintStat()
        {
            LogMessage("Your hero is at level {0}", GameInstance.Instance.CurrentPlayer.Level);
            LogMessage("Experience {0}", GameInstance.Instance.CurrentPlayer.Experience);
            LogMessage("Level up at {0}", GameInstance.Instance.CurrentPlayer.NextLevel);
            LogMessage("Current healt {0}hp", BodyStats.GetTotalHealth(GameInstance.Instance.CurrentPlayer));
        }

        private static void PrintHelp()
        {
            LogMessage("To start menu print minus '-' symbol.");
            LogMessage("List of availiable commands:");
            LogMessage("h - bring help;");
            LogMessage("s - show stats;");
            LogMessage("i - print out inventory;");
            LogMessage("e - equip inventory item;");
            LogMessage("t - take off inventory item;");
        }

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
