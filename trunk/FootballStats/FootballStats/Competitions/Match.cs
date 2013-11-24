namespace FootballStats.Competitions
{
    using System;
    using System.Collections.Generic;
    using FootballStats.Clubs;
    using FootballStats.Common;
    using FootballStats.Persons;

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
            this.FinalScore = finalScore;
            this.DateOfMatch = DateTime.Parse(dateOfMatch);
            this.HomeClub = homeClub;
            this.AwayClub = awayClub;
            this.homeTeam = homeClub.Team;
            this.awayTeam = awayClub.Team;
        }

        #region Properties

        public FinalScore FinalScore
        {
            get
            {
                return this.finalScore;
            }

            private set
            {
                this.finalScore = value;
            }
        }

        public DateTime DateOfMatch
        {
            get 
            { 
                return this.dateOfMatch;
            }

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
                        throw new Exception("Year must be in this [1950-2013] time frame!");
                    }
                }
                catch (InvalidCastException)
                {
                    throw new InvalidCastException("Incorrect Year!");
                }
            }
        }

        public Club HomeClub
        {
            get 
            {
                return this.homeClub;
            }

            private set 
            { 
                this.homeClub = value;
            }
        }

        public Club AwayClub
        {
            get
            { 
                return this.awayClub; 
            }

            private set 
            { 
                this.awayClub = value; 
            }
        }

        private Referee Referee
        {
            get
            {
                return this.referee;
            }

            set
            {
                this.referee = value;
            }
        }

        #endregion

        #region Methods

        public void SetReferee(Referee referee)
        {
            this.Referee = referee;
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

        #endregion

        public override string ToString()
        {
            if (this.referee != null)
            {
                string returnValue = string.Format("{0}\nReferee Name: {2}\n\nMATCH EVENTS\n{1}\nHOME TEAM:\n{3}\nAWAY TEAM:\n{4}",
                this.FinalScore.ToString(), this.matchEvents.ExtendedToString(), this.Referee.ToString(), this.homeTeam.ExtendedToString(), this.awayTeam.ExtendedToString());

                return returnValue.ToString();
            }
            else
            {
                string returnValue = string.Format("{0}\nMATCH EVENTS\n{1}\nHOME TEAM:\n{2}\nAWAY TEAM:\n{3}",
                this.FinalScore.ToString(), this.matchEvents.ExtendedToString(), this.homeTeam.ExtendedToString(), this.awayTeam.ExtendedToString());

                return returnValue.ToString();
            }
        }
    }
}
