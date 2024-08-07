// <--- means comment
// note: using
// import statements
using System;
using Week4Programming.Encounters;
using Week4Programming.Entities;

// namespace
namespace Week4Programming
{
    public class Program
    {
        public Character? Brandon;
        public Player? player;

        public static void Main(string[] args)
        {
            // static methods are called differently from normal methods
            Game.startGame();
            Program p = new Program();
            p.characterInit();
            while (Game.Running) 
            {
                Console.WriteLine("Where would you like to go first? (Town or Dungeon)");
                switch (Console.ReadLine())
                {
                    case "Dungeon":
                        Character boar = new Boar("bob", 17, 4, 0.05, 7);
                        Character slime = new Slime("bubble", 19, 5, 0.25, 5);

                        DungeonEncounter dungeon = new DungeonEncounter(1.0, true, "Muckdeep Caverns", p.player!, [boar, slime], Difficulty.Medium, 1, 3);

                        for (int i = 0; i < dungeon.NumOfRoomsInDungeon; i++)
                        {
                            dungeon.Event();
                        }

                        Console.WriteLine($"You have received: {dungeon.determineRewards()} Gold. \n Your next quest is: {dungeon.giveQuest()}");
                        break;

                    case "Town":
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
            Brandon = new Character("Brandon", 300, 12, 0.05, 10);
            player = new Player("NormalPerson", 13, 13, 0.1, 10, "Warrior", new Weapon(100.0, "Sword", 1, "Common", 7.0), false);
            //Brandon.move(10);
            //Brandon.attack();
        }

        public void restart()
        {
            characterInit();
            Console.WriteLine("Program reset");
        }
    }
}