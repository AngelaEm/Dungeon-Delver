using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Delver.Models
{
    internal class Player : Entity
    {
        public List<Item> Inventory { get; set; }

        public List<Item> KeyRing { get; set; }
        public int Dexterity { get; set; } 
        public int Strength { get; set; } 
        public int Level { get; set; } 
       


        public Player(string name, string description)
        {
            Name = name;
            Description = description;
            Health = 100;
            Level = 1;
            Dexterity= 10;
            Strength = 10;       
            Inventory = new List<Item>();
            Experience = 0;
            Dmg = 10;
            KeyRing = new List<Item>();
        }

        public int TakeDamage(Potion potion)
        {
            return Health += potion.PotionEffect();
        }
        public void PickUpItem(Item item)
        {
           Inventory.Add(item);
        }

        public void PickUpKey(NPC npc)
        {
            if (npc.NPCitems.Count > 0)
            {
                KeyRing.Add(npc.NPCitems[0]);
            }
           
        }

        public void ChooseItemsInRoom(Room room)
        {
            Console.WriteLine("\nPress any key to get three random items from this room\n");

            Random r = new Random();
            if (room.ItemsInRoom.Count > 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    int item = r.Next(room.ItemsInRoom.Count);
                    Console.WriteLine($"{room.ItemsInRoom[item]}");
                    PickUpItem(room.ItemsInRoom[item]);
                    room.RemoveItemFromRoom(room.ItemsInRoom[item]);

                }
            }
            else
            {
                Console.WriteLine("Sorry, no more items for you to pick up.");
            }
            

            Console.ReadKey();
        }

        public void UseItem(Potion potion)
        {
            Health += potion.PotionEffect();
            Inventory.Remove(potion);

            if (Health < 1)
            {
                IsAlive = false;
                Console.WriteLine($"You are dead {Name}. Better luck next time.");
            }
          
        }
        public void UseItem(Weapon weapon)
        {        
            Dmg = weapon.Dmg;
        }
        public void Attack(NPC npc)
        {
            npc.Health -= (Dmg + Strength);
            
        }
        public int PlayerAttackDmg()
        {
            return Dmg + Strength;
        }

        public void SeeItemsInBag()
        {
            foreach (var item in Inventory)
            {
                Console.WriteLine(item.ToString());
            }
            foreach (var item in KeyRing)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }
    }
}
