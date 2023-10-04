using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Delver.Models
{
    internal class Room
    {
        public string Description { get; set; }

        public List<Item> ItemsInRoom { get; set; }

        public List<NPC> NPCsInRoom { get; set; }

        public Room(string description)
        {
            Description= description;
            ItemsInRoom = new List<Item>();
            NPCsInRoom = new List<NPC>();
        }

        public void EnterRoom(Player player)
        {
            Console.WriteLine($"\n{player.Name} has entered the {Description} room.\n");
            Console.WriteLine("NPC:s in room: ");
            Console.WriteLine("***************\n");

            foreach (NPC npc in NPCsInRoom)
            {
                Console.WriteLine(npc.ToString());
                Console.WriteLine("***************\n");
            }
        }
    }
}
