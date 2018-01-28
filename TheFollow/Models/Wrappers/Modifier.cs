using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models.Interfaces;

namespace TheFollow.Models.Wrappers
{
    internal class Modifier : IModifier
    {
        public ModifierType Perk { get; set; }
        public int Value { get; set; }
    }
}
