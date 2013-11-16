using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballStats.Persons;
using FootballStats.Common;

namespace FootballStats.Clubs
{
    public interface IClubStats
    {
        double TeamAverageAge();
        int TotalPlayersAtClub();
        int TotalPlayersPerPosition(PlayerPosition position);
        bool HasManager();
        decimal AverageWageOfPlayers();
        decimal AverageWageOfStaff();
        decimal HighestPlayerWage();
        int CountPlayersWithSameNationality(Nationality nationality);
    }
}
