using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Delver.Models
{
    internal abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsUsable { get; set; }

        public override string ToString()
        {
            return  $"\nItem: {Name}\nDescription: {Description}\n";
        }

        public int PotionEffect(Item item)
        {
            if (item.IsUsable)
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
