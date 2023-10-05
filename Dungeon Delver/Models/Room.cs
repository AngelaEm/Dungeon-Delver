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

        public List<Item>? ItemsInRoom { get; set; }

        public List<NPC>? NPCsInRoom { get; set; }

        public Room(string description)
        {
            Description= description;
            ItemsInRoom = new List<Item>();
            NPCsInRoom = new List<NPC>();
        }

        public void EnterRoom(Player player)
        {
            if (Description == "Blue")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (Description == "Red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (Description == "Yellow")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (Description == "Black")
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (Description == "Gold")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            Console.WriteLine($"\n{player.Name} has entered the {Description} room.\n");
            Console.WriteLine("NPC:s in room: ");
            Console.WriteLine("***************\n");

            foreach (NPC npc in NPCsInRoom)
            {
                Console.WriteLine(npc.ToString());
                Console.WriteLine("***************\n");
            }
            Console.WriteLine("Items in room:\n");
            Console.WriteLine("***************\n");

            foreach (var item in ItemsInRoom)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ResetColor();
        }
    }
}
