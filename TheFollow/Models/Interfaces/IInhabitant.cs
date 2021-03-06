﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models.BodyParts;

namespace TheFollow.Models
{
    interface IInhabitant
    {
        string Id { get; set; }
        bool Npc { get; set; }
        int Level { get; set; }
        string Name { get; set; }
        string Title { get; set; }
        bool Alive { get; set; }
        int AttackStrength { get; set; }
        List<Item> Inventory { get; set; }
        List<BodyPart> Body { get; set; }
    }
}
