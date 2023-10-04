using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Delver.Models
{
    internal abstract class Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAlive { get; set; } = true;
        public int Health { get; set; }
        public int Dmg { get; set; }



    }
}
