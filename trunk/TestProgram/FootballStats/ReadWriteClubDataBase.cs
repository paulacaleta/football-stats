using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FootballStats
{
    public static class ReadWriteClubDataBase
    {
        public static void WriteInFile(List<Player> team, string teamName)
        {
            string path = String.Format("D:\\C#\\FootballStats\\FootballStats\\ClubInformation\\{0}.txt", teamName);

            using (StreamWriter write = new StreamWriter(path))
            {
                write.WriteLine("Players of {0}:", teamName);
                write.WriteLine();
                foreach (var player in team)
                {
                    write.WriteLine(player);
                }
            }
        }

        public static string ReadInformationAbouthClub(string teamName) 
        {
            string returnValue = null;
            string path = String.Format("D:\\C#\\FootballStats\\FootballStats\\ClubInformation\\{0}.txt", teamName);

            using (StreamReader read = new StreamReader(path))
            {
                returnValue = read.ReadToEnd();
            }

            return returnValue;
        }
    }
}
