using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models;

namespace TheFollow.StaticHelpers
{
    internal static class Pools
    {
        private static List<Title> TitlesLibrary = new List<Title>
        {
            new Title ( 1, "Skinny"),
            new Title ( 1, "Drunk"),
            new Title ( 1, "Pale"),

            new Title ( 2, "Short"),
            new Title ( 2, "Young"),
            new Title ( 2, "Confused"),

            new Title (3, "Brave"),

            new Title (4, "Mad"),

            new Title (5, "Bloodlust"),

            new Title (6, "Frightening"),

            new Title (7, "Epic"),

            new Title (8, "Historic"),

            new Title (9, "Heroic"),

            new Title (10, "Legendary")
        };
        internal static List<string> MonsterNamesLibrary = new List<string>
        {
            "Rat",
            "Goo",
            "Thief"
        };

        public static string GetTitleForLevel(int level)
        {
            var titles = TitlesLibrary.Where(x => x.Level == level).ToList();
            var r = Dice.random.Next(0, titles.Count);
            return titles[r].Value;
        }

        internal static string GetMonsterName()
        {
            var r = Dice.random.Next(0, MonsterNamesLibrary.Count);
            return MonsterNamesLibrary[r];
        }

        internal static Monster GetMonster()
        {
            return new Monster();
        }
    }
}
