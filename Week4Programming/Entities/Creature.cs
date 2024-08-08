using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Programming.Entities
{
    public abstract class Creature : Character
    {
        public Creature(string Name, double HealthPoints, int Level, double DodgeChance, int BaseDamage, List<string> Inventory) : 
            base(Name, HealthPoints, Level, DodgeChance, BaseDamage, Inventory) { }

        // Abstract method, no implementation - will be implemented in an derived classes
        public abstract void talk();

        // Concrete
        public void startDialogue()
        {
            Console.WriteLine($"Creature {Name} is speaking to you");
            talk();
        }
    }
}
