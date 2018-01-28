using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models.Interfaces;
using TheFollow.Models.Wrappers;

namespace TheFollow.StaticHelpers
{
    internal static class Navigation
    {
        internal static EventType PickEvent(IEnumerable<EventWeight> events)
        {
            return PickEvent_Action(events);
        }

        private static EventType PickEvent_Action(IEnumerable<EventWeight> events)
        {
            uint total = (uint)events.Sum(x => x.Weight);
            uint currentPickChance = 0;

            foreach(var e in events)
            {
                e.MinPickChance = currentPickChance;
                e.MaxPickChance = currentPickChance + e.Weight;
                currentPickChance = e.MaxPickChance;
            }

            var throwRes = Dice.random.Next(0, (int)currentPickChance + 1);
            return events.SingleOrDefault(x =>  throwRes >= x.MinPickChance && throwRes < x.MaxPickChance).Event;
        }
    }
}
