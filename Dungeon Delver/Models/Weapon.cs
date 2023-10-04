using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Delver.Models
{
    internal class Weapon : Item
    {
        public int Dmg { get; set; }
        public Weapon(string name, string description, int dmg, bool isUsable)
        {
            Name = name;
            Description = description;
            IsUsable = isUsable;
            Dmg = dmg;
        }

    }
}
