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

        public int PotionEffect()
        {
            if (IsUsable)
            {
                Console.WriteLine($"Your health was increased by 20.");
                return 20;
            }
            else
            {
                Console.WriteLine($"Your health was decreased by 10.");
                return -10;
            }
        }
    }
}
