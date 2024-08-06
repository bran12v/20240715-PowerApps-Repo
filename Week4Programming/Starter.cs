using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Programming
{
    public class Starter
    {
        public void Day1()
        {
            // point of entry for the program
            // Program.cs file, entry point for the program
            //Console.WriteLine("Hello World");

            // Data types
            /*
             * int - integers - whole numbers 4 bytes or 32 bits
             * long - larger numbers - whole number 8 bytes 64bits
             * float - store fractional numbers, 4bytes
             * double - "" - 8bytes
             * bool - true or false
             * char - single character
             * string - sequence of characters
             */

            int x = 0;

            // implicit and explicit type casting (change) int -> long
            long y = x; // implicit
            x = 'c';
            // char -> int -> long -> float -> double

            // Explicit type casting, larger to smaller
            double z = 3.6;
            int i = (int)z;
            //Console.WriteLine(i);
        }
    }
}
