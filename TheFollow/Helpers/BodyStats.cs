using System.Linq;
using TheFollow.Models;

namespace TheFollow.Helpers
{
	internal static class BodyStats
	{
		internal static int GetTotalHealth(IInhabitant inhabitant)
		{
			return inhabitant.Body.Sum(x => x.Health);
		}

		internal static void PrintBodyPartsStat(IInhabitant inhabitant)
		{
			foreach (var bodyPart in inhabitant.Body)
			{
				ConsoleHelper.LogMessage("{0}: Health - {1}/{2}hp, Defense - {3} ", bodyPart.Title, bodyPart.Health, bodyPart.MaxHealth, bodyPart.Defense);
			}
		}
	}
}