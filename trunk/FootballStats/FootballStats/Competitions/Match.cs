namespace FootballStats.Competitions
{
    using FootballStats.Clubs;
    using FootballStats.Persons;
    using FootballStats.Common;
    using System;
    using System.Collections.Generic;
        
    public class FinalScore
    {
        int homeTeam;
        int awayTeam;
        public int HomeTeam
        {
            get { return this.homeTeam; }
            set 
            {
                if (value > 0)
                {
                    this.homeTeam = value; 
                }
                else
                {
                    throw new Exception("Score can't be negative");
                }
            }
        }
        public int AwayTeam
        {
            get { return this.awayTeam; }
            set
            {
                if (value > 0)
                {
                    this.awayTeam = value;
                }
                else
                {
                    throw new Exception("Score can't be negative");
                }
            }
        }

        public FinalScore(int homeTeam, int awayTeam)
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
        }

        public override string ToString()
        {
            string returnValue = String.Format("FINAL GAME SCORE IS: {0}/{1}\n", homeTeam, awayTeam);
            return returnValue.ToString();
        }
    }

    public class Match : IMatchStats
    {
        private FinalScore finalScore;
        private DateTime dateOfMatch;
        private Club homeClub;
        private Club awayClub;
        private List<Player> homeTeam = new List<Player>();
        private List<Player> awayTeam = new List<Player>();
        private Referee referee;
        private List<MatchEvent> matchEvents = new List<MatchEvent>();

        public Match(Club homeClub, Club awayClub, string dateOfMatch, FinalScore finalScore) 
        {
            this.finalScore = finalScore;
            this.DateOfMatch = DateTime.Parse(dateOfMatch);
            this.HomeClub = homeClub;
            this.AwayClub = awayClub;
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
        public Club HomeClub 
        {
            get { return this.homeClub; }
            private set { this.homeClub = value; }
        }
        public Club AwayClub 
        {
            get { return this.awayClub; }
            private set { this.awayClub = value; }
        }

        //Methods    
        public void SetReferee(Referee referee) 
        {
            this.referee = referee;
        }
        public void AddEvents(MatchEvent newEvent)
        {
            this.matchEvents.Add(newEvent);
        }
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
        public string GetFinalScore() 
        {
            return this.finalScore.ToString();
        }
       
        public override string ToString()
        {
            if (this.referee != null)
            {
                string returnValue = String.Format("{0}\nReferee Name: {2}\n\nMATCH EVENTS\n{1}\nHOME TEAM:\n{3}\nAWAY TEAM:\n{4}",
                finalScore.ToString(), matchEvents.ExtendedToString(), referee.ToString(), homeTeam.ExtendedToString(), awayTeam.ExtendedToString());

                return returnValue.ToString();
            }
            else
            {
                string returnValue = String.Format("{0}\nMATCH EVENTS\n{1}\nHOME TEAM:\n{2}\nAWAY TEAM:\n{3}",
                finalScore.ToString(), matchEvents.ExtendedToString(), homeTeam.ExtendedToString(), awayTeam.ExtendedToString());

                return returnValue.ToString();
            }
        }
    }
}
