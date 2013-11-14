using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballStats.Persons
{
    public interface IPlayer
    {
        List<PlayerPosition> Positions { get; }
        void AddPosition(PlayerPosition position);
        void RemovePosition(PlayerPosition position);
    }
}
