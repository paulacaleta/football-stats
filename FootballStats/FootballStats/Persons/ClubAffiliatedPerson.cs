﻿namespace FootballStats.Persons
{
    using System;
    using FootballStats.Common;
    using System.Text;

    public abstract class ClubAffiliatedPerson : Person, IClubAffiliated
    {
        private decimal weeklyWage = 0.0m;
        private string affiliatedClub;

        public ClubAffiliatedPerson(string firstName, string middleName, string lastName, string birthDate, Nationality nationality)
            : base(firstName, middleName, lastName, birthDate, nationality)
        {
            this.AffiliatedClub = "Free Agent";
        }

        public string AffiliatedClub
        {
            get { return this.affiliatedClub; }
            set { this.affiliatedClub = value; }
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
            if (wage < 0)
            {
                throw new ArgumentOutOfRangeException("Can't have negative amount for wage!");
            }

            this.weeklyWage = wage;
        }

        public override string Serialize()
        {
            StringBuilder serialized = new StringBuilder();

            serialized.Append(base.Serialize());

            serialized.Append(";");
            serialized.Append(this.weeklyWage+";");
            serialized.Append(this.AffiliatedClub);

            return serialized.ToString();
        }
    }
}
