using System;
using System.Collections.Generic;
using TheFollow.Helpers;
using TheFollow.Models.BodyParts;
using TheFollow.Models.Interfaces;

namespace TheFollow.Models
{
	internal class Monster : IInhabitant, IEnemy
	{
		public string Id { get; set; }
		public bool Npc { get; set; }
		public int Level { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
		public bool Alive { get; set; }
		public int AttackStrength { get; set; }
		public List<Item> Inventory { get; set; }
		public List<BodyPart> Body { get; set; }
		public List<BodyPartType> CanAttack { get; set; }

		public Monster()
		{
			Id = "Monster_" + Guid.NewGuid();
			Npc = true;
			Level = GameInstance.Instance.CurrentPlayer.Level;
			Name = Pools.GetMonsterName();
			Title = Pools.GetTitleForLevel(Level);
			Alive = true;
			AttackStrength = Level;
			Body = new List<BodyPart>
						{
								new BodyPart(BodyPartType.RightHand, false, 1 + Level, 1 + Level),
								new BodyPart(BodyPartType.LeftHand, false, 1 + Level, 1 + Level),
								new BodyPart(BodyPartType.RightHand, false, 2 + Level, 2 + Level),
								new BodyPart(BodyPartType.LeftHand, false, 2 + Level, 2 + Level),
								new BodyPart(BodyPartType.LowerBody, false, 3 + Level, 3 + Level),
								new BodyPart(BodyPartType.UpperBody, true, 4 + Level, 4 + Level),
								new BodyPart(BodyPartType.Head, true, 0 + Level, 0 + Level)
						};
			CanAttack = new List<BodyPartType>();

			for (int i = 1; i <= Enum.GetNames(typeof(BodyPartType)).Length; i++)
			{
				CanAttack.Add((BodyPartType)i);
			}
		}
	}
}