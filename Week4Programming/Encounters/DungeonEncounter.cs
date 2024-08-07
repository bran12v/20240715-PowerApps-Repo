using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4Programming.Entities;
using Week4Programming.Exceptions;

namespace Week4Programming.Encounters
{
    public sealed class DungeonEncounter : Encounter
    {
        // Dynamic, assoicated with the Object.
        // it will change on a instance by instance basis
        public Difficulty DungeonDifficulty { get; set; }
        public int DungeonLevel { get; set; }
        public int NumOfRoomsInDungeon { get; set; }

        public DungeonEncounter(double EncounterRate, bool Hostile, string Location, Character PrimaryCharacter,
            Character[] ListOfCharactersInEncounter, Difficulty DungeonDifficulty, int DungeonLevel, int NumOfRoomsInDungeon) : 
            base(EncounterRate, true, Location, PrimaryCharacter, ListOfCharactersInEncounter)
        {
            this.DungeonDifficulty = DungeonDifficulty;
            this.DungeonLevel = DungeonLevel;
            this.NumOfRoomsInDungeon = NumOfRoomsInDungeon;
        }

        public override bool Event()
        {
            Random rnd = new Random();
            int randInt = rnd.Next(1, 4); // 1-3
            switch (randInt)
            {
                case 1:
                    bool cond = true;
                    int j = 0;
                    while (cond)
                    {
                        if (j >= 10) 
                        {
                            cond = false;
                        }
                        j++;
                        Console.WriteLine("IM LIVING IN YOUR WALLS"); // print 10
                    }
                    return true;
                case 2:
                    for (int i = 0; i < randInt; i++) // echo
                    {
                        Console.WriteLine("The wind howls through the tunnel walls... You hear something (or someone) in the distance");
                        string input = Console.ReadLine(); // happen twice
                        Console.WriteLine(input);
                    }
                    return true;
                case 3: // battle
                    Console.WriteLine("You have encounted the follow Creatures: ");
                    foreach (Character creature in ListOfCharactersInEncounter)
                    {
                        Console.WriteLine(creature.Name);
                    }
                    return false;
                default:
                    return false;
            }
        }

        public override double determineRewards()
        {
            double reward = (NumOfRoomsInDungeon + DungeonLevel) * 1.5;
            try
            {
                if (DungeonDifficulty == Difficulty.Easy)
                {
                    reward *= 0.5;
                }
                else if (DungeonDifficulty == Difficulty.Hard)
                {
                    reward *= 1.5;
                }
                else if (DungeonDifficulty == Difficulty.Medium)
                {
                    reward += 1;
                    throw new BaseDifficultyException("I CREATED THIS");
                }
                Console.WriteLine("This is your reward modifier: " + reward);

            }
            catch (BaseDifficultyException ex)
            {
                Console.WriteLine("All other exceptions: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("This always runs");
            }
            return reward * 50;
        }

        public override string giveQuest()
        {
            return Quest.assignQuest();
        }
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
}
