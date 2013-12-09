namespace FootballStats.Persons
{
    public interface IClubAffiliated
    {
        decimal WeeklyWage();

        decimal MonthlyWage();

        decimal YearlyWage();

        void SetWeeklyWage(decimal wage);

        // TODO: Return club or none if unemployed
        // void ChangeClub(Club newClub);
    }
}
