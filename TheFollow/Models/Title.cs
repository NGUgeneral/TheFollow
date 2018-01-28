using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFollow.Models
{
    internal class Title
    {
        public int Level { get; }
        public string Value { get; }

        public Title(int level, string value)
        {
            Level = level;
            Value = value;
        }
    }
}
