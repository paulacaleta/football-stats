namespace FootballStats.Common
{
    using System.Collections.Generic;
    using System.Text;
    using FootballStats.Clubs;
    using FootballStats.Competitions;
    using FootballStats.Persons;

    public static class ToStringExtentionsForCollections
    {
        public static string ExtendedToString<T>(this List<T> list)
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
    }
}
