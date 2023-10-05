using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Delver.Models
{
    internal class Player : Entity
    {
        public List<Item> Inventory { get; set; }
        public int Dexterity { get; set; } 
        public int Strength { get; set; } 
        public int Level { get; set; } 
        public int Experience { get; set; } 


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
        }

        public int TakeDamage(Potion potion)
        {
            return Health += potion.PotionEffect();
        }
        public void PickUpItem(Item item)
        {
           Inventory.Add(item);
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
    }
}
