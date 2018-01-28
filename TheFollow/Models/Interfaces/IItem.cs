using System.Collections.Generic;
using TheFollow.Models.Interfaces;

namespace TheFollow.Models
{
    internal interface IItem
    {
        string Id { get; set; }
        ModifierType Type { get; set; }
        ItemTypeSpecifier Specifier { get; set; }
        BodyPartType Slot { get; set; }
        bool Ranged { get; set; }
        bool TwoHanded { get; set; }
        bool Equiped { get; set; }
        string Description { get; set; }
        IEnumerable<IModifier> Modifiers { get; set; }
    }
}