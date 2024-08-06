using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Programming.Entities
{
    public class Weapon
    {
        public double Durability { get; set; }
        public string? Type { get; set; }
        public int DamageLevel { get; set; }
        public string? Rarity { get; set; }
        public double Weight { get; set; }
    }
}
