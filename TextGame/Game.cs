using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Items;
using TextGame.Locations;

namespace TextGame
{
    internal class Game
    {
        private bool gameOn = true;
        static List<Item> items = new List<Item>
        {
            new Sword("Big boy", "steel"),
            new Sword("Dwarf's power", "silver"),
        };
        Witcher geralt = new Witcher("Geralt", 80, items);
        Inn inn = new Inn();
        Trail trail = new Trail();
        Castle castle = new Castle();
        private Location currentLocation;
        private Dictionary<string, string> availableLocations = new Dictionary<string, string>();
        private Dictionary<string, string> availableOptions = new Dictionary<string, string>();
        public Game()
        {
            GameInit();
            ShowIntro();
        }

        /// <summary>
        /// Main game logic
        /// </summary>
        public void GameOn()
        {
            while (gameOn)
            {
                Console.WriteLine("-----------------------------------------------" +
                    "\n-----------------------------------------------" +
                    "\nWhat should I do?\n" +
                    "\n'G' - go to a location" +
                    "\n'S' - search for some items" +
                    "\n'I' - show your equipment" +
                    "\n'H' - show your current health" +
                    "\n'L' - show your current location" +
                    "\n'U' - use an item" +
                    "\n'E' - exit the game" +
                    "\n'T' - take an item\n" +
                    "-----------------------------------------------" +
                    "\n-----------------------------------------------\n");
                string input = getInput(availableOptions, "option");
                bool exit = false;
                switch (input)
                {
                    case "GO":
                        Console.Clear();
                        currentLocation = GoToLocation(currentLocation);
                        break;
                    case "EQUIPMENT":
                        ClearAndExecute(() => geralt.ShowItems());
                        break;
                    case "HEALTH":
                        ClearAndExecute(() => geralt.ShowCurrentHealth());
                        break;
                    case "LOCATION":
                        ClearAndExecute(() => currentLocation.GetDescription());
                        break;
                    case "SEARCH":
                        ClearAndExecute(() => currentLocation.ShowItems());
                        break;
                    case "EXIT":
                        Console.Clear();
                        exit = true;
                        break;
                    case "USE":
                        Console.Clear();
                        geralt.UseItem();
                        break;
                    case "TAKE":
                        Console.Clear();
                        currentLocation.RemoveItem(geralt);
                        break;
                    default:
                        break;
                }
                gameOn = ((geralt.Health != 100) && !exit);
                if (!gameOn)
                {
                    Console.WriteLine("\n-----------------------------------------------");
                    Console.WriteLine("|------G O O D B Y E ___ W A N D E R E R------|");
                    Console.WriteLine("-----------------------------------------------\n\n");
                }
            }
        }

        /// <summary>
        /// Executing a method as an argument
        /// </summary>
        /// <param name="action"></param>
        public void ClearAndExecute(Action action)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------");
            action();
            Console.WriteLine("-----------------------------------------------\n");
        }

        /// <summary>
        /// Changing witcher's location
        /// </summary>
        /// <param name="locName1">enum loc1</param>
        /// <param name="locName2">enum loc2</param>
        /// <param name="loc1">first location object</param>
        /// <param name="loc2">second location object</param>
        /// <param name="loc1Char">first letter of first location</param>
        /// <param name="loc2Char">first letter of second location</param>
        /// <returns></returns>
        private Location ChangeLocation(LocationsNames locName1, LocationsNames locName2, Location loc1, Location loc2, char loc1Char, char loc2Char)
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Where should I go? " +
                        $"\n'{loc1Char}' - go to the {locName1}" +
                        $"\n'{loc2Char}' - go to the {locName2}"
                    );
            Console.WriteLine("-----------------------------------------------");
            string destination = getInput(availableLocations, "location");
            Console.Clear();
            if (destination == currentLocation.Name.ToString())
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine($"I can't do that :-) I am already in: {currentLocation.Name} !!!");
                Console.WriteLine("-----------------------------------------------");
                return currentLocation;
            }
            else if (destination != currentLocation.Name.ToString() && destination == locName1.ToString())
            {
                return loc1;
            }
            else if (destination != currentLocation.Name.ToString() && destination == locName2.ToString())
            {
                return loc2;
            }
            return currentLocation;
        }
        
       /// <summary>
       /// Changing location basing on a current location
       /// </summary>
       /// <param name="currentLocation"></param>
       /// <returns></returns>
        private Location GoToLocation(Location currentLocation)
        {
            switch (currentLocation.Name)
            {
                case LocationsNames.Trail:
                    currentLocation = ChangeLocation(LocationsNames.Inn, LocationsNames.Castle, inn, castle, 'I', 'C');
                    return currentLocation;
                case LocationsNames.Inn:
                    currentLocation = ChangeLocation(LocationsNames.Trail, LocationsNames.Castle, trail, castle, 'T', 'C');
                    return currentLocation;
                case LocationsNames.Castle:
                    currentLocation = ChangeLocation(LocationsNames.Trail, LocationsNames.Inn, trail, inn, 'T', 'I');
                    return currentLocation;
                default:
                    return currentLocation;
            }
        }
        
        /// <summary>
        /// Validating an input
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="inputName"></param>
        /// <returns></returns>
        private string getInput(Dictionary<string, string> dict, string inputName)
        {
            string input = Console.ReadLine().ToUpper();
            while (!dict.ContainsKey(input))
            {
                Console.WriteLine($"This is not a correct {inputName}. Enter a correct {inputName}: ");
                input = Console.ReadLine().ToUpper();
                dict.ContainsKey(input);
            }
            input = dict[input];
            return input;
        }
        
        /// <summary>
        /// Game initialization
        /// </summary>
        private void GameInit()
        {
            availableLocations["I"] = LocationsNames.Inn.ToString();
            availableLocations["C"] = LocationsNames.Castle.ToString();
            availableLocations["T"] = LocationsNames.Trail.ToString();
            availableOptions["G"] = OptionsNames.GO.ToString();
            availableOptions["S"] = OptionsNames.SEARCH.ToString();
            availableOptions["T"] = OptionsNames.TAKE.ToString();
            availableOptions["I"] = OptionsNames.EQUIPMENT.ToString();
            availableOptions["H"] = OptionsNames.HEALTH.ToString();
            availableOptions["U"] = OptionsNames.USE.ToString();
            availableOptions["L"] = OptionsNames.LOCATION.ToString();
            availableOptions["E"] = OptionsNames.EXIT.ToString();
            currentLocation = trail;
        }

        /// <summary>
        /// Showing an intro when the game starts
        /// </summary>
        private void ShowIntro()
        {
            string intro = $"{geralt}, the witcher, stands before Kaer Morhen. " +
                "\nHis white hair and yellow eyes mark him unmistakably. " +
                "\nThe journey has taken its toll on him, his skin kissed by the sun," +
                "his face showing signs of fatigue. \nHis trusted sword rests on his back, " +
                "a weapon that has seen countless battles. \nAhead lies a signpost, " +
                "pointing to two directions: inn, castle. \nGerald ponders, seeking a place to rest, " +
                "his thoughts fixated on an inn for a hearty meal.\nHis senses alert, " +
                "he awaits the next adventure, ready for whatever challenges may come his way.\n\n";
            foreach (char c in intro)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }
        }
    }
}
