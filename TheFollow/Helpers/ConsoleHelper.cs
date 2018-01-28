using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Helpers;

namespace TheFollow.Helpers
{
    internal static class ConsoleHelper
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
                    case "q":
                        PrintQuest();
                        break;
                    case "i":
                        PrintInventory();
                        break;
                    case "e":
                        Handle_E();
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

        private static void PrintQuest()
        {
            var currentQuest = GameInstance.Instance.CurrentGameData.Quests[GameInstance.Instance.CurrentGameData.CurrentQuestIndex];
            currentQuest.GetGoalDescription();
        }

        private static void TakeOff_E()
        {
            LogMessage("Which inventory item would you like to take off?");
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
                        var item = GameInstance.Instance.CurrentPlayer.Inventory[index - 1];
                        var bodyPart = GameInstance.Instance.CurrentPlayer.Body.SingleOrDefault(x => x.Title == item.Slot);
                        bodyPart.TakeOffItem(item.Id);

                        LogMessage("You have removed item");
                    }
                }
                else
                {
                    LogMessage("Unavailiable inventory slot {0}", index);
                }
            }
        }

        private static void Handle_E()
        {
            LogMessage("Which inventory item would you like to equip?");
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
                        var item = GameInstance.Instance.CurrentPlayer.Inventory[index - 1];
                        var bodyPart = GameInstance.Instance.CurrentPlayer.Body.SingleOrDefault(x => x.Title == item.Slot);
                        bodyPart.EquipItem(item.Id);

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
            LogMessage("Level: {0}", GameInstance.Instance.CurrentPlayer.Level);
            LogMessage("Experience: {0}/{1}exp", GameInstance.Instance.CurrentPlayer.Experience, GameInstance.Instance.CurrentPlayer.NextLevel);
            LogMessage("Attack: {0}", GameInstance.Instance.CurrentPlayer.AttackStrength);
            BodyStats.PrintBodyPartsStat(GameInstance.Instance.CurrentPlayer);
        }

        private static void PrintHelp()
        {
            LogMessage("To start menu print minus '-' symbol.");
            LogMessage("List of availiable commands:");
            LogMessage("h - bring help;");
            LogMessage("s - show stats;");
            LogMessage("q - show current quest goal;");
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
