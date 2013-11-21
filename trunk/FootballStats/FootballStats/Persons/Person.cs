namespace FootballStats.Persons
{
    using System;
    using System.Text;
    using FootballStats.Common;
    using FootballStats.Competitions;

    public abstract class Person : IPerson
    {
        private Name name;
        private DateTime birthDate;
        private Nationality nationality;

        private int personID;

        protected Person(string firstName, string middleName, string lastName, string birthDate, Nationality nationality)
        {
            Name name = new Name();
            name.FirstName = firstName;
            name.MiddleName = middleName;
            name.LastName = lastName;
            this.Name = name;
            this.BirthDate = DateTime.Parse(birthDate);
            this.Nationality = nationality;

            this.personID = World.PersonID++;
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
                if (value.Year >= 1920 && value.Year <= DateTime.Today.Year)
                {
                    this.birthDate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid birth date input!");
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

        public override bool Equals(object obj)
        {
            Person person = obj as Person;

            if (person == null)
            {
                return false;
            }

            if (this.personID != person.personID)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            // TODO: implement the method
            return this.personID ^ this.personID;
        }

        public override string ToString()
        {
            string returnValue = string.Format("{0}\nBirthDate: {1}\nNationality: {2}",
                this.Name.ToString(), this.BirthDate.ToString(), this.Nationality.ToString());

            return returnValue.ToString();
        }
    }
}