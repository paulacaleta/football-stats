namespace FootballStats.Competitions
{
    using System;
    using FootballStats.Clubs;

    protected abstract class MatchEvent
    {
        DateTime TimeOfEvent { get; }
        Club InFavorOfTeam { get; }
    }
}
