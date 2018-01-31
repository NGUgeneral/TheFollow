using TheFollow.Models;

namespace TheFollow
{
	internal class GameInstance
	{
		private static readonly GameInstance instance = new GameInstance();
		internal Player CurrentPlayer { get; set; }
		internal GameData CurrentGameData { get; set; }

		internal static GameInstance Instance
		{
			get
			{
				return instance;
			}
		}
	}
}