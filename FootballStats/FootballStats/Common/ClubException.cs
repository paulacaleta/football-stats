namespace FootballStats.Common
{
    using System;
    using FootballStats.Persons;

    public class ClubException : ApplicationException
    {
        private IPerson personException;

        public ClubException()
        {
        }

        public ClubException(string message)
            : base(message)
        {
        }

        public ClubException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ClubException(string message, IPerson personException)
            : base(message)
        {
            this.PersonException = personException;
        }

        public ClubException(string message, IPerson personException, Exception innerException)
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
