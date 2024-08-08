using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4Programming.Entities;

namespace Week4Programming.Encounters
{
    public abstract class Encounter
    {
        public double EncounterRate { get; set; }
        public bool Hostile { get; set; }
        public string Location { get; set; }
        public Character PrimaryCharacter { get; set; }
        public Character[] ListOfCharactersInEncounter { get; set; }
        public Encounter(double EncounterRate, bool Hostile, string Location, Character PrimaryCharacter, Character[] ListOfCharactersInEncounter) 
        {
            this.EncounterRate = EncounterRate;
            this.Hostile = Hostile;
            this.Location = Location;
            this.PrimaryCharacter = PrimaryCharacter;
            this.ListOfCharactersInEncounter = ListOfCharactersInEncounter;
        }

        public abstract bool Event();

        public abstract double determineRewards();

        public string giveQuest()
        {
            return Quest.assignQuest();
        }
    }
}
