using FootballStats.Clubs;
using FootballStats.Persons;
using System;
using System.Text;
using System.Collections.Generic;
using FootballStats.Common;

namespace FootballStats.Competitions
{
    public class Season
    {
        private string season;
        private int totalTeams;

        private List<Club> participatingClubs = new List<Club>();
        private List<Referee> referees = new List<Referee>();        
        private List<Match> matches = new List<Match>();
        
        public Season(string season)
        {
            // TODO: must be unique number! There shouldn't be seasons with identical ID's
            this.season = season;
        }

        public string SeasonID 
        {
            get { return this.season; }
        }

        public List<Match> Matches
        {
            get
            {
                return this.matches;
            }
        }

        public void AddClub(Club club)
        {
            this.participatingClubs.Add(club);
            // TODO: Method that adds an existing club
        }        
        
        public void AddReferee(Referee referee)
        {
            // TODO: Implement this method
            // Referee must be an exiting one. Can't be implemented right now!
            this.referees.Add(referee);
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

        public override string ToString()
        {

            //TODO : Implement more statistical information.

            string formating = String.Format(new string('-',80));
            string clubList = null;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LIST OF ALL TEAMS:");
            sb.AppendLine(formating);

            for (int i = 0; i < this.participatingClubs.Count; i++)
            {
                sb.Append(participatingClubs[i].Name);
                sb.Append('\n');
            }
            
            sb.AppendLine(formating);
            sb.AppendLine("LIST OF ALL REFEREES:");
            sb.AppendLine(formating);

            for (int i = 0; i < this.referees.Count; i++)
            {
                sb.Append(referees[i].ToString());
                sb.Append('\n');
            }

            sb.AppendLine(formating);
            sb.AppendLine("LIST OF ALL MATCH SCORES:");
            sb.AppendLine(formating);

            for (int i = 0; i < this.matches.Count; i++)
            {
                sb.Append(String.Format("{0} vs {1}\n{2}", matches[i].HomeClub.Name, matches[i].AwayClub.Name,matches[i].GetFinalScore() ));
            }
            clubList = sb.ToString();
            
            string returnValue = String.Format("{0}\n",
                clubList);

            return returnValue.ToString();
        }
    }
}
