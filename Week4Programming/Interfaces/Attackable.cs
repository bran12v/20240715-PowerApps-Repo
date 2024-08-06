using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Programming.Interfaces
{
    public interface Attackable
    {
        public void takeDamage(double amount);
        public double counterAttack();
    }
}
