using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballStats.Common;

namespace FootballStats.Competitions
{
    public class Competition
    {
        private string name;
        private Nationality nationality;
        private List<Season> seasons = new List<Season>();

        public Competition(string name, Nationality nationality)
        {
            this.name = name;
            this.nationality = nationality;
        }

        string Name
        {
            get { return this.name; }
        }

        public void AddSeason(Season season)
        {
            this.seasons.Add(season);
            // TODO: Implement
            // Adding season is only allowed if List is empty or previous season has finished
        }

        public bool HasSeason(Season season)
        {
            if (this.seasons.Contains(season))
            {
                return true;
            }
            return false;
        }

        // TODO: Return all-time top goalscorer
        // These methods will call the corresponding methods in the last finished season:
        // TODO: Return current champion (top-finished team of the last finished season)        
        // TODO: Return current table
        // TODO: Return ...
    }
}
