using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models;

namespace TheFollow.StaticHelpers
{
    internal static class Beastiary
    {
        internal static List<string> MonsterDictionary = new List<string>
        {
            "Rat",
            "Goo",
            "Thief"
        };

        internal static string GetMonsterName()
        {   
            var r = Dice.random.Next(0, MonsterDictionary.Count);
            return MonsterDictionary[r];
        }

        internal static Monster GetMonster()
        {
            return new Monster();
        }
    }
}
