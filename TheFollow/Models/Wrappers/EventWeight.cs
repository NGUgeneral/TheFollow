using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models.Interfaces;

namespace TheFollow.Models.Wrappers
{
    internal class EventWeight
    {
        internal EventType Event { get; set; }
        internal uint Weight { get; set; }
        internal uint MinPickChance { get; set; }
        internal uint MaxPickChance { get; set; }
    }
}
