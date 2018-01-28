using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models;

namespace TheFollow.StaticHelpers
{
    internal static class BodyStats
    {
        internal static int GetTotalHealth(IInhabitant inhabitant)
        {
            return inhabitant.Body.Sum(x => x.Health);
        }
    }
}
