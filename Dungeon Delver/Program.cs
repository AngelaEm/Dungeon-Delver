using Dungeon_Delver.Models;

namespace Dungeon_Delver
{
    
    internal class Program
    {
        //static Game game = new Game();
        static string[] mainMenuChoices = { "Blue room", "Red room", "Green room", "Pink room", "Golden room", "Exit"};
        static string[] roomChoices = { "See whats inside", "Interact with NPC", "Pick up item", "Use item", "Check items in bag", "Exit room"};      

        

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
            NPC Ghost = new NPC("Ghost", "Is very spooky", 90, false, 12);
            NPC Vampire = new NPC("Vampire", "Drink your blood", 70, false, 8);
            NPC Wizzard = new NPC("Klaus", "A very red and fat man", 100, true, 0);
            NPC friendly1 = new NPC("Unicorn", "A very friendly unicorn", 50, true, 0);
            NPC friendly2 = new NPC("Dog", "A very friendly dog", 50, true, 0);
            NPC friendly3 = new NPC("Teacher", "A very friendly teacher", 70, true, 0);
            NPC friendly4 = new NPC("Santa Claus", "A very friendly santa", 60, true, 0);
            NPC dragon = new NPC("Dragon", "dangerous dragon who is guarding the golden room", 200, false, 18);


            // Rooms

            Room Blue = new Room("Blue");
            Room Red = new Room("Red");
            Room Green = new Room("Green");
            Room Pink = new Room("Pink");
            Room Gold = new Room("Gold");

            // Keys
            Key blueKey1 = new Key("Blue key", "A small lightblue key", true);
            Key blueKey2 = new Key("Blue key", "A big darkblue key", false);
            Key redKey1 = new Key("Red key", "A shiny red key", true);
            Key redKey2 = new Key("Red key", "A dirty old key", false);
            Key yellowKey1 = new Key("Green key", "A heavy golden key", true);
            Key yellowKey2 = new Key("Green key", "A heavy neonyellow key", false);
            Key blackKey1 = new Key("Pink key", "A talking black key", true);
            Key blackKey2 = new Key("Pink key", "A silent black key", false);
            Key goldenKey = new Key("Golden key", "locks upp treasure chamber", true);

            // Potions
            Potion healthPotion = new Potion("Health Potion", "Orange", false);
            Potion healthPotion1 = new Potion("Health Potion", "Pink", false);
            Potion healthPotion2 = new Potion("Health Potion", "Red", true);
            Potion healthPotion3 = new Potion("Health Potion", "Green", false);
            Potion healthPotion4 = new Potion("Health Potion", "Yellow", true);
            Potion mysteryPotion = new Potion("Health Potion", "Purple", false);
            Potion mysteryPotion1 = new Potion("Health Potion", "Brown", true);
            Potion mysteryPotio2 = new Potion("Health Potion", "Black", false);
            Potion mysteryPotio3 = new Potion("Health Potion", "Blue", false);

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
            Green.ItemsInRoom.Add(mysteryPotion);
            Green.ItemsInRoom.Add(mysteryPotion1);
            Pink.ItemsInRoom.Add(mysteryPotio2);
            Pink.ItemsInRoom.Add(mysteryPotio3);

            
            Blue.ItemsInRoom.Add(blueKey2);           
            Red.ItemsInRoom.Add(redKey2);          
            Green.ItemsInRoom.Add(yellowKey2);           
            Pink.ItemsInRoom.Add(blackKey2);

            Blue.ItemsInRoom.Add(Sword);
            Red.ItemsInRoom.Add(Axe);
            Green.ItemsInRoom.Add(CrossBow);
            Pink.ItemsInRoom.Add(Broom);
            Red.ItemsInRoom.Add(Pistol);
            Gold.ItemsInRoom.Add(Machete);


            // Add NPSs in room
            Blue.NPCsInRoom.Add(GiantRat);
            Blue.NPCsInRoom.Add(Slime);
            Blue.NPCsInRoom.Add(friendly1);
            Red.NPCsInRoom.Add(friendly2);
            Red.NPCsInRoom.Add(Crab);
            Green.NPCsInRoom.Add(Wizzard);
            Green.NPCsInRoom.Add(friendly3);
            Green.NPCsInRoom.Add(Ghost);
            Pink.NPCsInRoom.Add(friendly4);
            Pink.NPCsInRoom.Add(Vampire);
            Gold.NPCsInRoom.Add(dragon);

            // Keys on NPC
            Vampire.NPCitems.Add(blackKey1);
            Ghost.NPCitems.Add(yellowKey1);
            Crab.NPCitems.Add(redKey1);
            GiantRat.NPCitems.Add(blueKey1);
            dragon.NPCitems.Add(goldenKey);


            
            game.RoomsInGame.Add(Blue);
            game.RoomsInGame.Add(Red);
            game.RoomsInGame.Add(Green);
            game.RoomsInGame.Add(Pink);
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
            switch (menuSelected)

            {
                case 0:
                    
                    game.CurrentRoom = game.RoomsInGame[0];                  
                    game.OnRoomEnter(game.CurrentRoom);
                    InsideRoomMenu(MenuDesign(roomChoices), game, player, game.CurrentRoom);
                    break;

                case 1:
                    
                    game.CurrentRoom = game.RoomsInGame[1];                
                    game.OnRoomEnter(game.CurrentRoom);
                    InsideRoomMenu(MenuDesign(roomChoices), game, player, game.CurrentRoom);
                    
                    break;

                case 2:
                    
                    game.CurrentRoom = game.RoomsInGame[2];                
                    game.OnRoomEnter(game.CurrentRoom);
                    InsideRoomMenu(MenuDesign(roomChoices), game, player, game.CurrentRoom);
                    
                    break;

                case 3:
                   
                    game.CurrentRoom = game.RoomsInGame[3];
                    game.OnRoomEnter(game.CurrentRoom);
                    InsideRoomMenu(MenuDesign(roomChoices), game, player, game.CurrentRoom);
                    
                    break;

                case 4:

                    game.CurrentRoom = game.RoomsInGame[4];
                    game.CurrentRoom.InsideRoom(player);
                    game.FinalRoom();
                    MainMenu(MenuDesign(mainMenuChoices), game, player);


                    break;

                case 5:

                    Environment.Exit(0);
                    break;

          

            }
        }

        static void InsideRoomMenu(int menuSelected, Game game, Player player, Room room)
        {
            switch (menuSelected)
            {
                case 0:
                    
                    Console.Clear();
                    room.InsideRoom(player);
                    room.PrintEverythinInRoom();
                    Console.ReadKey();
                    InsideRoomMenu(MenuDesign(roomChoices), game, player, room);

                    break;

                case 1:

                    Console.Clear();
                    room.InsideRoom(player);

                    if (room.NPCsInRoom.Count != 0)
                    {
                        foreach (NPC npc in room.NPCsInRoom)
                        {

                            Console.WriteLine("\n---------------------------------");
                            Console.WriteLine($"You meet {npc.Name}!");
                            Console.WriteLine("---------------------------------\n");
                            Console.ReadKey();

                            if (npc.IsFriendly)
                            {
                                if (npc.Experience > 0)
                                {
                                    npc.GiveXP(player);
                                    Console.WriteLine("Hello Friend! You get 10 XP!");
                                    Console.WriteLine($"You now have {player.Experience} XP!");
                                    Console.WriteLine("---------------------------------\n");

                                }
                                else
                                {
                                    Console.WriteLine("Hello friend! Nice to see you again!");
                                }
                                Console.ReadKey();
                            }                         

                            else
                            {
                                npc.AttackPlayer(player);
                                Console.WriteLine($"{npc.Name} attack {player.Name}. {player.Name} now has health {player.Health} left\n");
                                Console.ReadKey();
                                game.Fight(player, npc);
                                break;

                            }
                        }                      
                    }
                    else
                    {
                        Console.WriteLine("No NPC:s to interact with.");
                    }
                    Console.ReadKey();
                    InsideRoomMenu(MenuDesign(roomChoices), game, player, room);

                    break;

                case 2:

                    Console.Clear();
                    room.InsideRoom(player);
                    Console.Clear();
                    player.ChooseItemsInRoom(room);                 
                    InsideRoomMenu(MenuDesign(roomChoices), game, player, room);

                    break;

                case 3:

                    Console.Clear();
                    room.InsideRoom(player);
                    player.SeeItemsToUseInBag();
                    Console.ReadKey();
                    player.ChoosePotionToUse();
                    InsideRoomMenu(MenuDesign(roomChoices), game, player, room);


                    break;

                case 4:
                    Console.Clear();
                    room.InsideRoom(player);
                    player.SeeItemsInBag();
                    Console.ReadKey();
                    InsideRoomMenu(MenuDesign(roomChoices), game, player, room);

                    break;

                case 5:
                    
                    MainMenu(MenuDesign(mainMenuChoices), game, player);
                    break;
            }

        }
    }
}