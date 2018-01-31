using System;
using System.Collections.Generic;
using TheFollow.GameFlow.Quests;
using TheFollow.Helpers;
using TheFollow.Models;
using TheFollow.Models.Interfaces;
using TheFollow.Models.Wrappers;

namespace TheFollow.GameFlow
{
	internal static class Campaign
	{
		internal static void LaunchInterface()
		{
			GameInstance.Instance.CurrentGameData = new GameData();
			Console.WriteLine("\n\n-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-\nWelcome!\nPlease, type below the name for you character and we can start!");
			Console.Write("Pease type in you name: ");
			GameInstance.Instance.CurrentPlayer = new Player(Console.ReadLine());

			GameInstance.Instance.CurrentPlayer.InitialEquip();

			Console.WriteLine("\nPlease - remember, any time you need help with the commands print '-h'");
			ConsoleHelper.UserMessage("\nSo, {0}, your journey has begun.", GameInstance.Instance.CurrentPlayer.Name);

			HandleSwitchQuest();
			ConsoleHelper.UserMessage("\nDon`t forget to gear up from your inventory.");

			while (GameInstance.Instance.CurrentPlayer.Alive && !GameInstance.Instance.CurrentGameData.Finished)
			{
				StartDay();
			}
		}

		internal static void HandleSwitchQuest()
		{
			var currentQuest = GameInstance.Instance.CurrentGameData.Quests[GameInstance.Instance.CurrentGameData.CurrentQuestIndex];
			currentQuest.GetIntro();
			currentQuest.GetGoalDescription();
		}

		internal static void HandleEndGame()
		{
			GameInstance.Instance.CurrentGameData.Replay = ConsoleHelper.FilterInput("Would you like to replay? (y/n)", new ConsoleKey[] { ConsoleKey.Y, ConsoleKey.N }) == ConsoleKey.Y ? true : false;
		}

		private static void StartDay()
		{
			var player = GameInstance.Instance.CurrentPlayer;
			Console.WriteLine("\nNew day. What will it bring?");
			ConsoleHelper.LogUserMessage("Current health is {0}hp", BodyStats.GetTotalHealth(GameInstance.Instance.CurrentPlayer));
			ConsoleHelper.FilterInput("Press enter to make a move and see what this day brought you", new ConsoleKey[] { ConsoleKey.Enter });

			var dayEvent = EventWeight.Pick(new List<EventWeight> {
								new EventWeight { Event = EventType.None, PickWeight = 20 },
								new EventWeight { Event = EventType.VillageAproach, PickWeight = 15 },
								new EventWeight { Event = EventType.MonsterEncounter, PickWeight = 65 }
						});

			switch (dayEvent)
			{
				case EventType.None:
					HandleNoneEncounter();
					break;

				case EventType.VillageAproach:
					HandleVillageEncounter();
					break;

				case EventType.MonsterEncounter:
					HandleMonsterEncounter();
					break;

				default:
					break;
			}
		}

		private static void HandleNoneEncounter()
		{
			Console.WriteLine("Nothing happened this day, you just wondered around without any clue and lost a day");
			Console.WriteLine("Even worse - you will have to stay outside during the night, so there is a chance to be caught by an ambush ...");
			if (Dice.ThrowDice(0, 6, 5))
			{
				Console.WriteLine("Gods have mercy, you saw a light while looking for firewood in the nearby forest.");
				HandleVillageEncounter();
			}
			else
			{
				if (Dice.ThrowDice(0, 6, 3))
				{
					Console.WriteLine("You have been able to find soome fire wood in the nearby forrest.\nThe fire will help you stay safe during the night as well - you will be able to heal yourself a little bit.");
					GameInstance.Instance.CurrentPlayer.PartialRegenerate();
					if (Dice.ThrowDice(0, 6, 4)) HandleMonsterEncounter();
				}
				else
				{
					Console.WriteLine("Rocky place you are at. You were not able to find any fire wood to face the darknes.");
					if (Dice.ThrowDice(0, 6, 3)) HandleMonsterEncounter();
				}
			}
		}

		private static void HandleVillageEncounter()
		{
			Console.WriteLine("You found a village with a friendly people.\nYou feel safe enough, so you are taking your chance to have a rest from your wandering and heal you wounds.");
			GameInstance.Instance.CurrentPlayer.PartialRegenerate(1);
		}

		private static void HandleMonsterEncounter()
		{
			var monster = Pools.GetMonster();
			ConsoleHelper.LogEnemyMessage("You have encountered a monster. It is an {0} {1}", monster.Title, monster.Name);
			ConsoleHelper.FilterInput("\nPress enter to face the enemy.", new ConsoleKey[] { ConsoleKey.Enter });
			while (monster.Alive)
			{
				FightHelper.BattleTurn(ref monster);
				if (!GameInstance.Instance.CurrentPlayer.Alive) { FightHelper.HandleDeath(monster); break; }
			}

			if (GameInstance.Instance.CurrentPlayer.Alive) FightHelper.ProcessVictory(monster);
		}

		internal static void ProcessLevelUp()
		{
			GameInstance.Instance.CurrentPlayer.Level += 1;
			GameInstance.Instance.CurrentPlayer.NextLevel += 10;
			ConsoleHelper.UserMessage("Congratulations! You gained a level up! Current level is {0}", GameInstance.Instance.CurrentPlayer.Level);

			foreach (var b in GameInstance.Instance.CurrentPlayer.Body)
			{
				b.MaxHealth += 1;
			}
			GameInstance.Instance.CurrentPlayer.AttackStrength += 1;
			GameInstance.Instance.CurrentPlayer.PartialRegenerate(1);

			switch (GameInstance.Instance.CurrentPlayer.Level)
			{
				case 2:
					GameInstance.Instance.CurrentPlayer.AddItemToInventory(Pools.GetItemById("TribalBracer_L"));
					GameInstance.Instance.CurrentPlayer.AddItemToInventory(Pools.GetItemById("TribalBracer_Heavy_R"));
					GameInstance.Instance.CurrentPlayer.AddItemToInventory(Pools.GetItemById("TribalBoot_L"));
					GameInstance.Instance.CurrentPlayer.AddItemToInventory(Pools.GetItemById("TribalBoot_R"));
					break;

				case 3:
					GameInstance.Instance.CurrentPlayer.AddItemToInventory(Pools.GetItemById("TribalShield"));
					break;

				default:
					break;
			}

			var currentQuest = GameInstance.Instance.CurrentGameData.Quests[GameInstance.Instance.CurrentGameData.CurrentQuestIndex];
			if (currentQuest is Quest1_TheTrial)
			{
				currentQuest.TryToComplete();
			}
		}
	}
}