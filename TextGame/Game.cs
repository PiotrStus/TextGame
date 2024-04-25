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
            new Sword("Dwarf's power", "steel"),
            new Sword("Blade of destiny", "silver"),
            new Sword("Dragon slayer", "silver"),
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
        public void GameOn()
        {
            while (gameOn)
            {
                //Console.Clear();
                //geralt.ShowItems();
                currentLocation.GetDescription();
                Console.WriteLine("\n---------------------\n" +
                    "\nWhat should I do?\n" +
                    "\n'G' - go to a location" +
                    "\n'I' - show available items" +
                    "\n'E' - show your equipment" +
                    "\n'L' - show your current location" +
                    "\n'H' - show your current health" +
                    "\n'T' - take an item\n");
                string input = getInput(availableOptions, "option");
               

                switch (input)
                {
                    case "GO":
                        currentLocation = GoToLocation(currentLocation);
                        break;
                    case "LOCATION":
                        currentLocation.GetDescription();
                        break;
                    case "EQUIPMENT":
                        geralt.ShowItems();
                        break;
                    default:
                        break;
                }

            }
            
        }

        private Location ChangeLocation(LocationsNames locName1, LocationsNames locName2, Location loc1, Location loc2, char loc1Char, char loc2Char)
        {
            //Console.Clear();
            Console.WriteLine("\nWhere should I go? " +
                        $"\n'{loc1Char}' - go to the {locName1}" +
                        $"\n'{loc2Char}' - go to the {locName2}"
                    );
            
            string destination = getInput(availableLocations, "location");
            if (destination == currentLocation.Name.ToString())
            {
                Console.WriteLine($"Don't cheat :-) You are already in: {currentLocation.Name} !!!");
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

        private Location GoToLocation(Location currentLocation)
        {
            string destination;
            switch (currentLocation.Name)
            {
                case LocationsNames.Trail:
                    //Console.WriteLine("\nWhere should I go? " +
                    //    "\n'I' - go to the old Inn" +
                    //    "\n'C' - go to the castle"
                    //);
                    //destination = getInput(availableLocations, "location");
                    //if (destination == currentLocation.Name.ToString())
                    //{
                    //    Console.WriteLine($"You are already in: {currentLocation.Name} !!!");
                    //    return currentLocation;
                    //}
                    //else if (destination != currentLocation.Name.ToString() && destination == LocationsNames.Inn.ToString())
                    //{
                    //    return inn;
                    //}
                    //else if (destination != currentLocation.Name.ToString() && destination == LocationsNames.Castle.ToString())
                    //{
                    //    return castle;
                    //}
                    //return currentLocation;
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

        private void GameInit()
        {
            availableLocations["I"] = LocationsNames.Inn.ToString();
            availableLocations["C"] = LocationsNames.Castle.ToString();
            availableLocations["T"] = LocationsNames.Trail.ToString();
            availableOptions["G"] = OptionsNames.GO.ToString();
            availableOptions["I"] = OptionsNames.ITEMS.ToString();
            availableOptions["T"] = OptionsNames.TAKE.ToString();
            availableOptions["E"] = OptionsNames.EQUIPMENT.ToString();
            availableOptions["L"] = OptionsNames.LOCATION.ToString();
            availableOptions["H"] = OptionsNames.HEALTH.ToString();
            currentLocation = trail;
        }

        private void ShowIntro()
        {
            string intro = $"{geralt}, the witcher, stands before Kaer Morhen. " +
                "\nHis white hair and yellow eyes mark him unmistakably. " +
                "\nThe journey has taken its toll on him, his skin kissed by the sun," +
                "his face showing signs of fatigue. \nHis trusted sword rests on his back, " +
                "a weapon that has seen countless battles. \nAhead lies a signpost, " +
                "pointing to two directions: inn, castle. \nGerald ponders, seeking a place to rest, " +
                "his thoughts fixated on an inn for a hearty meal.\nHis senses alert, " +
                "he awaits the next adventure, ready for whatever challenges may come his way.";
            foreach (char c in intro)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }
        }
    }
}
