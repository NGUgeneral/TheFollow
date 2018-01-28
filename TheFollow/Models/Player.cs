using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models.BodyParts;
using TheFollow.StaticHelpers;

namespace TheFollow.Models
{
    internal class Player : IInhabitant
    {
        public string Id { get; set; }
        public bool Npc { get; set ; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Alive { get; set; }
        public int AttackStrength { get; set; }
        public IEnumerable<IItem> Inventory { get; set; }
        public IEnumerable<IHealth> Body { get; set; }

        public uint Experience { get; set; }
        public uint NextLevel { get; set; }

        internal Player(string name)
        {
            Id = "Player_" + Guid.NewGuid();
            Npc = false;
            Level = 1;
            Name = name;
            Title = Pools.GetTitleForLevel(Level);
            Experience = 0;
            AttackStrength = 2;
            NextLevel = 10;
            Alive = true;
            Body = new List<IHealth>
            {
                new BodyPart("Head", true, 3, 3),
                new BodyPart("Torso", true, 10, 10),
                new BodyPart("Right hand", false, 4, 4),
                new BodyPart("Left hand", false, 4, 4),
                new BodyPart("Right leg", false, 5, 5),
                new BodyPart("Left leg", false, 5, 5)
            };
        }

        internal void Regenerate()
        {
            Regenerate_Action();
        }

        private void Regenerate_Action()
        {
            foreach (var bodyPart in Body)
            {
                bodyPart.Health = bodyPart.MaxHealth;
            }
        }

        internal void PartialRegenerate(int buff = 0)
        {
            PartialRegenerate_Action(buff);
            Console.WriteLine("You have healed up a little bit.");
            ConsoleHelpers.LogUserMessage("Current health is {0}hp", BodyStats.GetTotalHealth(this));
        }

        private void PartialRegenerate_Action(int buff)
        {
            foreach (var bodyPart in Body)
            {
                if(bodyPart.Health < bodyPart.MaxHealth) bodyPart.Health += (bodyPart.MaxHealth - bodyPart.Health)/(3 - buff);
            }
        }
    }
}
