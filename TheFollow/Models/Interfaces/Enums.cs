using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFollow.Models.Interfaces
{
    internal enum ItemType
    {
        HeadGear = 1,
        BodyPlate = 2,
        Gloves = 3,
        Legins = 4,
        Boots = 5,
        Weapon = 6,
        TwoHandedWeapon = 7,
        Shield = 8,
        Amulet = 9,
        Consumable = 10
    }

    internal enum EventType
    {
        MonsterEncounter = 1,
        VillageAproach = 2,
        None = 3
    }
}
