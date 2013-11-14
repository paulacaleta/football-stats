using System;
using System.Collections.Generic;
using System.Linq;
using FootballStats.Common;

namespace FootballStats.Persons
{
    public class Player : ClubAffiliatedPerson, IPlayer
    {
        // Fields
        List<PlayerPosition> positions = new List<PlayerPosition>();
        // TODO: Affiliated club

        public Player(string firstName, string middleName, string lastName, string birthDate, Nationality nationality)
            : base(firstName, middleName, lastName, birthDate, nationality)
        {
        }

        public List<PlayerPosition> Positions
        {
            get { return this.positions; }
        }

        public void AddPosition(PlayerPosition position)
        {
            // Ensures no position is contained more than once.
            if (!this.Positions.Contains(position))
            {
                this.positions.Add(position);
                return;
            }
            // TODO: Throw Custom Exception;
            throw new NotImplementedException();
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
            // TODO: Throw Custom Exception;
            throw new NotImplementedException();
        }
    }
}