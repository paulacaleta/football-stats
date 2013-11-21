namespace FootballStats.Competitions
{
    using FootballStats.Clubs;
    using FootballStats.Persons;
    using FootballStats.Common;
    using System;
    using System.Collections.Generic;
        
    public class Match
    {
        private DateTime dateOfMatch;
        private Club homeClub;
        private Club awayClub;

        private List<Player> homeTeam = new List<Player>();
        private List<Player> awayTeam = new List<Player>();
        private Referee referee;
        private List<MatchEvent> matchEvents = new List<MatchEvent>();

        public Match(Club homeClub, Club awayClub, string dateOfMatch) 
        {
            this.DateOfMatch = DateTime.Parse(dateOfMatch);
            this.homeClub = homeClub;
            this.awayClub = awayClub;
            this.homeTeam = homeClub.Team;
            this.awayTeam = awayClub.Team;
        }

        //properties
        public DateTime DateOfMatch 
        {
            get { return this.dateOfMatch; }
            private set 
            {
                try
                {
                    if (value.Year > 1950 && value.Year <= 2013)
                    {
                        this.dateOfMatch = value;
                    }
                    else
                    {
                        throw new Exception("Year must be in this [1950-2013] time frame.");
                    }
                }
                catch (InvalidCastException)
                {
                    throw new InvalidCastException("Inccorect Year");
                } 
            }
        }

        //Methods    

        public List<MatchEvent> GetEvents(EventType eventType)
        {
            List<MatchEvent> newEventList = new List<MatchEvent>();

            for (int i = 0; i < this.matchEvents.Count; i++)
            {
                if (this.matchEvents[i].EventType.Equals(eventType))
                {
                    newEventList.Add(this.matchEvents[i]);
                }
            }

            return newEventList;
        }
        public List<MatchEvent> GetAllEvents()
        {
            List<MatchEvent> newEventList = new List<MatchEvent>();

            for (int i = 0; i < this.matchEvents.Count; i++)
            {
                newEventList.Add(this.matchEvents[i]);
            }

            return newEventList;
        }
       
        public override string ToString()
        {
            string returnValue = String.Format("HOME TEAM:\n{0}\nAWAY TEAM:\n{1}", homeTeam.ExtendedToString(), awayTeam.ExtendedToString());

            return returnValue.ToString();
        }

    }
}
