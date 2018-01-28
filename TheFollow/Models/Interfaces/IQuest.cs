using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFollow.Models.Interfaces
{
    interface IQuest
    {   
        bool Completed { get; set; }
        int Order { get; set; }
        string Description { get; set; }
        string Description_Start { get; set; }
        string Description_Finish { get; set; }
        int Goal { get; set; }

        void TryToComplete();
    }
}
