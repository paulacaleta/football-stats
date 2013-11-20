namespace FootballStats.Persons
{
    using System;

    public struct Name
    {
        private const int FirstAndMiddleNameMaxLength = 15;
        private const int LastNameMaxLength = 20;
        private const int MinNameLength = 2;

        private string firstName;
        private string middleName;
        private string lastName;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                // First name is mandatory
                if (value.Length < MinNameLength || value == null)
                {
                    string message = string.Format(
                            "First name should be at least {0} characters.", MinNameLength);

                    throw new ArgumentOutOfRangeException(message);
                }

                if (value.Length > FirstAndMiddleNameMaxLength)
                {
                    string message = string.Format(
                        "First name should be no longer than {0} characters.", FirstAndMiddleNameMaxLength);

                    throw new ArgumentOutOfRangeException(message);
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                // Middle name is NOT mandatory
                if (value != null)
                {
                    if (value.Length < MinNameLength)
                    {
                        string message = string.Format(
                            "Middle name should be at least {0} characters.", MinNameLength);

                        throw new ArgumentOutOfRangeException(message);
                    }

                    if (value.Length > FirstAndMiddleNameMaxLength)
                    {
                        string message = string.Format(
                            "Middle name should be no longer than {0} characters.", FirstAndMiddleNameMaxLength);

                        throw new ArgumentOutOfRangeException(message);
                    }
                }

                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                // Last name is mandatory
                if (value.Length < MinNameLength || value == null)
                {
                    string message = string.Format(
                            "Last name should be at least {0} characters.", MinNameLength);

                    throw new ArgumentOutOfRangeException(message);
                }

                if (value.Length > LastNameMaxLength)
                {
                    string message = string.Format(
                        "Last name should be no longer than {0} characters.", LastNameMaxLength);

                    throw new ArgumentOutOfRangeException(message);
                }

                this.lastName = value;
            }
        }
    }
}