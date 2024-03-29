﻿namespace FootballStats.Persons
{
    using System.Text;
    using FootballStats.Common;

    public class Player : ClubAffiliatedPerson, IPlayer
    {
        private PlayerPosition position = PlayerPosition.NotSet;

        public Player(string firstName, string middleName, string lastName, string birthDate, Nationality nationality)
            : base(firstName, middleName, lastName, birthDate, nationality)
        {
        }

        public PlayerPosition Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
            }
        }

        public override string Serialize()
        {
            StringBuilder serialized = new StringBuilder();

            serialized.Append(base.Serialize());
            serialized.Append(";");
            serialized.Append(this.Position);

            return serialized.ToString();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} - {2}", this.Name.FirstName, this.Name.LastName, this.Position);
        }
    }
}