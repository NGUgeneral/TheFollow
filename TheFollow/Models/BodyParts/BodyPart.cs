using TheFollow.Models.Interfaces;

namespace TheFollow.Models.BodyParts
{
	internal class BodyPart : IHealth
	{
		public string Id { get; set; }
		public BodyPartType Title { get; set; }
		public bool Vital { get; set; }
		public int Defense { get; set; }
		public bool Crushed { get => Health == 0; }
		public Item WearableItem { get; set; }
		public Item HoldableItem { get; set; }
		public Item PermanentItem { get; set; }
		private int _health;
		public int Health { get => _health < 0 ? 0 : _health; set => _health = value; }
		public int MaxHealth { get; set; }

		internal BodyPart(BodyPartType title, bool vital, int health, int maxHealth)
		{
			Title = title;
			Vital = vital;
			Health = health;
			MaxHealth = maxHealth;
		}

		public void HealthAdd(int value)
		{
			Health += value;
		}

		public void HealthSub(int value)
		{
			Health -= value;
		}

		public bool HealthCheck()
		{
			return Health > 0;
		}
	}
}