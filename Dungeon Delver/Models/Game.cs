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
            Console.Clear();
            room.EnterRoom(Player);
            Console.WriteLine("Press enter to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        public void OnEnemyDefeat()
        {

        }
        public void OnItemUse()
        {

        }





    }
}
