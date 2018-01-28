using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.GameFlow;
using TheFollow.GameFlow.Quests;

namespace TheFollow.Models
{
    internal class GameData
    {
        internal bool Replay { get; set; }
        internal bool Finished { get; set; }
        internal List<Quest> Quests { get; set; }
        internal int CurrentQuestIndex { get; set; }

        internal GameData()
        {
            Replay = true;
            Quests = new List<Quest>
            {
                new Quest1_TheTrial()
            };
        }
    }
}
