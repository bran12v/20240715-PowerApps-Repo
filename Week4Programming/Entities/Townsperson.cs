using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Programming.Entities
{
    public sealed class Townsperson : Creature
    {
        // collection, group of data structures that have Element acess, different performance profiles and grow and shrink dynamically
        public int MoveSpeed { get; set; }
        public const string Greeting = "Good day, my friend."; // constant - unchanging
        public double Gold { get; set; }
        public Player? player { get; set; }
        //private struct PersonValues // class within a class
        //{
        //    public int MoveSpeed { get; set; }
        //    public double Gold { get; set; }
        //    public PersonValues(int MoveSpeed, double Gold) 
        //    {
        //        this.MoveSpeed = MoveSpeed;
        //        this.Gold = Gold;
        //    }
        //}
        public Townsperson(List<string> Inventory, int MoveSpeed, double Gold, Player player, string Name, double HealthPoints,
            int Level, double DodgeChance, int BaseDamage) : base(Name, HealthPoints, Level, DodgeChance, BaseDamage, Inventory) 
        {
            this.Inventory = Inventory;
            this.MoveSpeed = MoveSpeed;
            this.Gold = Gold;
            this.player = player;
        }
        public override void talk()
        {
            Console.WriteLine(Greeting);
            bool running = true;
            while (running)
            {
                Console.WriteLine("What do you want of me? (Display, Repair or Trade)");
                switch (Console.ReadLine())
                {
                    case "Display":
                        displayInventory();
                        break;
                    case "Trade":
                        Console.WriteLine("What item would you like to sell?");
                        string item = Console.ReadLine();
                        Console.WriteLine("What is the Gold cost of that item?");
                        double gold = double.Parse(Console.ReadLine());
                        Console.WriteLine(trade(player, item!, gold));
                        break;
                    case "Repair":
                        Console.WriteLine("How much does this repair cost?");
                        double Rgold = double.Parse(Console.ReadLine());
                        Console.WriteLine(repair(player, player.Weapon!, Rgold));
                        break;
                }
                Console.WriteLine("Would you like to continue?");
                if (Console.ReadLine().Equals("no")) {
                    running = false;
                }
            }
        }

        public void displayInventory()
        {
            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine($"Inventory Item {i}: {Inventory[i]}");
            }
        }
        

        public string trade(Player player, string item, double gold)
        {
            if (!player.Inventory.Contains(item))
            {
                return "Are you serious? You can't sell something you don't even have? What is this? Car insurance?";
            }
            if (!Inventory.Contains(item))
            {
                if (Gold >= gold)
                {
                    Inventory.Add(item);
                    Gold -= gold;
                    player.Gold += gold;
                    player.Inventory.Remove(item);
                    return "That was a exquisite trade!";
                }
                else
                {
                    return "Sorry buddy, I'm broke";
                }

            }
            else
            { // is contained
                return "No chance. I already have that item!";
            }
        }

        // Pass by Reference by Value - Normal Objects
        // Pass by Reference by Reference - Normal Objects by using ref, out
        // Pass by Value by Value - Normal Structs
        // Pass by Value by Reference - Normal Structs by using ref, in, out
        public string repair(Player player, Weapon weapon, double gold) 
        {
            if (weapon != null)
            {
                weapon.Durability = 100.0;
                if (player.Gold >= gold)
                {
                    Gold += gold;
                    player.Gold -= gold;
                }
                return "Your weapon has been repaired!";
            }
            return "Please don't waste my time! No lollygagging.";
        }
    }
}
