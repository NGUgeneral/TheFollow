using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TheFollow.GameFlow;
using TheFollow.GameFlow.Quests;
using TheFollow.Helpers;
using TheFollow.Models;

namespace TheFollow
{
    internal class GameInstance    {
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
