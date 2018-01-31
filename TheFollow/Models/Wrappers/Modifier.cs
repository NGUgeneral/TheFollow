using TheFollow.Models.Interfaces;

namespace TheFollow.Models.Wrappers
{
	internal class Modifier : IModifier
	{
		public ModifierType Perk { get; set; }
		public int Value { get; set; }
	}
}