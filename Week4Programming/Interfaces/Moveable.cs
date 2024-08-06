using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Programming.Interfaces
{
    public interface Moveable
    {
        // 100% abstract, no implementations
        // Framework
        public void move(int amount);

        public bool toggle();
    }
}
