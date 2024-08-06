using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Programming.Entities
{
    public class Boar : Creature
    {
        public override void talk()
        {
            Console.WriteLine("RAwDAOWDASDWAWDA");
            Console.WriteLine("*you are about to get charged* (Translation)");
        }

        public override void attack()
        {
            Console.WriteLine("Boar attack");
        }
    }
}
