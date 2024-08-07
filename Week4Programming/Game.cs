using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Programming
{
    public static class Game
    {
        public static bool Running { get; set; } = true;
        public const bool ex = true; // constant, cant be changed


        // Static - be the same, regardless of the object
        // associated with the class itself, not the object
        public static void startGame()
        {
            Console.WriteLine("Game is starting...");
            Console.WriteLine("Initialization finished!");
        }
    }
}
