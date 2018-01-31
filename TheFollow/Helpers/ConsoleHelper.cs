using System;
using System.Collections.Generic;
using System.Linq;

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
				if (menu.Equals(string.Empty))
					menu = "-";

				switch (menu.ToLower()[0].ToString())
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
						if (menu.Length == 1) PrintInventory();
						if (menu.Length > 1) HandleInventoryCommand(menu.Substring(1));
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

		private static void HandleInventoryCommand(string s)
		{
			var items = s.Split(',');
			var indexes = new List<int>();
			foreach (var i in items)
			{
				if (int.TryParse(i, out int index) && index - 1 < GameInstance.Instance.CurrentPlayer.Inventory.Count)
				{
					indexes.Add(index - 1);
				}
				else
				{
					LogMessage("Incorrect command -i{0}", s);
					return;
				}
			}

			indexes.ForEach(HandleEquip);
		}

		private static void HandleEquip(int index)
		{
			var item = GameInstance.Instance.CurrentPlayer.Inventory[index];

			if (item.Equiped)
			{
				GameInstance.Instance.CurrentPlayer.UnequipItem(item);
			}
			else
			{
				GameInstance.Instance.CurrentPlayer.EquipItem(item);
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
			LogMessage("Equiped weight: {0}", GameInstance.Instance.CurrentPlayer.GetWeight());
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
			LogMessage("i1,2,3 - equip/unequip inventory items;");
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