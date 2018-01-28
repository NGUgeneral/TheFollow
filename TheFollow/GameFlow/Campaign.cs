using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models;
using TheFollow.Models.Interfaces;
using TheFollow.Models.Wrappers;
using TheFollow.StaticHelpers;

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
            GameInstance.Instance.CurrentPlayer.EquipAllItems();
            Console.WriteLine("\nPlease - remember, any time you need help with the commands print '-h'");
            ConsoleHelpers.UserMessage("\nSo, {0}, your journey has begun.", GameInstance.Instance.CurrentPlayer.Name);

            HandleSwitchQuest();
            
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
            GameInstance.Instance.CurrentGameData.Replay = ConsoleHelpers.FilterInput("Would you like to replay? (y/n)", new ConsoleKey[] { ConsoleKey.Y, ConsoleKey.N }) == ConsoleKey.Y ? true : false;
        }

        private static void StartDay()
        {
            var player = GameInstance.Instance.CurrentPlayer;
            Console.WriteLine("\nNew day. What will it bring?");
            ConsoleHelpers.LogUserMessage("Current health is {0}hp", BodyStats.GetTotalHealth(GameInstance.Instance.CurrentPlayer));
            ConsoleHelpers.FilterInput("Press enter to make a move and see what this day brought you", new ConsoleKey[]{ ConsoleKey.Enter });

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
            ConsoleHelpers.LogEnemyMessage("You have encountered a monster. It is an {0} {1}", monster.Title, monster.Name);
            ConsoleHelpers.FilterInput("\nPress enter to face the enemy.", new ConsoleKey[] { ConsoleKey.Enter });
            while (monster.Alive)
            {
                BattleTurn(ref monster);
                if (!GameInstance.Instance.CurrentPlayer.Alive) { HandleDeath(monster); break; }
            }

            if (GameInstance.Instance.CurrentPlayer.Alive) ProcessVictory(monster);
        }

        private static void BattleTurn(ref Monster monster)
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
                ConsoleHelpers.LogMessage("You hitted {0} for {1}", monster.Name, GameInstance.Instance.CurrentPlayer.AttackStrength);
                if (bodyPartToAttack.Health <= 0) ConsoleHelpers.LogMessage("You have crushed the {0}s {1}", monster.Name, bodyPartToAttack.Title);
                ConsoleHelpers.LogEnemyMessage("Monster have {0}hp left overral", BodyStats.GetTotalHealth(monster));
                if (BodyStats.GetTotalHealth(monster) <= 0) monster.Alive = false;
            }
        }

        private static void AttackPlayer(ref Monster monster)
        {
            var bodyPartToAttack = GameInstance.Instance.CurrentPlayer.Body.FirstOrDefault(x => x.Health > 0);
            if (bodyPartToAttack != null)
            {
                bodyPartToAttack.Health -= monster.AttackStrength;
                ConsoleHelpers.LogMessage("Monster hitted your {0} for {1}", bodyPartToAttack.Title, monster.AttackStrength);
                if (bodyPartToAttack.Health <= 0) ConsoleHelpers.LogMessage("Your {0}s has been crushed", bodyPartToAttack.Title);
                ConsoleHelpers.LogUserMessage("You have {0}hp left overral", BodyStats.GetTotalHealth(GameInstance.Instance.CurrentPlayer));
                if (BodyStats.GetTotalHealth(GameInstance.Instance.CurrentPlayer) <= 0)
                {
                    GameInstance.Instance.CurrentPlayer.Alive = false;
                }
            }
        }

        private static void ProcessVictory(Monster monster)
        {
            ConsoleHelpers.LogMessage("Congratulations! You have slain the {0} {1}", monster.Title, monster.Name);
            ConsoleHelpers.LogUserMessage("You have {0}hp left.", BodyStats.GetTotalHealth(GameInstance.Instance.CurrentPlayer));
            AddExperience(1);
        }

        private static void HandleDeath(Monster monster)
        {
            ConsoleHelpers.LogMessage("\n---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---\nIt has been a journey, my friend.\nBut at the end - you failed and have been left for dying.\nA pitty {0} {1} have killed you ...\nNo mercy from the gods.", monster.Title, monster.Name);
            HandleEndGame();
        }

        private static void AddExperience(uint exp)
        {
            GameInstance.Instance.CurrentPlayer.Experience += exp;
            ConsoleHelpers.LogUserMessage("{0} points of experience acquired!", exp);

            if (GameInstance.Instance.CurrentPlayer.Experience >= GameInstance.Instance.CurrentPlayer.NextLevel)
            {
                ProcessLevelUp();
            }
            else
            {
                Console.WriteLine("{0} more points until the next level!", GameInstance.Instance.CurrentPlayer.NextLevel - GameInstance.Instance.CurrentPlayer.Experience);
            }

        }

        private static void ProcessLevelUp()
        {
            foreach (var b in GameInstance.Instance.CurrentPlayer.Body)
            {
                b.MaxHealth += 1;
            }
            GameInstance.Instance.CurrentPlayer.AttackStrength += 1;
            GameInstance.Instance.CurrentPlayer.PartialRegenerate(1);

            GameInstance.Instance.CurrentPlayer.Level += 1;
            GameInstance.Instance.CurrentPlayer.NextLevel += 10;
            ConsoleHelpers.UserMessage("Congratulations! You gained a level up! Current level is {0}", GameInstance.Instance.CurrentPlayer.Level);
        }
    }
}
