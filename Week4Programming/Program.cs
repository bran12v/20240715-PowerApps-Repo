// <--- means comment
// note: using
// import statements
using System;
using Week4Programming.Encounters;
using Week4Programming.Entities;

// namespace
namespace Week4Programming
{
    public class Program // Design Pattern: Singleton
    {
        public Character? Brandon;
        public Player? player;
        public Townsperson? townsPerson;
        private const string csvFileLocation = @"C:\Users\SSAdmin\Downloads\ExampleCSV.csv";
        private Program() { }

        private struct Position
        {
            int x { get; set; }
            int y { get; set; }
            int z { get; set; }
            public Position(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        public static void Main(string[] args)
        {
            // static methods are called differently from normal methods
            Game.startGame();
            Program p = new Program();
            p.characterInit();
            Position pos = new Position(1,2,3); // geometric position values with structs
            while (Game.Running) 
            {
                Console.WriteLine("Where would you like to go first? (Town or Dungeon)");
                switch (Console.ReadLine())
                {
                    case "Dungeon":
                        Character boar = new Boar("bob", 17, 4, 0.05, 7, new List<string>());
                        Character slime = new Slime("bubble", 19, 5, 0.25, 5, new List<string>());

                        DungeonEncounter dungeon = new DungeonEncounter(1.0, true, "Muckdeep Caverns", p.player!, [boar, slime], Difficulty.Medium, 1, 3);

                        for (int i = 0; i < dungeon.NumOfRoomsInDungeon; i++)
                        {
                            dungeon.Event();
                        }

                        Console.WriteLine($"You have received: {dungeon.determineRewards()} Gold. \n Your next quest is: {dungeon.giveQuest()}");
                        break;

                    case "Town":
                        TownEncounter town = new TownEncounter(0.5, false, "Shady Sands", p.player, [p.townsPerson], p.townsPerson);
                        town.Event();
                        Console.WriteLine($"{town.determineRewards()} \n Your next quest is: {town.giveQuest()}");
                        break;

                    default:
                        break;
                }

                Console.WriteLine("Would you like to continue? (yes or no)");
                if(Console.ReadLine()!.Equals("no"))
                {
                    Game.Running = false;
                }
            }
        }
        public void characterInit()
        {
            // CSV parsing to read inventory data TODO

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            using StreamReader reader = new StreamReader(csvFileLocation);
            for (int i = 0; !reader.EndOfStream; i++)
            {
                if (i == 0)
                {
                    reader.ReadLine();
                    continue;
                }
                string line = reader.ReadLine();

                // a comma separated string array with the info from the CSV
                string[] row = line.Split(",");

                // logic to created a list out of the string array
                List<string> list = new List<string>();
                for (int j = 1; j < row.Length; j++)
                {
                    list.Add(row[j]);
                }
                dict.Add(row[0], list);
            }

            Brandon = new Character("Brandon", 300, 12, 0.05, 10, dict["Character"]);
            //Console.WriteLine(Brandon.Inventory[0]);

            player = new Player("NormalPerson", 13, 13, 0.1, 10, "Warrior", new Weapon(100.0, "Sword", 1, "Common", 7.0),
                false, 100, dict["Player"]);
            //Console.WriteLine(player.Inventory[0]);

            townsPerson = new Townsperson(dict["TownsPerson"], 1, 100, player, "bob", 10, 3, 0.01, 10);
            //Console.WriteLine(townsPerson.Inventory[0]);
        }

        public void restart()
        {
            characterInit();
            Console.WriteLine("Program reset");
        }
    }
}