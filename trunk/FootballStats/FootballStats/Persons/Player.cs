namespace FootballStats.Persons
{
    using System.Collections.Generic;
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

        // DELETE LATER
        //public void AddPosition(PlayerPosition position)
        //{
        //    // Ensures no position is contained more than once.
        //    if (!this.Position.Contains(position))
        //    {
        //        this.position.Add(position);
        //        return;
        //    }

        //    string message = string.Format("This player position '{0}' already exists.", position);
        //    throw new InvalidPlayerPositionException(message, position);
        //}

        // DELETE LATER
        //public void RemovePosition(PlayerPosition position)
        //{
        //    if (this.Position.Contains(position))
        //    {
        //        for (int i = 0; i < this.Position.Count; i++)
        //        {
        //            if (this.Position[i] == position)
        //            {
        //                this.position.RemoveAt(i);
        //                return;
        //            }
        //        }
        //    }

        //    string message = string.Format("Cannot find '{0}' player position.", position);
        //    throw new InvalidPlayerPositionException(message, position);
        //}

        public override string Serialize()
        {
            StringBuilder serialized = new StringBuilder();

            serialized.Append(base.Serialize());

            serialized.Append(";");
            serialized.Append(this.Position);

            return serialized.ToString();

            // DELETE LATER
            //string positionToPrint = null;
            //StringBuilder sb = new StringBuilder();

            //if (this.Position.Count == 0)
            //{
            //     positionToPrint = "NotSet";
            //}
            //else
            //{
            //    for (int i = 0; i < this.Position.Count; i++)
            //    {
            //        sb.Append(this.Position[i]);
            //        sb.Append(',');
            //    }
            //    positionToPrint = sb.ToString();
            //}

            //string returnValue = string.Format("{0};{1};{2};{3}", base.Serialize(), positionToPrint, this.AffiliatedClub, this.WeeklyWage());

            //return returnValue.ToString();
        }
    }
}