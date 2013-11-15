using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStats.Clubs
{
    public interface IClubStats
    {
        double TeamAverageAge();
        int TotalPlayersAtClub();
        int TotalGoalkeepers();
        int TotalDefenders();
        int TotalForwards();
        bool HasManager();
        decimal AverageWage();
        decimal HighestWage();
    }
}
