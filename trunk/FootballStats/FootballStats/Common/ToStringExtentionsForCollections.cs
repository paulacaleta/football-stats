namespace FootballStats.Common
{
    using System.Collections.Generic;
    using System.Text;
    using FootballStats.Clubs;
    using FootballStats.Competitions;
    using FootballStats.Persons;

    public static class ToStringExtentionsForCollections
    {
        public static string ExtendedToString(this List<Player> list)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new string('-', 80));
            foreach (var player in list)
            {
                sb.AppendLine(player.ToString());
                sb.Append('\n');
            }

            return sb.ToString();
        }

        public static string ExtendedToString(this List<StaffMember> list)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new string('-', 80));
            foreach (var staffMember in list)
            {
                sb.AppendLine(staffMember.ToString());
                sb.Append('\n');
            }

            return sb.ToString();
        }

        public static string ExtendedToString(this List<MatchEvent> list)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new string('-', 80));
            foreach (var events in list)
            {
                sb.AppendLine(events.ToString());
                sb.Append('\n');
            }

            return sb.ToString();
        }

        public static string ExtendedToString(this List<Match> list)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new string('-', 80));
            foreach (var match in list)
            {
                sb.AppendLine(match.ToString());
                sb.Append('\n');
            }

            return sb.ToString();
        }

        public static string ExtendedToString(this List<Club> list)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new string('-', 80));
            foreach (var club in list)
            {
                sb.AppendLine(club.ToString());
                sb.Append('\n');
            }

            return sb.ToString();
        }

        public static string ExtendedToString(this List<Referee> list)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new string('-', 80));
            foreach (var referee in list)
            {
                sb.AppendLine(referee.ToString());
                sb.Append('\n');
            }

            return sb.ToString();
        }
    }
}
