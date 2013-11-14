using System;
using System.Linq;
using FootballStats.Common;

namespace FootballStats.Persons
{
    public class Referee : Person
    {
        public Referee(string firstName, string middleName, string lastName, string birthDate, Nationality nationality)
            : base(firstName, middleName, lastName, birthDate, nationality)
        {
        }
    }
}
