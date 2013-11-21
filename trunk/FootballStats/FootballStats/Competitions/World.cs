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
        private static List<Competition> allCompetitions = new List<Competition>();
        private static int personID = 1;

        static public List<Club> AllClubs
        {
            get
            {
                return allClubs;
            }
        }

        static public List<Competition> AllCompetitions
        {
            get
            {
                return allCompetitions;
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

        public static void AddCompetition(Competition competition)
        {
            if (!allCompetitions.Contains(competition))
            {
                allCompetitions.Add(competition);
            }
            else
            {
                // TODO: Implement exception
                throw new NotImplementedException(); 
            }
        }

        public static void SaveWorld()
        {
            // TODO: Implement method
            throw new NotImplementedException();
        }

        public static void LoadWorld()
        {
            // TODO: Implement method
            throw new NotImplementedException();
        }
    }
}
