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

        public void GoToNextRoom()
        {
            
        }
        public void GoToPreviousRoom()
        {

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
        public void OnEnemyDefeat()
        {

        }
        public void OnItemUse()
        {

        }





    }
}
