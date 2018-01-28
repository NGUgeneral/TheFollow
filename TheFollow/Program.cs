using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Events;
using TheFollow.GameFlow;
using TheFollow.Models;
using TheFollow.StaticHelpers;

namespace TheFollow
{
    class Program
    {
        static void Main(string[] args)
        {
            while (GameInstance.Instance.CurrentGameData == null ? true : GameInstance.Instance.CurrentGameData.Replay)
            {
                Campaign.LaunchInterface();
            }
        }
    }
}
