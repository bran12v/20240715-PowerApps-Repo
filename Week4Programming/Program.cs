// <--- means comment
// note: using
// import statements
using System;
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
            //Console.WriteLine("Please choose what action you would like to take: (Create, move)");
            //String input = Console.ReadLine();
            //Character newCharacter = null;
            //if (input != null && (input.Equals("Create") || input.Equals("Move")))
            //{
            //    if (input.Equals("Create"))
            //    {
            //        Console.WriteLine("Enter your Characters name: ");
            //        String name = Console.ReadLine();
            //        newCharacter = new Character();
            //        newCharacter.Name = name;
            //        Console.WriteLine($"{newCharacter.Name}");
            //    }
            //    if (input.Equals("Move"))
            //    {
            //        // TODO
            //    }
            //}

            Character boar = new Boar(); // polymorphism - many forms
            boar.Name = "bob";
            Character slime = new Slime();
            slime.Name = "harrison";

            Character[] array = new Character[2];
            array[0] = boar;
            array[1] = slime;

            Console.WriteLine($"Here are our 2 creatures! We have {array[0].Name} and {array[1].Name}");
            array[0].attack();
            array[1].attack();
        }

        public void characterInit()
        {
            Brandon = new Character();
            Brandon.Name = "Brandon";
            Brandon.Level = 300;
            Brandon.HealthPoints = 12;
            Brandon.DodgeChance = 0.05;
            Brandon.BaseDamage = 10;
            Brandon.move(10);
            Brandon.attack();

            player = new Player();
            player.Weapon = new Weapon();
            player.Weapon.DamageLevel = 2;
            player.Name = "Jaydon";
            player.Level = 299;
            player.HealthPoints = 13;
            player.DodgeChance = 0.1;
            player.BaseDamage = 10;
            player.ClassName = "warrior";
            player.Run = false;
        }

        public void restart()
        {
            characterInit();
            Console.WriteLine("Program reset");
        }
    }
}