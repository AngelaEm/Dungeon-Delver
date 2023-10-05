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

        public int ItemEffekt(Item item)
        {
            if (item.IsUsable)
            {
                Console.WriteLine($"\nThis Item was good for you and your health was increased by 30.");
                return 30;
            }
            else
            {
                Console.WriteLine($"\nThis item was bad for you and your health was decreased by 10.");
                return -10;
            }
        }

    }
}
