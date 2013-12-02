namespace FootballStats.Common
{
    using System;
    using FootballStats.Persons;

    public class InvalidPlayerPositionException : Exception
    {
        private PlayerPosition position;

        public InvalidPlayerPositionException()
        {
        }

        public InvalidPlayerPositionException(string message)
            : base(message)
        {
        }

        public InvalidPlayerPositionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InvalidPlayerPositionException(string message, PlayerPosition position)
            : base(message)
        {
            this.Position = position;
        }

        public InvalidPlayerPositionException(string message, PlayerPosition position, Exception innerException)
            : base(message, innerException)
        {
            this.Position = position;
        }

        public PlayerPosition Position
        {
            get
            {
                return this.position;
            }

            private set
            {
                this.position = value;
            }
        }
    }
}
