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
        // Club Save/Load information
        // TODO: additional information
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

            try
            {
                File.Delete(path);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File is missing!");
            }
            catch(FileLoadException)
            {
                Console.WriteLine("Can't load file!");
            }       

        }

        // Season Save/Load information
        #region Save/Load

        private static void SaveMatchInformation(Match match, Season season)
        {
            string path = String.Format(@"..\..\SeasonsDataBase\{2}\Matchs\{0}_vs_{1}.txt",
                match.HomeClub.Name.ToString(), match.AwayClub.Name.ToString(), season.SeasonID);

            using (StreamWriter write = new StreamWriter(path))
            {
                write.Write(match.ToString());
            }
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
       
        public static string ReadSeasonInformation(string seasonID) 
        {
            string path = String.Format(@"..\..\SeasonsDataBase\{0}\SeasonInformation.txt", seasonID);
            string returnValue = null;

            using (StreamReader read = new StreamReader(path))
            {
                returnValue = read.ReadToEnd();
            }

            return returnValue;
        }

        public static string ReadMatchInformationInSeason(string homeTeam, string awayTeam, string seasonID)
        {
            string returnValue = null;
            string path = String.Format(@"..\..\SeasonsDataBase\{2}\Matchs\{0}_vs_{1}.txt",
                homeTeam, awayTeam, seasonID);

            try
            {
                using (StreamReader read = new StreamReader(path))
                {
                    returnValue = read.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (FileLoadException)
            {
                Console.WriteLine("File can't load.");
            }
            

            return returnValue;
        }

        public static void DeleteSeason(string seasonID) 
        {
            string path = String.Format(@"..\..\SeasonsDataBase\{0}", seasonID);

            try
            {
                Directory.Delete(path, true);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (FileLoadException)
            {
                Console.WriteLine("File can't load.");
            }
        }
        #endregion
    }
}
