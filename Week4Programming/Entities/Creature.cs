using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Programming.Entities
{
    public abstract class Creature : Character
    {


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
