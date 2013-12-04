using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballStats.Clubs;
using FootballStats.Competitions;

namespace FootballStats.ViewModels
{
    public class ShowClubsViewModel
    {
        public IEnumerable<Club> Clubs
        {
            get
            {
                World.Load();
                return World.Clubs;
            }
        }
    }
}
