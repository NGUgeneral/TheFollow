using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFollow.Models.Interfaces
{
    internal enum ItemTypeSpecifier
    {
        HeadGear = 1,
        BodyPlate = 2,
        Gloves = 3,
        Leggings = 4,
        Boots = 5,
        Amulet = 6,
        AttackGear = 7,
        DefenseGear = 9,
        None = 10
    }

    internal enum ModifierType
    {
        Attack = 1,
        Defense = 2,
        Consumable = 3
    }

    internal enum BodyPartType
    {
        Head = 1,
        Body = 2,
        RightHand = 3,
        LeftHand = 4,
        RightLeg = 5,
        LeftLeg = 6,
        RightHand_2 = 7,
        LeftHand_2 = 8,
        RightLeg_2 = 9,
        LeftLeg_2 = 10
    }

    internal enum EventType
    {
        MonsterEncounter = 1,
        VillageAproach = 2,
        None = 3
    }
}
