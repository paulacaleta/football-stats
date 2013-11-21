using FootballStats.Clubs;
using FootballStats.Persons;
using System;
using System.Collections.Generic;

namespace FootballStats.Competitions
{
    public class Season
    {
        private int identificator;
        private Competition competition = null;
        // private int totalTeams;
        private List<Club> participatingClubs = new List<Club>();
        private List<Referee> referees = new List<Referee>();        
        // private DateTime startDate;
        // private DateTime endDate;
        private List<Match> matches = new List<Match>();
        
        public Season(int identificator)
        {
            // TODO: must be unique number! There shouldn't be seasons with identical ID's
            this.identificator = identificator;
        }
        
        // TODO: Method that returns the goal scorers and the total goals each player has scored

        public List<Match> Matches
        {
            get
            {
                return this.matches;
            }
        }

        public void SetCompetition(Competition competition)
        {
            // TODO: Method that sets the competition to an existing one.
            this.competition = competition;            
        }

        // TODO: Method that sets max number of teams

        public void AddClub(Club club)
        {
            this.participatingClubs.Add(club);
            // TODO: Method that adds an existing club
        }
        
        
        public void AddReferee(Referee referee)
        {
            // TODO: Implement this method
            // Referee must be an exiting one. Can't be implemented right now!
            throw new NotImplementedException();
        }

        public void SetTimespan(DateTime startDate, DateTime endDate)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
        
        public bool ContainsClub(Club club)
        {
            if (this.participatingClubs.Contains(club))
            {
                return true;
            }
            return false;
        }

        public bool ContainsReferee(Referee referee)
        {
            if (this.referees.Contains(referee))
            {
                return true;
            }
            return false;
        }

        public void AddMatch(Match match)
        {
            this.matches.Add(match);
        }
    }
}
