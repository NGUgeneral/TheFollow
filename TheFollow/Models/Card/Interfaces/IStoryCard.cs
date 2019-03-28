using System.Collections.Generic;

namespace TheFollow.Models.Card.Interfaces
{
	public interface IStoryCard
	{
		List<StoryCardRequirement> Requirements { get; }

	}
}