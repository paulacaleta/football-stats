using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballStats.Clubs;
using FootballStats.Competitions;
using FootballStats.Persons;
using System.IO;
using FootballStats.Common;

namespace FootballStats.IO
{
    public static class SaveLoad
    {
        

        internal static IO SaveLoader { get; private set; }

        static SaveLoad()
        {
            SaveLoader = new IO();
        }

        public class IO
        {
            private static string path = "..\\..\\..\\Database\\";

            internal IO()
            {
                
            }

            #region Save
            public void SaveWorld()
            {
                SavePlayers();
                SaveStaff();
                SaveReferees();
                SaveClubs();
            }

            private void SaveClubs()
            {
                StreamWriter writer = new StreamWriter(path + "Clubs.txt");

                using (writer)
                {
                    foreach (var club in World.Clubs)
                    {
                        writer.WriteLine(club.Serialize());
                    }
                }
            }

            private void SaveReferees()
            {
                StreamWriter writer = new StreamWriter(path + "Referees.txt");

                using (writer)
                {
                    foreach (var referee in World.Referees)
                    {
                        writer.WriteLine(referee.Serialize());
                    }
                }
            }

            private void SaveStaff()
            {
                StreamWriter writer = new StreamWriter(path + "Staff.txt");

                using (writer)
                {
                    foreach (var staff in World.Staff)
                    {
                        writer.WriteLine(staff.Serialize());
                    }
                }
            }

            private void SavePlayers()
            {
                StreamWriter writer = new StreamWriter(path + "Players.txt");

                using (writer)
                {
                    foreach (var player in World.Players)
                    {
                        writer.WriteLine(player.Serialize());
                    }
                }
            }
            #endregion

            #region Load // REFACTORING NEEDED
            public void LoadWorld()
            {
                LoadFile("Players.txt");
                LoadFile("Staff.txt");
                LoadFile("Referees.txt");
                LoadFile("Clubs.txt");
            }

            private void LoadFile(string textFileName)
            {
                StreamReader reader = new StreamReader(path + textFileName);

                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] entityData = line.Split(';');
                    switch (textFileName)
                    {
                        case "Players.txt": LoadSinglePlayer(entityData); break;
                        case "Staff.txt": LoadSingleStaff(entityData); break;
                        case "Referees.txt": LoadSingleReferee(entityData); break;
                        case "Clubs.txt": LoadSingleClub(entityData); break;
                        default:
                            break;
                    }

                    line = reader.ReadLine();
                }
            }

            private void LoadSingleClub(string[] entityData)
            {
                string name = entityData[0];
                Nationality nat = (Nationality)Enum.Parse(typeof(Nationality), entityData[1]);

                World.AddClub(new Club(name, nat));
            }

            private void LoadSingleReferee(string[] entityData)
            {
                string firstName = entityData[0];
                string middleName = entityData[1];
                string lastName = entityData[2];

                string dateOfBirth = entityData[3];
                Nationality nat = (Nationality)Enum.Parse(typeof(Nationality), entityData[4]);

                Referee newRef = new Referee(firstName, middleName, lastName, dateOfBirth, nat);
                World.Referees.Add(newRef);
            }

            private void LoadSingleStaff(string[] entityData)
            {
                string firstName = entityData[0];
                string middleName = entityData[1];
                string lastName = entityData[2];

                string dateOfBirth = entityData[3];
                Nationality nat = (Nationality)Enum.Parse(typeof(Nationality), entityData[4]);
                decimal weeklyWage = decimal.Parse(entityData[5]);

                string club = entityData[6];
                StaffPosition pos = (StaffPosition)Enum.Parse(typeof(StaffPosition), entityData[7]);

                StaffMember newStaff = new StaffMember(firstName, middleName, lastName, dateOfBirth, nat);
                if (club != "Free Agent") { newStaff.AffiliatedClub = club; }
                newStaff.SetWeeklyWage(weeklyWage);
                newStaff.StaffPosition = pos;

                World.Staff.Add(newStaff);
            }

            private void LoadSinglePlayer(string[] entityData)
            {
                string firstName = entityData[0];
                string middleName = entityData[1];
                string lastName = entityData[2];

                string dateOfBirth = entityData[3];
                Nationality nat = (Nationality)Enum.Parse(typeof(Nationality), entityData[4]);
                decimal weeklyWage = decimal.Parse(entityData[5]);

                string club = entityData[6];
                PlayerPosition pos = (PlayerPosition)Enum.Parse(typeof(PlayerPosition), entityData[7]);

                Player newPlayer = new Player(firstName, middleName, lastName, dateOfBirth, nat);
                if (club != "Free Agent") { newPlayer.AffiliatedClub = club; }
                newPlayer.SetWeeklyWage(weeklyWage);
                newPlayer.Position = pos;

                World.Players.Add(newPlayer);
            }
            #endregion        
        }       
    }
}
