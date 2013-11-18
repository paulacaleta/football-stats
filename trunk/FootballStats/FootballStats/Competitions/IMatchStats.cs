namespace FootballStats.Competitions
{
    using System.Collections.Generic;

    interface IMatchStats
    {
        List<MatchEvent> GetEvents(EventType eventType);
        List<MatchEvent> GetAllEvents();


    }
}
