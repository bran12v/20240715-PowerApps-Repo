using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4Programming.Interfaces;

namespace Week4Programming.Entities
{
    public class Player : Character, Moveable, Attackable
    {
        public string? ClassName { get; set; }
        public Weapon? Weapon { get; set; }
        public bool Run { get; set; }

        // This can be used as a constructor
        public Player() : this("bob", 1, 1, 0, 1, "rogue", new Weapon(70.2, "Dagger", 1, "Common", 4.5), true) { }

        // just like Base can
        public Player(string Name, double HealthPoints, int Level, double DodgeChance, int BaseDamage,
            string? ClassName, Weapon? Weapon, bool Run) : 
            base(Name, HealthPoints, Level, DodgeChance, BaseDamage) // refers to the parent con
        {
            this.ClassName = ClassName;
            this.Weapon = Weapon;
            this.Run = Run;
        }

        public bool toggle()
        {
            return !Run;
        }

        public void takeDamage(double amount)
        {
            if (amount > 0)
            {
                Console.WriteLine($"HP before attack: {HealthPoints}");
                HealthPoints = HealthPoints - amount * (1 - DodgeChance); // 0 - 1
                Console.WriteLine($"Current HP: {HealthPoints}");
            }
            else
            {
                Console.WriteLine("Took no damage");
            }
            Console.WriteLine($"We counter attack for {counterAttack()} damage");
        }

        public double counterAttack()
        {
            double dmg = BaseDamage;
            if (Weapon != null)
            {
                dmg += Weapon.DamageLevel;
            }
            return dmg;
        }
    }
}
