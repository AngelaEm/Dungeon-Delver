using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Delver.Models
{
    internal class Game
    {
        public List<Room> RoomsInGame { get; set; } = new List<Room>();
        public Room CurrentRoom { get; set; }
        public Player Player { get; set; }

        public Game(Player player)
        {
            Player = player;
        }

       
        public void OnRoomEnter(Room room)
        {
            room.InsideRoom(Player);
            Random random = new Random();          
            Console.WriteLine("\nSpin wheel of fortune!\n");
            Console.ReadKey();
            int luckyNumber = random.Next(1, 21);

            if (luckyNumber%2 == 0)
            {
                Player.Experience += luckyNumber;
                Player.Health += luckyNumber;

                Console.WriteLine($"Lucky you! You get {luckyNumber} extra XP and HP. You now have {Player.Experience} XP and {Player.Health} HP!");
                
               
            }
            else
            {
                Player.Experience -= luckyNumber;
                Player.Health -= luckyNumber;
                Console.WriteLine($"To bad! You loose {luckyNumber} XP and Hp. You now have {Player.Experience} XP and {Player.Health} HP...");
                

            }
            Console.ReadKey();


        }

        public void Fight(Player player, NPC npc)
        {
            while (npc.IsAlive && player.IsAlive)
            {
                Random random = new Random();
                int criticalDmg = player.PlayerAttackDmg() * 2;

                int hitRandom = random.Next(1, 6);

                //Hits enemy
                if (hitRandom > 1)
                {
                    //You hit a critical strike
                    if (hitRandom > 4)
                    {
                        npc.Health -= criticalDmg;
                        
                        Console.WriteLine($"\n{player.Name} hit a critical strike for {criticalDmg}. {npc.Name} now has {npc.Health} hp.");
                        Console.ReadKey();
                    }
                    //you hit a normal strike
                    else
                    {
                        player.Attack(npc);
                        
                        Console.WriteLine($"\n{player.Name} hit a strike for {player.PlayerAttackDmg()}. {npc.Name} now has {npc.Health} hp.");
                        Console.ReadKey();
                    }
                }
                //Misses enemy
                else
                {
                    Console.WriteLine("\nYou missed your attack");
                    Console.ReadKey();
                }
                if (npc.IsAlive && player.IsAlive)
                {
                    npc.AttackPlayer(player);
                    Console.WriteLine($"\n{npc.Name} strike back with {npc.Dmg} and {player.Name} now has {player.Health} hp.");
                    Console.ReadKey();
                }

            }
            
            if (npc.IsAlive && !player.IsAlive)
            {
                Console.WriteLine("\nGame over");
                Console.ReadKey(true);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"\n{npc.Name} died!");
                CurrentRoom.NPCsInRoom.Remove(npc);
                npc.GiveXP(player);
                Console.WriteLine($"\nYou now have {player.Experience} XP!");
                if (npc.NPCitems.Count > 0)
                {
                    Console.WriteLine($"\n{npc.Name} dropped a {npc.NPCitems[0].Description} and you picked it up.");
                    player.PickUpKey(npc);
                }                           
            }
        }

        public void FinalRoom()
        {
            Console.Clear();

            if (Player.KeyRing.Count == 4)
            {
                Console.WriteLine($"\nYou got all keys! You are welcome to fight the {CurrentRoom.NPCsInRoom[0].Description}! Good Luck...");
                Console.ReadKey();
                Fight(Player, CurrentRoom.NPCsInRoom[0]);
                Console.ReadKey();
                
            }
            else
            {
                Console.WriteLine("\nYou need four keys to enter. Please check out the other rooms and try to find the right keys...\n");
                
            }
            Console.ReadKey();
        }
    }
}
