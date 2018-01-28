using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFollow.Models.Interfaces
{
    internal enum ItemType
    {
        Plates = 1,
        Weapon = 2,
        Consumable = 3
    }

    internal enum ItemTypeSpecifier
    {
        HeadGear = 1,
        BodyPlate = 2,
        Gloves = 3,
        Legins = 4,
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
        Heal = 3
    }

    internal enum EventType
    {
        MonsterEncounter = 1,
        VillageAproach = 2,
        None = 3
    }
}
