using System;
using System.Collections.Generic;
using System.Linq;
using FootballStats.Clubs;
using FootballStats.Persons;

namespace FootballStats.Competitions
{
    public static class World
    {        
        private static List<Club> allClubs = new List<Club>();
        private static int personID = 1;

        static public List<Club> AllClubs
        {
            get
            {
                return allClubs;
            }
        }

        public static int PersonID
        {
            get
            {
                return personID;
            }

            set
            {
                personID = value;
            }
        }

        public static void AddClub(Club club)
        {
            if (!allClubs.Contains(club))
            {
                allClubs.Add(club);
                
            }
            else
            {
                // TODO: Implement exception
                throw new NotImplementedException(); 
            }            
        }
    }
}
