using System.Collections.Generic;
using System.Linq;
using TheFollow.Models.Interfaces;

namespace TheFollow.Models
{
	internal class Item : IItem
	{
		public string Id { get; set; }
		public ItemType Type { get; set; }
		public ItemSlot Slot { get; set; }
		public int Weight { get; set; }
		public bool Ranged { get; set; }
		public bool TwoHanded { get; set; }
		public bool Equiped { get; set; }
		public string Description { get; set; }
		public IEnumerable<IModifier> Modifiers { get; set; }
		public int ThrowAttack { get => Weight + Modifiers.Where(x => x.Perk == ModifierType.Attack).Sum(x => x.Value); }
	}
}