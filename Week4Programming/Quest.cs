using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Programming
{
    public static class Quest
    {
        public static string[] Quests { get; private set; } = 
            { "Clear MuckDeep Cavern", "Talk to Townsfolk", "Complete Battle", "Herb Gathering", "Collect 10 Boar Hides" };
        public static int NumberOfQuests { get; private set; } = Quests.Length;

        public static string assignQuest()
        {
            return Quests[new Random().Next(0, NumberOfQuests)]; // Get random quest text from list
        }
    }
}
