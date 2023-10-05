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
            Random random = new Random();          
            Console.WriteLine("\nSpin wheel of fortune!\n");
            Console.ReadKey();
            int luckyNumber = random.Next(1, 21);

            if (luckyNumber%2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Lucky you! You got {luckyNumber} and get {luckyNumber} extra XP!");
                Player.Experience += luckyNumber;
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"To bad! You got {luckyNumber} and loose {luckyNumber} XP!");
                Player.Experience -= luckyNumber;
                Console.ResetColor();
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
                        Console.Beep(1000, 1000);
                        Console.WriteLine($"{player.Name} hit a critical strike for {criticalDmg}. {npc.Name} now has {npc.Health} hp.");
                        Console.ReadKey();
                    }
                    //you hit a normal strike
                    else
                    {
                        player.Attack(npc);
                        Console.Beep(1000, 1000);
                        Console.WriteLine($"{player.Name} hit a strike for {player.PlayerAttackDmg()}. {npc.Name} now has {npc.Health} hp.");
                        Console.ReadKey();
                    }
                }
                //Misses enemy
                else
                {
                    Console.WriteLine("You missed your attack");
                    Console.ReadKey();
                }
                if (npc.IsAlive && player.IsAlive)
                {
                    npc.AttackPlayer(player);
                    Console.WriteLine($"{npc.Name} strike back with {npc.Dmg} and {player.Name} now has {player.Health} hp.");
                    Console.ReadKey();
                }

            }
            
            if (npc.IsAlive && !player.IsAlive)
            {
                Console.WriteLine("Game over");
                Console.ReadKey(true);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"{npc.Name} died!");
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
    }
}
