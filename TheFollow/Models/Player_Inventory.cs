using System.Collections.Generic;
using System.Linq;
using TheFollow.Helpers;
using TheFollow.Models.BodyParts;
using TheFollow.Models.Interfaces;

namespace TheFollow.Models
{
	internal partial class Player
	{
		public void AddItemToInventory(Item item)
		{
			Inventory.Add(item);
			ConsoleHelper.LogUserMessage("{0} for {1} has been added to you inventory", item.Type, item.Slot);
		}

		public void RemoveItemFromInventory(Item item)
		{
			UnequipItem(item);
			Inventory.Remove(item);
			ConsoleHelper.LogUserMessage("{0} for {1} has been removed from your inventory", item.Type, item.Slot);
		}

		public void EquipItem(Item item)
		{
			List<BodyPart> bodyParts = ChooseBodyParts(item);

			foreach (var perk in item.Modifiers.Where(x => x.Perk == ModifierType.Attack))
			{
				AttackStrength += perk.Value;
			}

			foreach (var bodyPart in bodyParts)
			{
				foreach (var perk in item.Modifiers.Where(x => x.Perk == ModifierType.Defense))
				{
					bodyPart.Defense += perk.Value;
				}

				if (item.Type == ItemType.AttackGear || item.Type == ItemType.Shield)
				{
					bodyPart.HoldableItem = item;
				}

				if (item.Type == ItemType.Permanent)
				{
					bodyPart.PermanentItem = item;
				}

				if (item.Type == ItemType.DefenseGear)
				{
					bodyPart.WearableItem = item;
				}
			}

			item.Equiped = true;
			ConsoleHelper.LogMessage("{0} for {1} has been equiped.", item.Type, item.Slot);
		}

		public void UnequipItem(Item item)
		{
			if (item.Type != ItemType.Permanent)
			{
				List<BodyPart> bodyParts = ChooseBodyParts(item);

				foreach (var perk in item.Modifiers.Where(x => x.Perk == ModifierType.Attack))
				{
					AttackStrength -= perk.Value;
				}

				foreach (var bodyPart in bodyParts)
				{
					foreach (var perk in item.Modifiers.Where(x => x.Perk == ModifierType.Defense))
					{
						bodyPart.Defense -= perk.Value;
					}

					if (item.Type == ItemType.AttackGear || item.Type == ItemType.Shield)
					{
						bodyPart.HoldableItem = null;
					}

					if (item.Type == ItemType.DefenseGear)
					{
						bodyPart.WearableItem = null;
					}
				}

				item.Equiped = false;
				ConsoleHelper.LogMessage("{0} for {1} has been unequiped.", item.Type, item.Slot);
			}
			else
			{
				ConsoleHelper.LogMessage("Can`t remove a permanent item");
			}
		}

		private List<BodyPart> ChooseBodyParts(Item item)
		{
			List<BodyPart> bodyParts = new List<BodyPart>();

			switch (item.Slot)
			{
				case ItemSlot.Head:
					bodyParts.Add(Body.SingleOrDefault(x => x.Title == BodyPartType.Head));
					break;

				case ItemSlot.UpperBody:
					bodyParts.Add(Body.SingleOrDefault(x => x.Title == BodyPartType.UpperBody));
					break;

				case ItemSlot.LowerBody:
					bodyParts.Add(Body.SingleOrDefault(x => x.Title == BodyPartType.LowerBody));
					break;

				case ItemSlot.Hands:
					bodyParts.Add(Body.SingleOrDefault(x => x.Title == BodyPartType.LeftHand));
					bodyParts.Add(Body.SingleOrDefault(x => x.Title == BodyPartType.RightHand));
					break;

				case ItemSlot.RightHand:
					bodyParts.Add(Body.SingleOrDefault(x => x.Title == BodyPartType.RightHand));
					break;

				case ItemSlot.LeftHand:
					bodyParts.Add(Body.SingleOrDefault(x => x.Title == BodyPartType.LeftHand));
					break;

				case ItemSlot.RightBoot:
					bodyParts.Add(Body.SingleOrDefault(x => x.Title == BodyPartType.RightLeg));
					break;

				case ItemSlot.LeftBoot:
					bodyParts.Add(Body.SingleOrDefault(x => x.Title == BodyPartType.LeftLeg));
					break;

				default:
					break;
			}
			return bodyParts;
		}

		public List<Item> GetWearedItems()
		{
			var items = Body.Select(x => x.WearableItem).Where(x => x != null).ToList();
			items.AddRange(Body.Select(x => x.HoldableItem).Where(x => x != null));
			return items;
		}
	}
}