using System;

namespace TheFollow.Helpers
{
	internal static class Dice
	{
		internal static Random random = new Random();

		internal static bool ThrowDice(int min, int max, int win)
		{
			var value = random.Next(min, max + 1);
			return value >= win;
		}
	}
}