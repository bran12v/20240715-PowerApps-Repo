using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * OOP (Object Orient Programming)
 * 
 * 4 Pillars
 * Encasulation - security
 * Access Modifiers
 * Determine the lvl of access to the resource
 * 
 * Public - Everything
 * Private - Just class
 * Protected - Just class or derived classes
 * Internal - only code in the same assembly (compilation) .exe .dll
 * Protected Internal - Just class or derived classes in the same/different assembly
 * Private Protected - Just class or derived classes in the same assembly
 * File - Just the file
 * 
 * 
 * Inheritance
 * 
 * Polymorphism
 * 
 * Abstraction
 */


namespace Week4Programming.Entities
{
    public class Character : IComparable//, IEnumerable // for each
    {
        // fields (characteristics) has
        public string Name { get; set; } // syntaxic sugar
        public double HealthPoints { get; set; }
        public int Level { get; set; }
        public double DodgeChance { get; set; }
        public int BaseDamage { get; set; }
        public List<string> Inventory { get; set; } // Generic

        // contructor, has the same name as the class. 
        // doesn't have a return type
        public Character() // default contructor
        {
            Name = "Rookie";
            HealthPoints = 1;
            Level = 1;
            DodgeChance = 0;
            BaseDamage = 1;
            Inventory = new List<string>();
        }

        // constructor overloading
        public Character(string Name, double HealthPoints, int Level, double DodgeChance, int BaseDamage, List<string> Inventory)
        {
            this.Name = Name; // this is a reference to the class, it's how you get the fields of THIS CLASS
            this.HealthPoints = HealthPoints;
            this.Level = Level;
            this.DodgeChance = DodgeChance;
            this.BaseDamage = BaseDamage;
            this.Inventory = Inventory;
        }

        // methods (actions) can do
        public void move(int amount)
        {
            //Console.WriteLine("Moved" + amount +  "step"); // java way
            Console.WriteLine($"Moved {amount} steps"); // string literal way
        }

        // virtual - checks the implementation at runtime based on derived classes
        public virtual void attack()
        {
            Console.WriteLine("Attacking");
        }

        // implement a method to compare an object to the character class
        public int CompareTo(object? to)
        {
            if (this == null || to == null)
            {
                return 1;
            }
            if (this.GetType() != to.GetType()) 
            {
                return 1; 
            }
            else
            {
                Character toCharacter = (Character) to;
                if (this.Name.Equals(toCharacter!.Name))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        // MoveNext()
        // Current
        // Reset()
    }
}
