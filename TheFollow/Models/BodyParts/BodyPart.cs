using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public Item HoldaleItem { get; set; }
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

        public void EquipItem(string id)
        {
            var itemIndex = GameInstance.Instance.CurrentPlayer.Inventory.IndexOf(GameInstance.Instance.CurrentPlayer.Inventory.SingleOrDefault(x => x.Id == id));
            var item = GameInstance.Instance.CurrentPlayer.Inventory[itemIndex];
            foreach (var perk in item.Modifiers.Where(x => x.Perk == ModifierType.Attack))
            {
                GameInstance.Instance.CurrentPlayer.AttackStrength += perk.Value;
            }

            foreach (var perk in item.Modifiers.Where(x => x.Perk == ModifierType.Defense))
            {
                this.Defense += perk.Value;
            }

            item.Equiped = true;
        }

        public void TakeOffItem(string id)
        {
            var itemIndex = GameInstance.Instance.CurrentPlayer.Inventory.IndexOf(GameInstance.Instance.CurrentPlayer.Inventory.SingleOrDefault(x => x.Id == id));
            var item = GameInstance.Instance.CurrentPlayer.Inventory[itemIndex];
            foreach (var perk in item.Modifiers.Where(x => x.Perk == ModifierType.Attack))
            {
                GameInstance.Instance.CurrentPlayer.AttackStrength -= perk.Value;
            }

            foreach (var perk in item.Modifiers.Where(x => x.Perk == ModifierType.Defense))
            {
                this.Defense -= perk.Value;
            }

            item.Equiped = false;
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
