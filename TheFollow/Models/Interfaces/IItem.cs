using System.Collections.Generic;
using TheFollow.Models.Interfaces;

namespace TheFollow.Models
{
    internal interface IItem
    {
        string Id { get; set; }
        ItemType Type { get; set; }
        string Description { get; set; }
        IEnumerable<IModifier> Modifiers { get; set; }
    }
}