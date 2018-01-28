using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Helpers;
using TheFollow.Models;

namespace TheFollow
{
    internal class GameInstance
    {
        private static readonly GameInstance instance = new GameInstance();
        internal Player CurrentPlayer { get; set; }
        private static bool Replay = true;

        private GameInstance() { }

        internal static GameInstance Instance
        {
            get
            {
                return instance;
            }
        }

        internal static void UpdateReplay(bool replay)
        {
            Replay = replay;
        }

        internal static bool GetReplay()
        {
            return Replay;
        }
    }
}
