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
        public IEnumerable<Person> Players
        {
            get
            {
                World.Load();
                return World.Players;
            }
        }

        public IEnumerable<Person> FreeAgentPlayers
        {
            get
            {
                World.Load();
                List<Player> freePlayers = new List<Player>();
                foreach (var player in World.Players)
                {
                    if (player.AffiliatedClub == "Free Agent")
                    {
                        freePlayers.Add(player);
                    }
                }
                return freePlayers;
            }
        }
    }
}
