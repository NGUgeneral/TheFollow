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
            var typesAmount = Enum.GetNames(typeof(EventType)).Length;
            var index = Dice.random.Next(1, typesAmount + 1);

            while (true)
            {
                if (Dice.ThrowDice(0, 6, 3)) return (EventType)index;
                index = index >= typesAmount ? 1 : index + 1;
            }
        }
    }
}
