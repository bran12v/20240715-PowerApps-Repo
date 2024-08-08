using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4Programming.Entities;

namespace Week4Programming.Encounters
{
    /*
     * This town encounter is part of a group of encounters that a player can experience if
     * they choose this item from the option list
     * etc
     * etc
     * 
     */
    public class TownEncounter: Encounter
    {
        // this is a reference to the person in the town
        public Townsperson person { get; set; }
        // This private class represents the person's house
        private class House
        {
            public int rooms { get; set; }
        }
        // This is a reference to the TownsPerson's house
        private House house { get; set; }
        // This is the constructor for the Town Encounter
        public TownEncounter(double EncounterRate, bool Hostile, string Location, Character PrimaryCharacter,
            Character[] ListOfCharactersInEncounter, Townsperson person) :
            base(EncounterRate, true, Location, PrimaryCharacter, ListOfCharactersInEncounter) 
        {
            this.person = person;
            house = new House();
            house.rooms = 1;
        }

         /* Implementation of the Event method from the encounter class
          * Where the player character talks to the person in the town
          */
        public override bool Event()
        {
            person.talk();
            return true;
        }
        /*
         * Towns do not have any monsters so there are no additional rewards for clearing the town encounter
         */
        public override double determineRewards()
        {
            Console.WriteLine("You have finished with this village. You find no more items of value here.");
            return 0;
        }
    }
}
