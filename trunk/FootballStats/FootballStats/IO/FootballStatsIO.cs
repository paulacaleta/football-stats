using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballStats.Clubs;
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
    }
}
