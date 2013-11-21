using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballStats.Persons;

namespace FootballStats.Common
{
    public static class ToStringExtentionsForCollections
    {
        public static string ExtendedToString(this List<Player> list)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new string('-',80));
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
            foreach (var StaffMember in list)
            {
                sb.AppendLine(StaffMember.ToString());
                sb.Append('\n');
            }

            return sb.ToString();
        }
    }
}
