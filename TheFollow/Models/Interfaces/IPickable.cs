using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFollow.Models.Interfaces
{
    internal interface IPickable
    {
        uint PickWeight { get; set; }
        uint MinPickChance { get; set; }
        uint MaxPickChance { get; set; }
    }
}
