using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFollow.Models.Interfaces;

namespace TheFollow.Models
{
    interface IHealth
    {
        BodyPartType Title { get; set; }
        bool Vital { get; set; }
        int Defense { get; set; }
        
        int Health { get; set; }
        int MaxHealth { get; set; }

        void HealthAdd(int value);
        void HealthSub(int value);
        bool HealthCheck();
    }
}
