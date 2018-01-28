using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models.Interfaces;

namespace TheFollow.Models
{
    internal class Item : IItem
    {
        public string Id { get; set; }
        public ItemType Type { get; set; }
        public ItemTypeSpecifier Specifier { get; set; }
        public bool Ranged { get; set; }
        public bool TwoHanded { get; set; }
        public bool Equiped { get; set; }
        public string Description { get; set; }
        public IEnumerable<IModifier> Modifiers { get; set; }
    }
}
