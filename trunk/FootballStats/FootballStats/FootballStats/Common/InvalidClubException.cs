namespace FootballStats.Common
{
    using System;
    using FootballStats.Persons;

    public class InvalidClubException : Exception
    {
        private IPerson personException;

        public InvalidClubException()
        {
        }

        public InvalidClubException(string message)
            : base(message)
        {
        }

        public InvalidClubException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InvalidClubException(string message, IPerson personException)
            : base(message)
        {
            this.PersonException = personException;
        }

        public InvalidClubException(string message, IPerson personException, Exception innerException)
            : base(message, innerException)
        {
            this.PersonException = personException;
        }

        public IPerson PersonException
        {
            get
            {
                return this.personException;
            }

            private set
            {
                this.personException = value;
            }
        }
    }
}
