using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStats
{
	public class Club
	{
		private List<Player> team = new List<Player>();
		private string name;

		public Club(string name, List<Player> team)
		{
			this.name = name;
			this.team = team;
		}

        public List<Player> GetTeam() 
        {
            return this.team;
        }

        public string GetName() 
        {
            return this.name;
        }

		public override string ToString()
		{
			string teamToPrint = null;
            StringBuilder sb = new StringBuilder();

			foreach (var item in team)
			{
                sb.Append(item.ToString());
                sb.Append("\n");
			}

            teamToPrint = sb.ToString();

			string returnValue = String.Format("Team name: {0}\n{1}", name, teamToPrint);

			return returnValue.ToString();
		}
	}
}
