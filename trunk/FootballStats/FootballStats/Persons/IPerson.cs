using System;
using System.Linq;

namespace FootballStats.Persons
{
    public interface IPerson
    {
        Name Name { get; }
        Nationality Nationality { get; }

        int GetAge();
    }
}
