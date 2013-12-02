namespace FootballStats.Clubs
{
    using FootballStats.Common;
    using FootballStats.Persons;

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
