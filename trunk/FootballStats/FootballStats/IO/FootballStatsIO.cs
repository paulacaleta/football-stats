using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballStats.Clubs;
using FootballStats.Competitions;
using System.IO;

namespace FootballStats.IO
{
    public static class FootballStatsIO
    {
        public static void SaveClubInformation(Club club)
        {
            string path = String.Format(@"..\..\ClubInformation\{0}.txt", club.Name);

            using (StreamWriter write = new StreamWriter(path))
            {
                write.Write(club.ToString());
            }
        }

        public static string LoadClubInformation(string clubName)
        {
            string path = String.Format(@"..\..\ClubInformation\{0}.txt", clubName);
            string returnValue = null;

            try
            {
                using (StreamReader read = new StreamReader(path))
                {
                    returnValue = read.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                //TODO: implement custom exception
                //Ant this is just :D stupid !!! fix later!
                ex = new Exception("Non existing team!");
                throw ex;
            }

            return returnValue;
        }

        public static void DeleteClubInformation(string clubName)
        {
            string path = String.Format(@"..\..\ClubInformation\{0}.txt", clubName);
            string returnValue = null;

            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                //TODO: implement custom exception
                //Ant this is just :D stupid !!! fix later!
                ex = new Exception("Non existing team!");
                throw ex;
            }

        }

        private static void SaveMatchInformation(Match match, Season season)
        {
            string path = String.Format(@"..\..\SeasonsDataBase\{2}\Matchs\{0}_vs_{1}.txt",
                match.HomeClub.Name.ToString(), match.AwayClub.Name.ToString(), season.SeasonID);

            using (StreamWriter write = new StreamWriter(path))
            {
                write.Write(match.ToString());
            }
        }

        public static string ReadMatchInformation(string homeTeam, string awayTeam)
        {
            string returnValue = null;
            string path = String.Format(@"..\..\SeasonsDataBase\21.11.2013\Matchs\{0}_vs_{1}.txt",
                homeTeam, awayTeam);

            using (StreamReader read = new StreamReader(path))
            {
                returnValue = read.ReadToEnd();
            }

            return returnValue;
        }

        public static void SaveSeason(Season season) 
        {
            string directoryCreatPath = String.Format(@"..\..\SeasonsDataBase\{0}\Matchs", season.SeasonID);
            Directory.CreateDirectory(directoryCreatPath);

            string path = String.Format(@"..\..\SeasonsDataBase\{0}\SeasonInformation.txt", season.SeasonID);
            
            using (StreamWriter write = new StreamWriter(path))
            {
                write.Write(season.ToString());
            }

            foreach (var match in season.Matches)
            {
                FootballStatsIO.SaveMatchInformation(match, season);
            }
           
        }


    }
}
