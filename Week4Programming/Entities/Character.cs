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


    public class Character
    {
        // fields (characteristics) has
        public string Name { get; set; } // syntaxic sugar
        public double HealthPoints { get; set; }
        //public int Level { 
        //    get {
        //        return 1;
        //    }
        //    set
        //    {
        //        Level = 1;
        //    }
        //}
        public int Level { get; set; }
        public double DodgeChance { get; set; }
        public int BaseDamage { get; set; }

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
    }
}
