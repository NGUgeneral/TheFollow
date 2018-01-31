﻿using System;
using System.Collections.Generic;
using System.Linq;
using TheFollow.Models;
using TheFollow.Models.Interfaces;
using TheFollow.Models.Wrappers;

namespace TheFollow.Helpers
{
	internal static class Pools
	{
		#region EnemyTitles

		private static List<Title> TitlesLibrary = new List<Title>
				{
						new Title ( 1, "Skinny"),
						new Title ( 1, "Drunk"),
						new Title ( 1, "Pale"),
						new Title ( 1, "Silly"),
						new Title ( 1, "Goofy"),
						new Title ( 1, "Foolish"),
						new Title ( 1, "Pathetic"),
						new Title ( 1, "Sick"),
						new Title ( 1, "Stupid"),

						new Title ( 2, "Short"),
						new Title ( 2, "Young"),
						new Title ( 2, "Confused"),
						new Title ( 2, "Annoying"),
						new Title ( 2, "Irritative"),
						new Title ( 2, "Troublesome"),
						new Title ( 2, "Jokish"),
						new Title ( 2, "Dull"),
						new Title ( 2, "Idiotic"),
						new Title ( 2, "Moronic"),
						new Title ( 2, "Scared"),

						new Title (3, "Brave"),
						new Title (3, "Plucky"),
						new Title (3, "Courageous"),
						new Title (3, "Daring"),
						new Title (3, "Bold"),
						new Title (3, "Seasoned"),
						new Title (3, "Sophisticated"),
						new Title (3, "Tall"),
						new Title (3, "Not so bad"),

						new Title (4, "Mad"),
						new Title (4, "Veteran"),
						new Title (4, "Wise"),
						new Title (4, "Smart"),

						new Title (5, "Bloodlust"),

						new Title (6, "Frightening"),

						new Title (7, "Epic"),

						new Title (8, "Historic"),

						new Title (9, "Heroic"),

						new Title (10, "Legendary")
				};

		#endregion EnemyTitles

		#region EnemyNames

		private static List<string> MonsterNamesLibrary = new List<string>
				{
						"Rat",
						"Goo",
						"Thief",
						"Gremlin",
						"Davy Jones",
						"Chupacabra",
						"Manticore",
						"Banshee",
						"Poltergeist",
						"Revenant",
						"Headless Horseman",
						"Zombie",
						"Yeti",
						"Mummy",
						"Orc",
						"Goblin",
						"Golem",
						"Werewolf",
						"Godzilla",
						"Cerberus",
						"Siren",
						"Succubus",
						"Incubus",
						"Cyclops",
						"Sasquatch",
						"Nandi bear",
						"Rakshasa",
						"Basilisk",
						"Changeling",
						"Vampire",
						"Windigo"
				};

		#endregion EnemyNames

		#region Items

		private static List<Item> Items = new List<Item>()
				{
						new Item()
						{
								Id="TribalSword",
								Type = ItemType.AttackGear,
								Slot = ItemSlot.RightHand,
								Weight = 2,
								Ranged = false,
								Description = "A traditional small, one handed sword of your tribe. Your father helped you to craft it.",
								Modifiers = new List<Modifier>
								{
										new Modifier
										{
												Perk = ModifierType.Attack,
												Value = 1
										}
								}
						},
						new Item()
						{
								Id="TribalShield",
								Type = ItemType.Shield,
								Slot = ItemSlot.LeftHand,
								Weight = 2,
								Ranged = false,
								Description = "Tribal Shield",
								Modifiers = new List<Modifier>
								{
										new Modifier
										{
												Perk = ModifierType.Defense,
												Value = 1
										}
								}
						},
						new Item()
						{
								Id="TribalBow",
								Type = ItemType.AttackGear,
								Slot = ItemSlot.Hands,
								Weight = 3,
								Ranged = true,
								Description = "Tribal Bow",
								Modifiers = new List<Modifier>
								{
										new Modifier
										{
												Perk = ModifierType.Attack,
												Value = 2
										}
								}
						},
						new Item()
						{
								Id="TribalOutfit",
								Type = ItemType.DefenseGear,
								Slot = ItemSlot.UpperBody,
								Weight = 2,
								Ranged = false,
								Description = "A traditional outfit of your tribe.",
								Modifiers = new List<Modifier>
								{
										new Modifier
										{
												Perk = ModifierType.Defense,
												Value = 1
										}
								}
						},
						new Item()
						{
								Id="TribalHelmet",
								Type = ItemType.DefenseGear,
								Slot = ItemSlot.Head,
								Weight = 1,
								Ranged = false,
								Description = "A traditional mask of the warriors from your tribe.",
								Modifiers = new List<Modifier>
								{
										new Modifier
										{
												Perk = ModifierType.Defense,
												Value = 1
										}
								}
						},
						new Item()
						{
								Id="TribalWaistband",
								Type = ItemType.DefenseGear,
								Slot = ItemSlot.LowerBody,
								Weight = 1,
								Ranged = false,
								Description = "A traditional wais outfit of warriors of your tribe.",
								Modifiers = new List<Modifier>
								{
										new Modifier
										{
												Perk = ModifierType.Defense,
												Value = 1
										}
								}
						},
						new Item()
						{
								Id="TribalBoot_R",
								Type = ItemType.DefenseGear,
								Slot = ItemSlot.RightBoot,
								Weight = 1,
								Ranged = false,
								Description = "Tribal boot - right",
								Modifiers = new List<Modifier>
								{
										new Modifier
										{
												Perk = ModifierType.Defense,
												Value = 1
										}
								}
						},
						new Item()
						{
								Id="TribalBoot_L",
								Type = ItemType.DefenseGear,
								Slot = ItemSlot.LeftBoot,
								Weight = 1,
								Ranged = false,
								Description = "Tribal boot - left",
								Modifiers = new List<Modifier>
								{
										new Modifier
										{
												Perk = ModifierType.Defense,
												Value = 1
										}
								}
						},
						new Item()
						{
								Id="TribalBracer_R",
								Type = ItemType.DefenseGear,
								Slot = ItemSlot.RightHand,
								Weight = 1,
								Ranged = false,
								Description = "Tribal bracer R",
								Modifiers = new List<Modifier>
								{
										new Modifier
										{
												Perk = ModifierType.Defense,
												Value = 1
										}
								}
						},
						new Item()
						{
								Id="TribalBracer_L",
								Type = ItemType.DefenseGear,
								Slot = ItemSlot.LeftHand,
								Weight = 1,
								Ranged = false,
								Description = "Tribal bracer L",
								Modifiers = new List<Modifier>
								{
										new Modifier
										{
												Perk = ModifierType.Defense,
												Value = 1
										}
								}
						},
						new Item()
						{
								Id="TribalBracer_Heavy_R",
								Type = ItemType.DefenseGear,
								Slot = ItemSlot.RightHand,
								Weight = 2,
								Ranged = false,
								Description = "Heavy Tribal bracer",
								Modifiers = new List<Modifier>
								{
										new Modifier
										{
												Perk = ModifierType.Defense,
												Value = 2
										}
								}
						},
						new Item()
						{
								Id="TribalAmulet",
								Type = ItemType.Charm,
								Slot = ItemSlot.UpperBody,
								Weight = -2,
								Ranged = false,
								Description = "Amulet of old gods",
								Modifiers = new List<Modifier>()
						},
						new Item()
						{
								Id="TribalTattoo",
								Type = ItemType.Permanent,
								Slot = ItemSlot.UpperBody,
								Weight = -1,
								Ranged = false,
								Description = "Mark of a warrior of your tribe.",
								Modifiers = new List<Modifier>
								{
								}
						}
				};

		#endregion Items

		public static string GetTitleForLevel(int level)
		{
			var titles = TitlesLibrary.Where(x => x.Level == level).ToList();
			var r = Dice.random.Next(0, titles.Count);
			return titles[r].Value;
		}

		internal static string GetMonsterName()
		{
			var r = Dice.random.Next(0, MonsterNamesLibrary.Count);
			return MonsterNamesLibrary[r];
		}

		internal static Monster GetMonster()
		{
			return new Monster();
		}

		internal static Item GetItemById(string id)
		{
			return GetItemUniqueDuplicate(Items.SingleOrDefault(x => x.Id == id));
		}

		private static Item GetItemUniqueDuplicate(Item item)
		{
			return new Item
			{
				Id = item.Id + Guid.NewGuid(),
				Type = item.Type,
				Slot = item.Slot,
				Weight = item.Weight,
				Ranged = item.Ranged,
				Description = item.Description,
				Modifiers = item.Modifiers
			};
		}
	}
}