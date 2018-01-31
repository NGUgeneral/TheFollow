using TheFollow.Helpers;
using TheFollow.Models.Interfaces;

namespace TheFollow.GameFlow
{
	internal abstract class Quest : IQuest
	{
		public bool Completed { get; set; }
		public int Order { get; set; }
		public string Description { get; set; }
		public string Description_Start { get; set; }
		public string Description_Finish { get; set; }
		public int Goal { get; set; }

		public abstract void TryToComplete();

		internal void GetIntro()
		{
			ConsoleHelper.UserMessage(this.Description);
		}

		internal void GetGoalDescription()
		{
			ConsoleHelper.UserMessage("\nQuest goal:\n{0}", this.Description_Start);
		}

		internal void HandleFinishQuest()
		{
			this.Completed = true;
			GameInstance.Instance.CurrentGameData.CurrentQuestIndex += 1;
			ConsoleHelper.UserMessage(this.Description_Finish);

			if (GameInstance.Instance.CurrentGameData.CurrentQuestIndex >= GameInstance.Instance.CurrentGameData.Quests.Count)
			{
				GameInstance.Instance.CurrentGameData.Finished = true;
				Campaign.HandleEndGame();
			}
			else
			{
				Campaign.HandleSwitchQuest();
			}
		}
	}
}