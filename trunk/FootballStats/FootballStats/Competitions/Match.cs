namespace FootballStats.Competitions
{
    using FootballStats.Clubs;
using FootballStats.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Match : IMatchStats
    {
        private Competition competition;
        private Season season;
        private DateTime dateOfMatch;
        private Club homeClub;
        private Club awayClub;
        private List<Player> homeFirstTeam = new List<Player>();
        private List<Player> awayFirstTeam = new List<Player>();
        private List<Player> homeReserves = new List<Player>();
        private List<Player> awayReserves = new List<Player>();
        private Referee referee;
        private List<MatchEvent> matchEvents = new List<MatchEvent>();
                
        public void SetCompetition(Competition competition)
        {
            // TODO: Implement this method
            // Note: Competition must be an existing one. Can't be implemented right now!
            throw new NotImplementedException();
        }

        public void SetSeason(Season season)
        {
            // TODO: Implement this method
            // Note: season must be an existing one- use HasSeason method in Competition class
            throw new NotImplementedException();
        }

        public void SetTeams(Club homeTeam, Club awayTeam)
        {
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

        public void AddEvent()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void AddPlayerToList(Player player, Club club, string team)
        {
            if (club != this.homeClub && club != this.awayClub)
            {
                 // TODO: Implement this
                throw new NotImplementedException();
            }
            if (team != "first" && team != "reserves")
            {
                // TODO: Implement this
                throw new NotImplementedException();
            }
            if (club.ContainsPlayer(player))
            {
                if (club == homeClub)
                {
                    if (team == "first")
                    {
                        homeFirstTeam.Add(player);
                    }
                    else if (team == "reserves")
                    {
                        homeReserves.Add(player);
                    }
                    return;
                }
                else if (club == awayClub)
                {
                    if (team == "first")
                    {
                        awayFirstTeam.Add(player);
                    }
                    else if (team == "reserves")
                    {
                        awayReserves.Add(player);
                    }
                    return;
                }
            }
            // TODO: Implement this exception
            throw new NotImplementedException();
        }

        public void RemovePlayerFromList(Player player, List<Player> team)
        {
            if (team != this.homeFirstTeam && team != this.homeReserves
                && team != this.awayFirstTeam && team != this.awayReserves)
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
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public List<MatchEvent> GetAllEvents()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
