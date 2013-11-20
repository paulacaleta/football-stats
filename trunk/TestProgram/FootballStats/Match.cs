using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStats
{
    public class Match
    {
        string homeTeamName;
        string awayTeamName;
        private List<Player> homeTeam = new List<Player>();
        private List<Player> awayTeam = new List<Player>();

        public Match(Club homeTeam, Club awayTeam) 
        {
            this.homeTeamName = homeTeam.GetName();
            this.awayTeamName = awayTeam.GetName();
            this.homeTeam = homeTeam.GetTeam();
            this.awayTeam = awayTeam.GetTeam();
        }

        //Methods
        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            string nameOfClub = String.Format("Home team: {0}\n", this.homeTeamName);

            returnValue.Append(nameOfClub);
            foreach (var player in homeTeam)
            {
                returnValue.Append(player.ToString());
                returnValue.Append("\n");
            }
            returnValue.Append("\n");
            nameOfClub = String.Format("Home team: {0}\n", this.awayTeamName);

            returnValue.Append(nameOfClub);
            foreach (var player in awayTeam)
            {
                returnValue.Append(player.ToString());
                returnValue.Append("\n");
            }
            

            return returnValue.ToString();
        }
    }
}
