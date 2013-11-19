using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballStats.Persons;

namespace FootballStats.Common
{
    class InvalidPlayerPositionException : Exception
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
            this.position = position;
        }

        public InvalidPlayerPositionException(string message, PlayerPosition position, Exception innerException)
            : base(message, innerException)
        {
            this.position = position;
        }

        public PlayerPosition Position
        {
            get
            {
                return this.position;
            }
        }
    }
}
