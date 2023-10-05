using Dungeon_Delver.Models;

namespace Dungeon_Delver
{
    
    internal class Program
    {
        //static Game game = new Game();
        static string[] mainMenuChoices = { "Blue room", "Red room", "Yellow room", "Black room", "Golden room","Extra", "Exit" };
        static string[] roomChoices = { "See whats inside", "Attack", "Pick up item", "Use item", "Check items in bag", "Exit room"};      

        static int menuSelected = MenuDesign(mainMenuChoices);

        static void Main(string[] args)
        {
            
            
            // Player
            Player angela = new Player("Angela", "Teacher");

            // Game
            Game game = new Game(angela);


            Start(game);

            MainMenu(MenuDesign(mainMenuChoices), game, angela);
            

            

        }

        static void Start(Game game)
        {
            // NPSs
            NPC Crab = new NPC("Crab", "Its got a knife", 70, false, 7);
            NPC GiantRat = new NPC("Giant Rat", "Its Huge!", 50, false, 5);
            NPC Slime = new NPC("Slime", "its very slimy", 60, false, 10);
            NPC Wizzard = new NPC("Klaus", "A very red and fat man", 100, true, 0);

            // Rooms

            Room Blue = new Room("Blue");
            Room Red = new Room("Red");
            Room Yellow = new Room("Yellow");
            Room Black = new Room("Black");
            Room Gold = new Room("Gold");

            // Keys
            Key blueKey1 = new Key("Blue key 1", "A small lightblue key", true);
            Key blueKey2 = new Key("Blue key 2", "A big darkblue key", false);
            Key redKey1 = new Key("Red key 1", "A shiny red key", true);
            Key redKey2 = new Key("Red key 2", "A dirty old key", false);
            Key yellowKey1 = new Key("Yellow key 1", "A heavy golden key", false);
            Key yellowKey2 = new Key("Yellow key 2", "A heavy neonyellow key", true);
            Key blackKey1 = new Key("Black key 1", "A talking black key", false);
            Key blackKey2 = new Key("Black key", "A silent black key", true);

            // Potions
            Potion healthPotion = new Potion("Health Potion", "Generates health", true);
            Potion healthPotion1 = new Potion("Health Potion", "Generates health", true);
            Potion healthPotion2 = new Potion("Health Potion", "Generates health", true);
            Potion healthPotion3 = new Potion("Health Potion", "Generates health", false);
            Potion healthPotion4 = new Potion("Health Potion", "Generates health", false);
            Potion mysteryPotion = new Potion("Health Potion", "Drink at your own peril", true);
            Potion mysteryPotion1 = new Potion("Health Potion", "Drink at your own peril", true);
            Potion mysteryPotio2 = new Potion("Health Potion", "Drink at your own peril", false);
            Potion mysteryPotio3 = new Potion("Health Potion", "Drink at your own peril", false);

            // Weapons
            Weapon Sword = new Weapon("Excalibur", "Sword", 25, true);
            Weapon Axe = new Weapon("TimberAxe", "Axe", 30, true);
            Weapon CrossBow = new Weapon("Bow", " CrossBow", 15, true);
            Weapon Pistol = new Weapon("Golden Eagle", "Pistol", 45, true);
            Weapon Broom = new Weapon("Broom", "For Cleaning", 0, false);
            Weapon Machete = new Weapon("Machete", "Big Knife", 20, true);

            //AdditemsToRoom
            Blue.ItemsInRoom.Add(healthPotion);
            Blue.ItemsInRoom.Add(healthPotion1);
            Blue.ItemsInRoom.Add(healthPotion2);
            Red.ItemsInRoom.Add(healthPotion3);
            Red.ItemsInRoom.Add(healthPotion4);
            Yellow.ItemsInRoom.Add(mysteryPotion);
            Yellow.ItemsInRoom.Add(mysteryPotion1);
            Black.ItemsInRoom.Add(mysteryPotio2);
            Black.ItemsInRoom.Add(mysteryPotio3);

            Blue.ItemsInRoom.Add(blueKey1);
            Blue.ItemsInRoom.Add(blueKey2);
            Red.ItemsInRoom.Add(redKey1);
            Red.ItemsInRoom.Add(redKey2);
            Yellow.ItemsInRoom.Add(yellowKey1);
            Yellow.ItemsInRoom.Add(yellowKey2);
            Black.ItemsInRoom.Add(blackKey1);
            Black.ItemsInRoom.Add(blackKey2);

            Blue.ItemsInRoom.Add(Sword);
            Red.ItemsInRoom.Add(Axe);
            Yellow.ItemsInRoom.Add(CrossBow);
            Black.ItemsInRoom.Add(Broom);
            Red.ItemsInRoom.Add(Pistol);
            Gold.ItemsInRoom.Add(Machete);


            // Add NPSs in room
            Blue.NPCsInRoom.Add(GiantRat);
            Blue.NPCsInRoom.Add(Slime);
            Red.NPCsInRoom.Add(Crab);
            Yellow.NPCsInRoom.Add(Wizzard);

            
            game.RoomsInGame.Add(Blue);
            game.RoomsInGame.Add(Red);
            game.RoomsInGame.Add(Yellow);
            game.RoomsInGame.Add(Black);
            game.RoomsInGame.Add(Gold);

            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine("\n*******************************\n");
            Console.WriteLine("Welcome to Dungeon Delver");         
            Console.WriteLine("\n*******************************\n");
            Console.WriteLine("Press enter to enter the dungeon...");
            Console.ReadKey();
            Console.ResetColor();
        }

        static int MenuDesign(string[] menuChoices)
        {

            int menuSelected = 0;
            bool isRunning = true;

            // Variable holding the color to highligt with and an arrow
            string color = "\u001b[34m--->    ";

            // Let user navigate through menu using "up" and "down" and select with enter
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine();
                Console.CursorVisible = false;

                Console.WriteLine("\nUse up and down arrows to navigate and press enter to select.\n");

                // Iterates through array to display menuchoises
                for (int i = 0; i < menuChoices.Length; i++)
                {
                    Console.WriteLine($"{(menuSelected == i ? color : "\t")}{menuChoices[i]}\u001b[0m");
                }

                // Naviagte with up and down-arrows
                var keyPressed = Console.ReadKey(true);

                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelected != menuChoices.Length - 1)
                {
                    menuSelected++;
                }

                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelected > 0)
                {
                    menuSelected--;
                }

                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
            return menuSelected;
        }

        static void MainMenu(int menuSelected, Game game, Player player)
        {
            bool isRunning = true;

            while (isRunning)
            {
                switch (menuSelected)

                {
                    case 0:

                        game.OnRoomEnter(game.RoomsInGame[0]);
                        InsideRoomMenu(MenuDesign(roomChoices), game, player, game.RoomsInGame[0]);
                        break;

                    case 1:

                        game.OnRoomEnter(game.RoomsInGame[1]);
                        InsideRoomMenu(MenuDesign(roomChoices), game, player, game.RoomsInGame[1]);
                        break;

                    case 2:
                        game.OnRoomEnter(game.RoomsInGame[2]);
                        InsideRoomMenu(MenuDesign(roomChoices), game, player, game.RoomsInGame[2]);
                        break;

                    case 3:
                        game.OnRoomEnter(game.RoomsInGame[3]);
                        InsideRoomMenu(MenuDesign(roomChoices), game, player, game.RoomsInGame[3]);
                        break;

                    case 4:
                        game.OnRoomEnter(game.RoomsInGame[4]);
                        InsideRoomMenu(MenuDesign(roomChoices), game, player, game.RoomsInGame[4]);
                        break;

                    case 5:

                        break;

                    case 6:

                        Environment.Exit(0);
                        break;


                }
            }
        }

        static void InsideRoomMenu(int menuSelected, Game game, Player player, Room room)
        {
            bool isRunning = true;

            while (isRunning)
            {
                switch (menuSelected)
                {
                    case 0:

                        Console.Clear();
                        room.EnterRoom(player);
                        Console.ReadKey();
                        InsideRoomMenu(MenuDesign(roomChoices), game, player, room);

                        break;

                    case 1:

                        Console.Clear();
                        Console.WriteLine("Attack!");
                        Console.ReadKey();
                       

                        foreach (NPC npc in room.NPCsInRoom)
                        {
                            npc.TakeDamage(player);
                            Console.WriteLine($"{player.Name} attack {npc.Name}. {npc.Name} now has health {npc.Health} left\n");
                            player.TakeDamage(npc);
                            Console.WriteLine($"{player.Name} attack {npc.Name} but it was a tough fight and {player.Name} now has health {player.Health} left\n");
                            Console.ReadKey();
                        }
                        
                        InsideRoomMenu(MenuDesign(roomChoices), game, player, room);

                        break;

                    case 2:

                        Console.Clear();


                        Console.WriteLine("Do you want to add items to yor bag?");
                        Console.WriteLine("You may add three different items. Press enter to continue...\n");
                        Console.ReadKey();



                        for (int i = 0; i < room.ItemsInRoom.Count; i++)
                        {
                            Console.Clear();
                            Console.WriteLine($"Press y to add and n to pass: {room.ItemsInRoom[i]}");
                            string input = Console.ReadLine();
                            if (input == "y")
                            {
                                player.PickUpItem(room.ItemsInRoom[i]);
                                Console.WriteLine($"\nYou added {room.ItemsInRoom[i]}");
                            }
                            else
                            {
                                Console.WriteLine($"\nYou did not add {room.ItemsInRoom[i]}");
                            }

                        }
                        Console.ReadKey();


                        InsideRoomMenu(MenuDesign(roomChoices), game, player, room);

                        break;

                    case 3:

                       
                        InsideRoomMenu(MenuDesign(roomChoices), game, player, room);


                        break;

                    case 4:

                        foreach (var item in player.Inventory)
                        {
                            Console.WriteLine(item.Name);
                        }
                        Console.ReadKey();
                        InsideRoomMenu(MenuDesign(roomChoices), game, player, room);

                        break;

                    case 5:
                        isRunning = false;
                        MainMenu(MenuDesign(mainMenuChoices), game, player);
                        break;
                }
            }
            

            
            

        }
    }
}