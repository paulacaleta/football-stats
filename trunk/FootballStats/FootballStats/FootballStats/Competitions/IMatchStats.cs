namespace FootballStats.Competitions
{
    using System.Collections.Generic;

    public interface IMatchStats
    {
        List<MatchEvent> GetEvents(EventType eventType);

        List<MatchEvent> GetAllEvents();
    }
}
