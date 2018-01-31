using System.Collections.Generic;
using System.Linq;
using TheFollow.Models.Interfaces;

namespace TheFollow.Helpers
{
	internal static class Picker<T> where T : IPickable
	{
		internal static IPickable Pick_Action(IEnumerable<IPickable> events)
		{
			uint total = (uint)events.Sum(x => x.PickWeight);
			uint currentPickChance = 0;

			foreach (var e in events)
			{
				e.MinPickChance = currentPickChance;
				e.MaxPickChance = currentPickChance + e.PickWeight;
				currentPickChance = e.MaxPickChance;
			}

			var throwRes = Dice.random.Next(1, (int)currentPickChance + 1);
			return events.SingleOrDefault(x => throwRes > x.MinPickChance && throwRes <= x.MaxPickChance);
		}
	}
}