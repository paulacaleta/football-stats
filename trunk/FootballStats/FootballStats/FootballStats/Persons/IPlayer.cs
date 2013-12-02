namespace FootballStats.Persons
{
    using System.Collections.Generic;

    public interface IPlayer
    {
        IList<PlayerPosition> Positions { get; }

        void AddPosition(PlayerPosition position);

        void RemovePosition(PlayerPosition position);
    }
}
