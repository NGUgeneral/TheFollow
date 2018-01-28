using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Events;
using TheFollow.Models;
using TheFollow.StaticHelpers;

namespace TheFollow
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Start();
            }
        }

        static void Start()
        {
            Console.WriteLine("\n\n\nWelcome!\nPlease, type below the name for you character and we can start!");
            Console.Write("Pease type in you name: ");
            GameInstance.Instance.CurrentPlayer = new Player(Console.ReadLine());
            Console.WriteLine("\nSo, {0}, your journey has begun.", GameInstance.Instance.CurrentPlayer.Name);
            while (GameInstance.Instance.CurrentPlayer.Alive)
            {
                StartDay();
            }
        }

        private static void StartDay()
        {
            var player = GameInstance.Instance.CurrentPlayer;
            Console.WriteLine("\nNew day. What will it bring?");
            Console.WriteLine("Current health is {0}hp", BodyStats.GetTotalHealth(GameInstance.Instance.CurrentPlayer));
            Console.WriteLine("Press enter to make a move and see what this day brought you");
            Console.ReadKey();
            var dayEvent = Navigation.MakeAMove();
            switch (dayEvent)
            {
                case Models.Interfaces.EventType.None:
                    HandleNoneEncounter();
                    break;
                case Models.Interfaces.EventType.VillageAproach:
                    HandleVillageEncounter();
                    break;
                case Models.Interfaces.EventType.MonsterEncounter:
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
            if(Dice.ThrowDice(0,6,5))
            {
                Console.WriteLine("Gods have mercy, you saw a light while looking for firewood in the nearby forest.");
                HandleVillageEncounter();
            }
            else
            {
                if(Dice.ThrowDice(0, 6, 3))
                {
                    Console.WriteLine("You have been able to find soome fire wood in the nearby forrest.\nThe fire will help you stay safe during the night as well - you will be able to heal yourself a little bit.");
                    GameInstance.Instance.CurrentPlayer.PartialRegenerate();
                    if (Dice.ThrowDice(0, 6, 4)) HandleMonsterEncounter();
                }
                else
                {
                    if (Dice.ThrowDice(0, 6, 3)) HandleMonsterEncounter();
                }
            }
        }

        private static void HandleVillageEncounter()
        {
            Console.WriteLine("You found a village with a friendly people.\nYou feel safe enough, so you are taking your chance to have a rest from your wandering and heal you wounds.");
            GameInstance.Instance.CurrentPlayer.Regenerate();
            Console.ReadKey();
        }

        private static void HandleMonsterEncounter()
        {
            var monster = Beastiary.GetMonster();
            Console.WriteLine("You have encountered a monster. It is an {0} {1}", monster.Title,  monster.Name);
            Console.ReadKey();
            while (monster.Alive)
            {
                BattleTurn(ref monster);
                if (!GameInstance.Instance.CurrentPlayer.Alive) { ProcessDeath(monster); break; }
            }

            if (GameInstance.Instance.CurrentPlayer.Alive) ProcessVictory(monster);
        }

        private static void BattleTurn(ref Monster monster)
        {
            Console.WriteLine("\nPress enter to attack");
            Console.ReadKey();
            AttackMonster(ref monster);
            if (monster.Alive) { AttackPlayer(ref monster); }
        }

        private static void AttackMonster(ref Monster monster)
        {
            var bodyPartToAttack = monster.Body.FirstOrDefault(x => x.Health > 0);
            if(bodyPartToAttack != null)
            {
                bodyPartToAttack.Health -= GameInstance.Instance.CurrentPlayer.AttackStrength;
                Console.WriteLine("You hitted {0} for {1}", monster.Name, GameInstance.Instance.CurrentPlayer.AttackStrength);
                if (bodyPartToAttack.Health <= 0) Console.WriteLine("You have crushed the {0}s {1}", monster.Name, bodyPartToAttack.Title);
                Console.WriteLine("Monster have {0}hp left overral", BodyStats.GetTotalHealth(monster));
                if (BodyStats.GetTotalHealth(monster) <= 0) monster.Alive = false;
            }
        }

        private static void AttackPlayer(ref Monster monster)
        {
            var bodyPartToAttack = GameInstance.Instance.CurrentPlayer.Body.FirstOrDefault(x => x.Health > 0);
            if (bodyPartToAttack != null)
            {
                bodyPartToAttack.Health -= monster.AttackStrength;
                Console.WriteLine("Monster hitted your {0} for {1}", bodyPartToAttack.Title, monster.AttackStrength);
                if (bodyPartToAttack.Health <= 0) Console.WriteLine("Your {0}s has been crushed", bodyPartToAttack.Title);
                Console.WriteLine("You have {0}hp left overral", BodyStats.GetTotalHealth(GameInstance.Instance.CurrentPlayer));
                if (BodyStats.GetTotalHealth(GameInstance.Instance.CurrentPlayer) <= 0)
                {
                    GameInstance.Instance.CurrentPlayer.Alive = false;
                }
            }
        }

        private static void ProcessVictory(Monster monster)
        {
            Console.WriteLine("Congratulations! You have slain the {0} {1}", monster.Title, monster.Name);
            AddExperience(1);
            Console.ReadKey();
        }

        private static void ProcessDeath(Monster monster)
        {
            Console.WriteLine("\n---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---xxx---\nIt has been a journey, my friend.\nBut at the end - you failed and have been left for dying.\nA pitty {0} {1} have killed you ...\nNo mercy from the gods.", monster.Title, monster.Name);
        }

        private static void AddExperience(uint exp)
        {
            GameInstance.Instance.CurrentPlayer.Experience += exp;
            Console.WriteLine("{0} points of experience acquired!", exp);

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
            foreach(var b in GameInstance.Instance.CurrentPlayer.Body)
            {
                b.MaxHealth += 1;
            }
            GameInstance.Instance.CurrentPlayer.AttackStrength += 1;

            GameInstance.Instance.CurrentPlayer.Level += 1;
            GameInstance.Instance.CurrentPlayer.NextLevel += 10;
            Console.WriteLine("Congratulations! You gained a level up! Current level is {0}", GameInstance.Instance.CurrentPlayer.Level);
        }
    }
}
