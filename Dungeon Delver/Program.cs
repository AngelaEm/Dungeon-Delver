using Dungeon_Delver.Models;

namespace Dungeon_Delver
{
    
    internal class Program
    {
        //static Game game = new Game();
        static string[] mainMenuChoices = { "Blue room", "Red room", "Yellow room", "Black room", "Golden room","Exit"};
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
            NPC Ghost = new NPC("Ghost", "Is very spooky", 90, false, 15);
            NPC Vampire = new NPC("Vampire", "Drink your blood", 380, false, 8);
            NPC Wizzard = new NPC("Klaus", "A very red and fat man", 100, true, 0);
            NPC friendly1 = new NPC("Unicorn", "A very friendly unicorn", 50, true, 0);
            NPC friendly2 = new NPC("Dog", "A very friendly dog", 50, true, 0);
            NPC friendly3 = new NPC("Teacher", "A very friendly teacher", 70, true, 0);
            NPC friendly4 = new NPC("Santa Claus", "A very friendly santa", 60, true, 0);


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
            Key yellowKey1 = new Key("Yellow key 1", "A heavy golden key", true);
            Key yellowKey2 = new Key("Yellow key 2", "A heavy neonyellow key", false);
            Key blackKey1 = new Key("Black key 1", "A talking black key", true);
            Key blackKey2 = new Key("Black key", "A silent black key", false);

            // Potions
            Potion healthPotion = new Potion("Health Potion", "Green", true);
            Potion healthPotion1 = new Potion("Health Potion", "Pink", true);
            Potion healthPotion2 = new Potion("Health Potion", "Red", true);
            Potion healthPotion3 = new Potion("Health Potion", "Green", false);
            Potion healthPotion4 = new Potion("Health Potion", "Yellow", false);
            Potion mysteryPotion = new Potion("Health Potion", "Purple", true);
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
            Yellow.ItemsInRoom.Add(mysteryPotion);
            Yellow.ItemsInRoom.Add(mysteryPotion1);
            Black.ItemsInRoom.Add(mysteryPotio2);
            Black.ItemsInRoom.Add(mysteryPotio3);

            
            Blue.ItemsInRoom.Add(blueKey2);           
            Red.ItemsInRoom.Add(redKey2);          
            Yellow.ItemsInRoom.Add(yellowKey2);           
            Black.ItemsInRoom.Add(blackKey2);

            Blue.ItemsInRoom.Add(Sword);
            Red.ItemsInRoom.Add(Axe);
            Yellow.ItemsInRoom.Add(CrossBow);
            Black.ItemsInRoom.Add(Broom);
            Red.ItemsInRoom.Add(Pistol);
            Gold.ItemsInRoom.Add(Machete);


            // Add NPSs in room
            Blue.NPCsInRoom.Add(GiantRat);
            //Blue.NPCsInRoom.Add(Slime);
            Blue.NPCsInRoom.Add(friendly1);
            Red.NPCsInRoom.Add(friendly2);
            Red.NPCsInRoom.Add(Crab);
            //Yellow.NPCsInRoom.Add(Wizzard);
            Yellow.NPCsInRoom.Add(friendly3);
            Yellow.NPCsInRoom.Add(Ghost);
            Black.NPCsInRoom.Add(friendly4);
            Black.NPCsInRoom.Add(Vampire);

            // Keys on NPC
            Vampire.NPCitems.Add(blackKey1);
            Ghost.NPCitems.Add(yellowKey1);
            Crab.NPCitems.Add(redKey1);
            GiantRat.NPCitems.Add(blueKey1);


            
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
                    game.OnRoomEnter(game.CurrentRoom);
                    InsideRoomMenu(MenuDesign(roomChoices), game, player, game.CurrentRoom);
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
                    room.EnterRoom(player);
                    Console.ReadKey();
                    InsideRoomMenu(MenuDesign(roomChoices), game, player, room);

                    break;

                case 1:

                    Console.Clear();

                    if(room.NPCsInRoom.Count != 0)
                    {
                        foreach (NPC npc in room.NPCsInRoom)
                        {
                            

                            Console.WriteLine($"You meet {npc.Name}!");
                            Console.ReadKey();
                            if (npc.IsFriendly)
                            {
                                if (npc.Experience > 0)
                                {
                                    npc.GiveXP(player);
                                    Console.WriteLine("Hello Friend! You get 10 XP!");
                                    Console.WriteLine($"You now have {player.Experience} XP!");
                                    
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

                    player.ChooseItemsInRoom(room);
                    Console.ReadKey();

                    InsideRoomMenu(MenuDesign(roomChoices), game, player, room);

                    break;

                case 3:

                    Console.Clear();
                    player.SeePotionsAndWeaponsInBag();
                    Console.ReadKey();
                    player.ChoosePotionToUse();
                    Console.ReadKey();
                    InsideRoomMenu(MenuDesign(roomChoices), game, player, room);


                    break;

                case 4:

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