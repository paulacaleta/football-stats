using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballStats.Competitions;
using FootballStats.Persons;

namespace FootballStats.ViewModels
{
    public class ShowPersonsViewModel
    {
        public IEnumerable<Person> Persons
        {
            get
            {
                World.Load();
                return World.Persons;
            }
        }

        public IEnumerable<Person> FreeAgents
        {
            get
            {
                World.Load();
                List<ClubAffiliatedPerson> freeAgents = new List<ClubAffiliatedPerson>();
                foreach (var player in World.Players)
                {
                    if (player.AffiliatedClub == "Free Agent")
                    {
                        freeAgents.Add(player);
                    }
                }
                foreach (var staff in World.Staff)
                {
                    if (staff.AffiliatedClub == "Free Agent")
                    {
                        freeAgents.Add(staff);
                    }
                }
                return freeAgents;
            }
        }
    }
}
