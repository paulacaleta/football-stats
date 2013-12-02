namespace FootballStats.Competitions
{
    using System;
    using System.Collections.Generic;
    using FootballStats.Clubs;
    using FootballStats.Common;
using FootballStats.Persons;
    using FootballStats.IO;

    public static class World
    {        
        public static List<Club> Clubs = new List<Club>();
        public static List<Player> Players = new List<Player>();
        public static List<StaffMember> Staff = new List<StaffMember>();
        public static List<Referee> Referees = new List<Referee>();
        private static int personID = 1;

        private static bool isLoaded = false;

        public static void Load()
        {
            if (!isLoaded)
            {
                Players = FootballStatsIO.ParsePlayersFromPlayerTxt();
                Staff = FootballStatsIO.ParsePlayersFromStaffMemberTxt();
                Referees = FootballStatsIO.ParseRefereesFromRefereeTxt();
            }            
        }

        public static void Save() 
        {
            FootballStatsIO.SavePlayers(Players);
            FootballStatsIO.SaveStaffMembers(Staff);
            FootballStatsIO.SaveReferees(Referees);
        }

        //static World() 
        //{
           
            
        //    //ToDo: fix ID
        //    //personID = FootballStatsIO.ParsePlayersFromPlayerTxt().Count;
        //}
        
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
