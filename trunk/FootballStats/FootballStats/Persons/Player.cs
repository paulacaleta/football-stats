namespace FootballStats.Persons
{
    using System.Collections.Generic;
    using System.Text;
    using FootballStats.Common;

    public class Player : ClubAffiliatedPerson, IPlayer
    {
        private IList<PlayerPosition> positions = new List<PlayerPosition>();

        public Player(string firstName, string middleName, string lastName, string birthDate, Nationality nationality)
            : base(firstName, middleName, lastName, birthDate, nationality)
        {
        }
        
        public IList<PlayerPosition> Positions
        {
            get
            { 
                return this.positions;
            }
        }

        public void AddPosition(PlayerPosition position)
        {
            // Ensures no position is contained more than once.
            if (!this.Positions.Contains(position))
            {
                this.positions.Add(position);
                return;
            }

            string message = string.Format("This player position '{0}' already exists.", position);
            throw new InvalidPlayerPositionException(message, position);
        }

        public void RemovePosition(PlayerPosition position)
        {
            if (this.Positions.Contains(position))
            {
                for (int i = 0; i < this.Positions.Count; i++)
                {
                    if (this.Positions[i] == position)
                    {
                        this.positions.RemoveAt(i);
                        return;
                    }
                }
            }

            string message = string.Format("Cannot find '{0}' player position.", position);
            throw new InvalidPlayerPositionException(message, position);
        }

        public override string Serialize()
        {

            string positionToPrint = null;
            StringBuilder sb = new StringBuilder();

            if (this.Positions.Count == 0)
            {
                 positionToPrint = "NotSet";
            }
            else
            {
                for (int i = 0; i < this.Positions.Count; i++)
                {
                    sb.Append(this.Positions[i]);
                    sb.Append(',');
                }
                positionToPrint = sb.ToString();
            }

            string returnValue = string.Format("{0};{1};{2};{3}", base.Serialize(), positionToPrint, this.AffiliatedClub, this.WeeklyWage());

            return returnValue.ToString();
        }
    }
}