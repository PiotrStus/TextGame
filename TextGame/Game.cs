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
            new Sword("sword", "silver"),
        };
        Witcher geralt = new Witcher("Geralt", 80, items);
        Inn inn = new Inn();
        Trail trail = new Trail();
        private Location currentLocation;

        private Dictionary<string, string> availableLocations = new Dictionary<string,string>();
        private Dictionary<string, string> availableOptions = new Dictionary<string, string>();

        public Game()
        {
            GameInit();
        }
        public void GameOn()
        {
            while (gameOn)
            {
                ShowIntro();
                string input = getInput(availableOptions, "option");
                Console.WriteLine($"Input {input}");

                switch (input)
                {
                    case "GO":
                        GoToLocation(); break;
                    default:
                        break;

                }

            }
        }

        private void GoToLocation() 
        {
            Console.WriteLine("\nWhere do you want to go? " +
                "\n'I' - go to the old Inn" +
                "\n'C' - go to the castle"
                );
            string destination = getInput(availableLocations, "location");
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
            availableLocations["I"] = "INN";
            availableLocations["C"] = "CASTLE";
            availableOptions["G"] = "GO";
            availableOptions["I"] = "ITEMS";
            availableOptions["T"] = "TAKE";
            availableOptions["E"] = "EQUIPMENT";

            currentLocation = trail;
            Console.WriteLine("xXx");
            currentLocation.GetDescription();
            Console.WriteLine("xXx\n");
        }

        private void ShowIntro()
            {
            string intro = $"{geralt}, the witcher, stands before Kaer Morhen. " +
                "\nHis white hair and yellow eyes mark him unmistakably. " +
                "\nThe journey has taken its toll on him, his skin kissed by the sun," +
                "his face showing signs of fatigue. \nHis trusted sword rests on his back," +
                "a weapon that has seen countless battles. \nAhead lies a signpost, " +
                "pointing to three directions: inn, castle. \nGerald ponders, seeking a place to rest," +
                "his thoughts fixated on a tavern for a hearty meal.\n His senses alert, " +
                "he awaits the next adventure, ready for whatever challenges may come his way." +
                "\n\n---------------------" +
                "\n\nWhat do you want to do?" +
                "\n'G' - go to a location" +
                "\n'I' - show available items" +
                "\n'E' - show your equipment" +
                "\n'T' - take an item\n";

                    

                    foreach (char c in intro)
                    {
                        Console.Write(c);
                        //Thread.Sleep(10);
                    }
            gameOn = false;
            }


        
    }
}
