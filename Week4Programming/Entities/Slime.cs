﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Programming.Entities
{
    public class Slime : Creature
    {
        public override void talk()
        {
            Console.WriteLine("Bubblebubblebubblebubblebubblebubblebubblebubble");
            Console.WriteLine("I will achieve victory even at the cost of my very life (Translation)");
        }

        public override void attack()
        {
            Console.WriteLine("Slime attack");
        }
    }
}
