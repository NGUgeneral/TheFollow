namespace TheFollow.Models.Interfaces
{
	internal enum ItemSlot
	{
		Head = 1,
		UpperBody = 2,
		LowerBody = 3,
		RightHand = 4,
		LeftHand = 5,
		Hands = 6,
		RightBoot = 7,
		LeftBoot = 8,
		Amulet = 9,
		None = 10
	}

	internal enum ItemType
	{
		AttackGear = 1,
		DefenseGear = 2,
		Shield = 3,
		Charm = 4,
		Permanent = 5
	}

	internal enum ModifierType
	{
		Attack = 1,
		Defense = 2,
		Weight = 3,
		Consumable = 4
	}

	internal enum BodyPartType
	{
		Head = 1,
		UpperBody = 2,
		LowerBody = 3,
		RightHand = 4,
		LeftHand = 5,
		RightLeg = 6,
		LeftLeg = 7
	}

	internal enum EventType
	{
		MonsterEncounter = 1,
		VillageAproach = 2,
		None = 3
	}

	internal enum RetreatCondition
	{
		Rob = 1,
		Run = 2,
		Depress = 3,
		Limb = 4
	}
}