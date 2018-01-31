using System.Collections.Generic;

namespace TheFollow.Models.Interfaces
{
	internal interface IEnemy
	{
		List<BodyPartType> CanAttack { get; set; }
	}
}