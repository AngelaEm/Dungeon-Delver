using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Delver.Models
{
    internal class Potion : Item
    {
        public Potion(string name, string description, bool isUsable)
        {
            Name = name;
            Description = description;
            IsUsable = isUsable;
        }
        
    }
}
