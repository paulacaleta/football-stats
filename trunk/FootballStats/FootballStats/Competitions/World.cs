namespace FootballStats.Competitions
{
    using System;
    using System.Collections.Generic;
    using FootballStats.Clubs;
    using FootballStats.Common;

    public static class World
    {        
        private static List<Club> allClubs = new List<Club>();
        private static int personID = 1;

        public static List<Club> AllClubs
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
                string message = string.Format("{0} is already exists!", club);
                throw new InvalidClubException(message); 
            }            
        }
    }
}
