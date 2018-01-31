using TheFollow.GameFlow;

namespace TheFollow
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			while (GameInstance.Instance.CurrentGameData == null ? true : GameInstance.Instance.CurrentGameData.Replay)
			{
				Campaign.LaunchInterface();
			}
		}
	}
}