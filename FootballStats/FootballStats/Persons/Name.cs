﻿namespace FootballStats.Persons
{
    using FootballStats.Common;

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
                if (value.Length < MinNameLength || value == null)
                {
                    string message = string.Format(
                            "First name should be at least {0} characters.", MinNameLength);

                    throw new InvalidPersonDataException(message);
                }

                if (value.Length > FirstAndMiddleNameMaxLength)
                {
                    string message = string.Format(
                        "First name should be no longer than {0} characters.", FirstAndMiddleNameMaxLength);

                    throw new InvalidPersonDataException(message);
                }

                if (ContainsNonLetterCharacter(value))
                {
                    ThrowInvalidCharInNameException();
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
                if (value != null)
                {
                    if (value.Length < MinNameLength)
                    {
                        string message = string.Format(
                            "Middle name should be at least {0} characters.", MinNameLength);

                        throw new InvalidPersonDataException(message);
                    }

                    if (value.Length > FirstAndMiddleNameMaxLength)
                    {
                        string message = string.Format(
                            "Middle name should be no longer than {0} characters.", FirstAndMiddleNameMaxLength);

                        throw new InvalidPersonDataException(message);
                    }

                    if (ContainsNonLetterCharacter(value))
                    {
                        ThrowInvalidCharInNameException();
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
                if (value.Length < MinNameLength || value == null)
                {
                    string message = string.Format(
                            "Last name should be at least {0} characters.", MinNameLength);

                    throw new InvalidPersonDataException(message);
                }

                if (value.Length > LastNameMaxLength)
                {
                    string message = string.Format(
                        "Last name should be no longer than {0} characters.", LastNameMaxLength);

                    throw new InvalidPersonDataException(message);
                }

                if (ContainsNonLetterCharacter(value))
                {
                    ThrowInvalidCharInNameException();
                }

                this.lastName = value;
            }
        }

        private bool ContainsNonLetterCharacter(string str)
        {
            foreach (var character in str)
            {
                if (!char.IsLetter(character) && character != '-')
                {
                    return true;
                }
            }
            return false;
        }

        private void ThrowInvalidCharInNameException()
        {
            string message = string.Format("Name must contain letters only!");

            throw new InvalidPersonDataException(message);
        }

        public string Serialize()
        {
            string returnValue = string.Format("{0},{1},{2}", this.FirstName, this.MiddleName, this.LastName);

            return returnValue.ToString();
        }
    }
}