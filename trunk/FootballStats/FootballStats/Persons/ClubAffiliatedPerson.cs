namespace FootballStats.Persons
{
    using System;
    using FootballStats.Common;

    public abstract class ClubAffiliatedPerson : Person, IClubAffiliated
    {
        private decimal weeklyWage = 0.0m;

        public ClubAffiliatedPerson(string firstName, string middleName, string lastName, string birthDate, Nationality nationality)
            : base(firstName, middleName, lastName, birthDate, nationality)
        {
        }

        public decimal WeeklyWage()
        {
            return this.weeklyWage;
        }

        public decimal MonthlyWage()
        {
            decimal dailyWage = this.weeklyWage / 7;
            return dailyWage * 30;
        }

        public decimal YearlyWage()
        {
            decimal monthlyWage = this.MonthlyWage();
            return monthlyWage * 12;
        }
        public void SetWeeklyWage(decimal wage)
        {
            if (wage <= 0 )
            {
                throw new ArgumentOutOfRangeException("Can't have negative or 0 amount for wage!");
            }

            this.weeklyWage = wage;
        }
    }
}
