namespace FootballStats.Competitions
{
    using System.Collections.Generic;

    interface IMatchStats
    {
        List<Goal> Goal { get; }
        List<Corner> Corner { get; }
        List<PenaltyKick> PenaltyKick { get; }
    }
}
