using TheFollow.Models.Interfaces;

namespace TheFollow.Models
{
	internal interface IHealth
	{
		BodyPartType Title { get; set; }
		bool Vital { get; set; }
		int Defense { get; set; }

		int Health { get; set; }
		int MaxHealth { get; set; }

		void HealthAdd(int value);

		void HealthSub(int value);

		bool HealthCheck();
	}
}