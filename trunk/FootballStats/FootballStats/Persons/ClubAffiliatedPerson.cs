using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FootballStats.Common;
using FootballStats.Persons;

namespace FootballStats.Persons
{
    public abstract class ClubAffiliatedPerson : Person, IClubAffiliated
    {
        decimal weeklyWage;

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
            return this.MonthlyWage() * 12;
        }
        public void SetWeeklyWage(decimal wage)
        {
            this.weeklyWage = wage;
        }
    }
}
