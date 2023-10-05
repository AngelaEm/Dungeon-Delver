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

        public int Experience { get; set; } 
        public bool IsAlive
        {
            get
            {
                if (Health > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               
            }

            set { IsAlive = value; }
        } 
                
               
        public int Health { get; set; }
        public int Dmg { get; set; }

    }
}
