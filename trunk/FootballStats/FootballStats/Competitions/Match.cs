namespace FootballStats.Competitions
{
    using FootballStats.Clubs;
    using FootballStats.Persons;
    using System;
    using System.Collections.Generic;
        
    public class Match : IMatchStats
    {
        private Competition competition;
        private Season season;
        private DateTime dateOfMatch;
        private Club homeClub;
        private Club awayClub;
        private List<Player> homeTeam = new List<Player>();
        private List<Player> awayTeam = new List<Player>();
        private Referee referee;
        private List<MatchEvent> matchEvents = new List<MatchEvent>();
        
        public void SetCompetition(Competition competition)
        {
            if (World.AllCompetitions.Contains(competition))
            {
                this.competition = competition;
            }
            else
            {
                // TODO: Implement exception
                throw new NotImplementedException();
            }
        }

        public void SetSeason(Season season)
        {
            this.season = season;
            return;
            // TODO: Implement this method
            // Note: season must be an existing one - use HasSeason method in Competition class
            throw new NotImplementedException();
        }

        public void SetTeams(Club homeTeam, Club awayTeam)
        {
            if (this.season == null)
            {
                // TODO: Implement this exception "Must set season"
                throw new NotImplementedException();
            }
            if (this.season.ContainsClub(homeTeam))
            {
                this.homeClub = homeTeam;
            }
            else
            {
                // TODO: Implement this exception
                throw new NotImplementedException();
            }

            if (this.season.ContainsClub(awayTeam))
            {
                this.awayClub = awayTeam;
            }
            else
            {
                // TODO: Implement this exception
                throw new NotImplementedException();
            }
        }

        public void AddEvent(MatchEvent ev)
        {
            this.matchEvents.Add(ev);
            // TODO: Implement this method
            //throw new NotImplementedException();
        }

        public void AddPlayerToList(Player player, Club club)
        {
            if (club != this.homeClub && club != this.awayClub)
            {
                // TODO: Implement this
                throw new NotImplementedException();
            }
            if (club.ContainsPlayer(player))
            {
                if (club == homeClub)
                {
                    homeTeam.Add(player);
                    return;
                }
                else if (club == awayClub)
                {
                    awayTeam.Add(player);
                    return;
                }
            }
            // TODO: Implement this exception
            throw new NotImplementedException();
        }

        public void RemovePlayerFromList(Player player, List<Player> team)
        {
            if (team != this.homeTeam && team != this.awayTeam)
            {
                // TODO: Implement this exception
                throw new NotImplementedException();
            }
            if (team.Contains(player))
            {
                for (int i = 0; i < team.Count; i++)
                {
                    if (team[i] == player)
                    {
                        team.RemoveAt(i);
                    }
                }
                return;
            }
            // TODO: Implement this exception
            throw new NotImplementedException();
        }

        public void SetDate(DateTime date)
        {
            this.dateOfMatch = date;
            // TODO: Implement an exception
            throw new NotImplementedException();
        }

        public void SetReferee(Referee referee)
        {
            if (this.season.ContainsReferee(referee))
            {
                this.referee = referee;
            }
            // TODO: Implement an exception
            throw new NotImplementedException();
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

        public void CompleteMatch()
        {
            this.season.AddMatch(this);
        }
    }
}
