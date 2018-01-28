using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFollow.Models.BodyParts
{
    internal class BodyPart : IHealth
    {
        public string Title { get; set; }
        public bool Vital { get; set; }
        public int Defense { get; set; }
        private int _health;
        public int Health { get => _health < 0 ? 0 : _health; set => _health = value; }
        public int MaxHealth { get; set; }

        internal BodyPart(string title, bool vital, int health, int maxHealth)
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
