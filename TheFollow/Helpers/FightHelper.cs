using System;
using System.Linq;
using TheFollow.GameFlow;
using TheFollow.Models;

namespace TheFollow.Helpers
{
	internal static class FightHelper
	{
		internal static void BattleTurn(ref Monster monster)
		{
			AttackMonster(ref monster);
			if (monster.Alive) { AttackPlayer(ref monster); }
		}

		private static void AttackMonster(ref Monster monster)
		{
			var bodyPartToAttack = monster.Body.FirstOrDefault(x => x.Health > 0);
			if (bodyPartToAttack != null)
			{
				bodyPartToAttack.Health -= GameInstance.Instance.CurrentPlayer.AttackStrength;
				ConsoleHelper.LogMessage("You hitted {0} for {1}", monster.Name, GameInstance.Instance.CurrentPlayer.AttackStrength);
				if (bodyPartToAttack.Health <= 0) ConsoleHelper.LogMessage("You have crushed the {0}s {1}", monster.Name, bodyPartToAttack.Title);
				ConsoleHelper.LogEnemyMessage("Monster have {0}hp left overral", BodyStats.GetTotalHealth(monster));
				if (BodyStats.GetTotalHealth(monster) <= 0) monster.Alive = false;
			}
		}

		private static void AttackPlayer(ref Monster monster)
		{
			var bodyPartToAttack = GameInstance.Instance.CurrentPlayer.Body.FirstOrDefault(x => x.Health > 0);
			if (bodyPartToAttack != null)
			{
				bodyPartToAttack.Health -= monster.AttackStrength - bodyPartToAttack.Defense;
				ConsoleHelper.LogMessage("Monster hitted your {0} for {1}", bodyPartToAttack.Title, monster.AttackStrength - bodyPartToAttack.Defense);
				if (bodyPartToAttack.Health <= 0) ConsoleHelper.LogMessage("Your {0}s has been crushed", bodyPartToAttack.Title);
				ConsoleHelper.LogUserMessage("You have {0}hp left overral", BodyStats.GetTotalHealth(GameInstance.Instance.CurrentPlayer));
				if (BodyStats.GetTotalHealth(GameInstance.Instance.CurrentPlayer) <= 0)
				{
					GameInstance.Instance.CurrentPlayer.Alive = false;
				}
			}
		}

		internal static void ProcessVictory(Monster monster)
		{
			ConsoleHelper.LogMessage("Congratulations! You have slain the {0} {1}", monster.Title, monster.Name);
			ConsoleHelper.LogUserMessage("You have {0}hp left.", BodyStats.GetTotalHealth(GameInstance.Instance.CurrentPlayer));
			AddExperience(1);
		}

		internal static void HandleDeath(Monster monster)
		{
			ConsoleHelper.LogMessage("\n---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---\nIt has been a journey, my friend.\nBut at the end - you failed and have been left for dying.\nA pitty {0} {1} have killed you ...\nNo mercy from the gods.", monster.Title, monster.Name);
			Campaign.HandleEndGame();
		}

		private static void AddExperience(uint exp)
		{
			GameInstance.Instance.CurrentPlayer.Experience += exp;
			ConsoleHelper.LogUserMessage("{0} points of experience acquired!", exp);

			if (GameInstance.Instance.CurrentPlayer.Experience >= GameInstance.Instance.CurrentPlayer.NextLevel)
			{
				Campaign.ProcessLevelUp();
			}
			else
			{
				Console.WriteLine("{0} more points until the next level!", GameInstance.Instance.CurrentPlayer.NextLevel - GameInstance.Instance.CurrentPlayer.Experience);
			}
		}
	}
}