﻿namespace FootballStats.Competitions
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
        //private static int personID = 1;

        private static bool isLoaded = false;

        public static void Load()
        {
            if (!isLoaded)
            {
                FootballStatsIO.LoadWorld();
                AssociatePersonsToClubs();
                //Players = FootballStatsIO.ParsePlayersFromPlayerTxt();
                //Staff = FootballStatsIO.ParsePlayersFromStaffMemberTxt();
                //Referees = FootballStatsIO.ParseRefereesFromRefereeTxt();
                //Clubs = FootballStatsIO.ParseClubInformation();
                isLoaded = true;
            }            
        }

        private static void AssociatePersonsToClubs()
        {
            foreach (var person in Players)
            {
                Associate(person);
            }
            foreach (var person in Staff)
            {
                Associate(person);
            }
        }
  
        private static void Associate(ClubAffiliatedPerson person)
        {
            if (person.AffiliatedClub != "Free Agent")
            {
                for (int i = 0; i < Clubs.Count; i++)
                {
                    if (Clubs[i].Name == person.AffiliatedClub)
                    {
                        if (person is Player)
                        {
                            Clubs[i].Team.Add(person as Player);
                            return;
                        }
                        else if (person is StaffMember)
                        {
                            Clubs[i].Staff.Add(person as StaffMember);
                            return;
                        }
                    }
                }
            }
        }

        public static void Save() 
        {
            FootballStatsIO.SaveWorld();
            //FootballStatsIO.SavePlayers(Players);
            //FootballStatsIO.SaveStaffMembers(Staff);
            //FootballStatsIO.SaveReferees(Referees);
            //FootballStatsIO.SaveClubInformation(Clubs);
        }

        //static World() 
        //{
           
            
        //    //ToDo: fix ID
        //    //personID = FootballStatsIO.ParsePlayersFromPlayerTxt().Count;
        //}
        
        //public static int PersonID
        //{
        //    get
        //    {
        //        return personID;
        //    }

        //    set
        //    {
        //        personID = value;
        //    }
        //}
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
