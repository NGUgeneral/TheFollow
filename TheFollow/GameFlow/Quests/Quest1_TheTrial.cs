using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFollow.GameFlow.Quests
{
    internal class Quest1_TheTrial : Quest
    {
        public Quest1_TheTrial()
        {
            Order = 1;
            Description = "You are a young warrior of your tribe.\nAll your life so far you have prepared yourself for this day. Today is your initiation and that means that it is time for you to discover a real warrior inside of yourself.";
            Description_Start = "Reach level 3 to complete your trial.";
            Description_Finish = "Congratulations!\nYou have reached level " + Goal + " and from now on - you will be recognized as a warrior among you people.";
            Goal = 3;
        }

        public override void TryToComplete()
        {
           if(GameInstance.Instance.CurrentPlayer.Level >= Goal) HandleFinishQuest();
        }
    }
}
