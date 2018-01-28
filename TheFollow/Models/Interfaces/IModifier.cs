using TheFollow.Models.Interfaces;

namespace TheFollow.Models
{
    interface IModifier
    {
        ModifierType Perk { get; set; }
        int Value { get; set; }
    }
}