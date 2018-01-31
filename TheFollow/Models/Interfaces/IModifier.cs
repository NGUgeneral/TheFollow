using TheFollow.Models.Interfaces;

namespace TheFollow.Models
{
	internal interface IModifier
	{
		ModifierType Perk { get; set; }
		int Value { get; set; }
	}
}