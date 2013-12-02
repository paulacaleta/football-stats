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
                return World.Players;
            }
        }
    }
}
