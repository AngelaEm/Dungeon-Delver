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
            return  Name;
        }

    }
}
