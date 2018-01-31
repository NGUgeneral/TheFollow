using System.Collections.Generic;
using TheFollow.Models.Interfaces;

namespace TheFollow.Models
{
	internal interface IItem
	{
		string Id { get; set; }
		ItemSlot Slot { get; set; }
		ItemType Type { get; set; }
		int Weight { get; set; }
		bool Ranged { get; set; }
		bool Equiped { get; set; }
		string Description { get; set; }
		IEnumerable<IModifier> Modifiers { get; set; }
	}
}