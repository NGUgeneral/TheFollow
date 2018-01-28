using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models.Interfaces;
using TheFollow.StaticHelpers;

namespace TheFollow.Models.Wrappers
{
    internal class EventWeight : IPickable 
    {
        public EventType Event { get; set; }
        public uint PickWeight { get; set; }
        public uint MinPickChance { get; set; }
        public uint MaxPickChance { get; set; }

        internal static EventType Pick(IEnumerable<IPickable> events)
        {
            return (Picker<EventWeight>.Pick_Action(events) as EventWeight).Event;
        }
    }
}
