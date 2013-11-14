namespace FootballStats.Persons
{
    using System;
    using FootballStats.Common;

    public abstract class Person : IPerson
    {
        Name name;
        DateTime birthDate;
        Nationality nationality;

        protected Person(Name name, DateTime birthDate, Nationality nationality)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.Nationality = nationality;
        }

        public Name Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }

            set
            {
                // TODO: Check for inappropriate input
                this.birthDate = value;
            }
        }

        public Nationality Nationality
        {
            get
            {
                return this.nationality;
            }

            set
            {
                this.nationality = value;
            }
        }

        public int GetAge()
        {
            // Age is calculated up to the current moment
            // TODO: Improve at later stage
            return (int)(((DateTime.Now - BirthDate).TotalDays) / 365);
        }
    }
}
