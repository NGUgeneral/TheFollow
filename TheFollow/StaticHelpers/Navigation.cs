using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models.Interfaces;

namespace TheFollow.StaticHelpers
{
    internal static class Navigation
    {
        internal static EventType MakeAMove()
        {   
            while (true)
            {
                if (Dice.ThrowDice(0, 6, 5)) return EventType.VillageAproach;
                if (Dice.ThrowDice(0, 6, 5)) return EventType.None;
                if (Dice.ThrowDice(0, 6, 2)) return EventType.MonsterEncounter;
            }
        }
    }
}
