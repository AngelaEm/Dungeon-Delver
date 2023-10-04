using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Delver.Models
{
    internal class Key : Item
    {
        public Key(string name, string description, bool isUsable)
        {
            Name = name;
            Description = description;
            IsUsable = isUsable;

        }
    }
}
