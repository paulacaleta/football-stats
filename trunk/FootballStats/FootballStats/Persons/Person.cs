namespace FootballStats.Persons
{
    using System;
    using System.Text;
    using FootballStats.Common;

    public abstract class Person : IPerson
    {
        private Name name;
        private DateTime birthDate;
        private Nationality nationality;

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

        #region Properties

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
                if (value.Year >= 1920 && value.Year <= DateTime.Today.Year)
                {
                    this.birthDate = value;
                }
                else
                {
                    throw new InvalidPersonDataException("Year of birth can't be earlier than 1920 or later than today!");
                }
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

        #endregion

        #region Methods

        public int GetAge()
        {
            // Age is calculated up to the current moment    
            DateTime today = DateTime.Today;
            int personAge = today.Year - this.BirthDate.Year;

            if (this.BirthDate > today.AddYears(-personAge))
            {
                personAge--;
            }

            return personAge;
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

        public override string ToString()
        {
            return string.Format("{0} {1}", this.name.FirstName, this.name.LastName);
        }

        public virtual string Serialize()
        {
            StringBuilder serialized = new StringBuilder();

            serialized.Append(this.Name.FirstName + ";");
            serialized.Append(this.Name.MiddleName + ";");
            serialized.Append(this.Name.LastName + ";");
            serialized.Append(string.Format("{0}.{1}.{2}",
                this.BirthDate.Day, this.BirthDate.Month, this.BirthDate.Year + ";"));
            serialized.Append(this.Nationality);

            return serialized.ToString();
        }

        #endregion
    }
}