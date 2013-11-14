namespace FootballStats.Persons
{
    using System;
    using FootballStats.Common;
    using System.Text;

    public abstract class Person : IPerson
    {
        Name name;
        DateTime birthDate;
        Nationality nationality;

        protected Person(string firstName, string middleName, string lastName, string birthDate, Nationality nationality)
        {
            Name name = new Name();
            name.FirstName = firstName;
            name.MiddleName = middleName;
            name.LastName = lastName;
            this.Name = name;
            this.BirthDate = DateTime.Parse(birthDate);
            this.Nationality = nationality;
        }

        public Name Name
        {
            private get
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

        public string GetName()
        {
            StringBuilder name = new StringBuilder();
            name.Append(this.Name.FirstName);
            if (this.Name.MiddleName != null)
            {
                name.AppendFormat(" {0}", this.Name.MiddleName);
            }
            name.AppendFormat(" {0}", this.Name.LastName);
            return name.ToString();
        }

        public void ChangeName(string firstName, string middleName, string lastName)
        {
            Name newName = new Name();
            newName.FirstName = firstName;
            newName.MiddleName = middleName;
            newName.LastName = lastName;
            this.Name = newName;
        }
    }
}