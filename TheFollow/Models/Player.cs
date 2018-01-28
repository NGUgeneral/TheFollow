using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models.BodyParts;
using TheFollow.Models.Interfaces;
using TheFollow.Models.Wrappers;
using TheFollow.Helpers;

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
        public List<Item> Inventory { get; set; }
        public List<BodyPart> Body { get; set; }

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
            Inventory = new List<Item>();
            Body = new List<BodyPart>
            {   
                new BodyPart(BodyPartType.RightHand, false, 4, 4),
                new BodyPart(BodyPartType.LeftHand, false, 4, 4),
                new BodyPart(BodyPartType.RightLeg, false, 5, 5),
                new BodyPart(BodyPartType.LeftLeg, false, 5, 5),
                new BodyPart(BodyPartType.Body, true, 10, 10),
                new BodyPart(BodyPartType.Head, true, 3, 3),
            };

            //Initial inventory
            Inventory.Add(Pools.GetItemById("TribalSword"));
            Inventory.Add(Pools.GetItemById("TribalOutfit"));
            Inventory.Add(Pools.GetItemById("TribalHelmet"));
        }

        internal void InitialEquip()
        {
            //foreach(var item in Inventory)
            //{
            //    var bodyPartIndex = Body.IndexOf(Body.SingleOrDefault(x => x.Title == item.Slot) as BodyPart);
            //    Body[bodyPartIndex].EquipItem(item.Id);
            //}
        }

        public void Regenerate()
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

        public void PartialRegenerate(int buff = 0)
        {
            PartialRegenerate_Action(buff);
            Console.WriteLine("You have healed up a little bit.");
            ConsoleHelper.LogUserMessage("Current health is {0}hp", BodyStats.GetTotalHealth(this));
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
