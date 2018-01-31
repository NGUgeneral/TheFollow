using System.Collections.Generic;
using TheFollow.Models.BodyParts;

namespace TheFollow.Models
{
	internal interface IInhabitant
	{
		string Id { get; set; }
		bool Npc { get; set; }
		int Level { get; set; }
		string Name { get; set; }
		string Title { get; set; }
		bool Alive { get; set; }
		int AttackStrength { get; set; }
		List<Item> Inventory { get; set; }
		List<BodyPart> Body { get; set; }
	}
}