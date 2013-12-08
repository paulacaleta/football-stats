namespace FootballStats.Common
{
    using System;
    using FootballStats.Persons;

    public class InvalidPersonDataException : ApplicationException
    {
        //private PlayerPosition position;

        public InvalidPersonDataException()
        {
        }

        public InvalidPersonDataException(string message)
            : base(message)
        {
        }

        public InvalidPersonDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        //public InvalidPersonDataException(string message, PlayerPosition position)
        //    : base(message)
        //{
        //    this.Position = position;
        //}

        //public InvalidPersonDataException(string message, PlayerPosition position, Exception innerException)
        //    : base(message, innerException)
        //{
        //    this.Position = position;
        //}

        //public PlayerPosition Position
        //{
        //    get
        //    {
        //        return this.position;
        //    }

        //    private set
        //    {
        //        this.position = value;
        //    }
        //}
    }
}
