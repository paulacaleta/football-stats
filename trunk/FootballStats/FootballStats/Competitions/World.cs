namespace FootballStats.Competitions
{
    using System;
    using System.Collections.Generic;
    using FootballStats.Clubs;
    using FootballStats.Common;
using FootballStats.Persons;

    public static class World
    {        
        public static List<Club> Clubs = new List<Club>();
        public static List<Person> Persons = new List<Person>();
        private static int personID = 1;
        
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
            if (!Clubs.Contains(club))
            {
                Clubs.Add(club);                
            }
            else
            {
                string message = string.Format("{0} is already exists!", club);
                throw new InvalidClubException(message); 
            }            
        }
    }
}
