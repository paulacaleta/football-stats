namespace FootballStats.ViewModels
{
    using System.Collections.Generic;
    using FootballStats.Clubs;
    using FootballStats.Competitions;

    public class ShowClubsViewModel
    {
        public IEnumerable<Club> Clubs
        {
            get
            {
                World.Load();
                return World.Clubs;
            }
        }
    }
}
