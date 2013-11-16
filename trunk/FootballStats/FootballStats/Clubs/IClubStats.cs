using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballStats.Persons;

namespace FootballStats.Clubs
{
    public interface IClubStats
    {
        double TeamAverageAge();
        int TotalPlayersAtClub();
        int TotalPlayersPerPosition(PlayerPosition position); // TODO: Implement this method
        bool HasManager();
        decimal AverageWageOfPlayers();
        decimal AverageWageOfStaff();
        decimal HighestPlayerWage();
    }
}
