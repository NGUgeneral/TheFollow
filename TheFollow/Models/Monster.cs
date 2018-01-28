using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models.BodyParts;
using TheFollow.StaticHelpers;

namespace TheFollow.Models
{
    internal class Monster : IInhabitant
    {
        public string Id { get; set; }
        public bool Npc { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Alive { get; set; }
        public int AttackStrength { get; set; }
        public IEnumerable<IItem> Inventory { get; set; }
        public IEnumerable<IHealth> Body { get; set; }

        public Monster()
        {
            Id = "Monster_" + Guid.NewGuid();
            Npc = true;
            Level = GameInstance.Instance.CurrentPlayer.Level;
            Name = Pools.GetMonsterName();
            Title = Pools.GetTitleForLevel(Level);
            Alive = true;
            AttackStrength = Level;
            Body = new List<IHealth>
            {
                new BodyPart("Head", true, 3, 3),
                new BodyPart("Torso", true, 10, 10)
            };
        }
    }
}
