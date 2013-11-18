using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballStats.Clubs;
using FootballStats.Persons;

namespace FootballStats.Competitions
{
    public class Season
    {
        private int identificator;
        private Competition competition;
        private int totalTeams;
        private List<Club> participatingClubs;
        private List<Referee> referees;        
        private DateTime startDate;
        private DateTime endDate;
        
        public Season(int identificator)
        {
            // TODO: must be unique number! There shouldn't be seasons with identical ID's
            this.identificator = identificator;
        }

        // TODO: Method that sets the competition to an existing one

        // TODO: Method that sets max number of teams

        // TODO: Method that adds an existing club
        
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
    }
}
