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
    public static class FootballStatsIO
    {
        private static string path = "..\\..\\..\\Database\\";

        #region Save
        public static void SaveWorld()
        {
            SavePlayers();
            SaveStaff();
            SaveReferees();
            SaveClubs();
        }

        private static void SaveClubs()
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

        private static void SaveReferees()
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

        private static void SaveStaff()
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

        private static void SavePlayers()
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
        public static void LoadWorld()
        {
            LoadFile("Players.txt");
            LoadFile("Staff.txt");
            LoadFile("Referees.txt");
            LoadFile("Clubs.txt");
        }

        private static void LoadFile(string textFileName)
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

        private static void LoadSingleClub(string[] entityData)
        {
            string name = entityData[0];
            Nationality nat = (Nationality)Enum.Parse(typeof(Nationality), entityData[1]);

            World.AddClub(new Club(name, nat));
        }

        private static void LoadSingleReferee(string[] entityData)
        {
            string firstName = entityData[0];
            string middleName = entityData[1];
            string lastName = entityData[2];

            string dateOfBirth = entityData[3];
            Nationality nat = (Nationality)Enum.Parse(typeof(Nationality), entityData[4]);

            Referee newRef = new Referee(firstName,middleName,lastName,dateOfBirth,nat);
            World.Referees.Add(newRef);
        }

        private static void LoadSingleStaff(string[] entityData)
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

        private static void LoadSinglePlayer(string[] entityData)
        {
            string firstName = entityData[0];
            string middleName = entityData[1];
            string lastName = entityData[2];

            string dateOfBirth = entityData[3];
            Nationality nat = (Nationality)Enum.Parse(typeof(Nationality), entityData[4]);
            decimal weeklyWage = decimal.Parse(entityData[5]);

            string club = entityData[6];
            PlayerPosition pos = (PlayerPosition)Enum.Parse(typeof(PlayerPosition), entityData[7]);

            Player newPlayer = new Player(firstName,middleName,lastName,dateOfBirth,nat);
            if (club != "Free Agent") { newPlayer.AffiliatedClub = club; }
            newPlayer.SetWeeklyWage(weeklyWage);
            newPlayer.Position = pos;

            World.Players.Add(newPlayer);
        }
        #endregion

        //Person Save/Load information
        #region Person Save/Load
        //Player
        //public static void SavePlayers(List<Player> players)
        //{
        //    string path = String.Format(@"..\..\..\FootballStats\PersonInformation\Player.txt");

        //    using (StreamWriter write = new StreamWriter(path, true))
        //    {
        //        foreach (var player in players)
        //        {
        //            write.WriteLine(player.Serialize());
        //        }
        //    }
        //}
        //public static List<Player> ParsePlayersFromPlayerTxt()
        //{
        //    List<Player> returnList = new List<Player>();
        //    string path = String.Format(@"..\..\..\FootballStats\PersonInformation\Player.txt");
        //    StringBuilder sb = new StringBuilder();

        //    using (StreamReader read = new StreamReader(path))
        //    {
        //        sb.Append(read.ReadToEnd());
        //    }
        //    string[] parseHelper = sb.ToString().Split(new[] { ";", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

        //    int ID = 0;
        //    string firstName = null;
        //    string middleName = null;
        //    string lastName = null;
        //    string dateOfBirth = null;
        //    Nationality nationality = Nationality.Bulgarian; // This doesnt matter because nationality is mendetory in the constructor.
        //    PlayerPosition position = PlayerPosition.NotSet;
        //    string clubAfiliation = null;
        //    decimal weaklyWage = 0;

        //    for (int i = 0; i < parseHelper.Length; i++)
        //    {
        //        if (i % 7 == 0)
        //        {
        //            //ID
        //            ID = int.Parse(parseHelper[i]);

        //        }
        //        else if (i % 7 == 1)
        //        {
        //            //Name
        //            string[] splitName = parseHelper[i].Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        //            firstName = splitName[0];
        //            middleName = splitName[1];
        //            lastName = splitName[2];
        //        }
        //        else if (i % 7 == 2)
        //        {
        //            //DateOfBirth
        //            dateOfBirth = parseHelper[i];
        //        }
        //        else if (i % 7 == 3)
        //        {
        //            //Nationality
        //            nationality = (Nationality)Enum.Parse(typeof(Nationality), parseHelper[i]);
        //        }
        //        else if (i % 7 == 4)
        //        {
        //            //Position
        //            string[] splitPosition = parseHelper[i].Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

        //            foreach (var item in splitPosition)
        //            {
        //                position = (PlayerPosition)Enum.Parse(typeof(PlayerPosition), item);
        //            }
        //        }
        //        else if (i % 7 == 5)
        //        {
        //            //ClubAfiliation
        //            clubAfiliation = parseHelper[i];
        //        }
        //        else if (i % 7 == 6)
        //        {
        //            //WeaklyWage
        //            weaklyWage = Decimal.Parse(parseHelper[i]);
        //        }
        //        else
        //        {
        //            //TODO: implement custom exception
        //            throw new Exception("Player Not Saved Correctly!");
        //        }

        //        if (i % 7 == 6 && i > 0)
        //        {
        //            //Initialize Constructor
        //            Player tempPlayer = new Player(firstName, middleName, lastName, dateOfBirth, nationality);
        //            tempPlayer.PersonID = ID;
        //            tempPlayer.Position.Add(position);
        //            tempPlayer.SetWeeklyWage(weaklyWage);
        //            tempPlayer.AffiliatedClub = clubAfiliation;

        //            //Add Everything into the list that the method returns
        //            returnList.Add(tempPlayer);

        //            //We need to defult every variable
        //            ID = 0;
        //            firstName = null;
        //            middleName = null;
        //            lastName = null;
        //            dateOfBirth = null;
        //            nationality = Nationality.Bulgarian; // This doesnt matter because nationality is mendetory in the constructor.
        //            position = PlayerPosition.NotSet;
        //            clubAfiliation = null;
        //            weaklyWage = 0;
        //        }

        //    }

        //    return returnList;
        //}

        //StaffMember
        //public static void SaveStaffMembers(List<StaffMember> staff) 
        //{
        //    string path = String.Format(@"..\..\..\FootballStats\PersonInformation\StaffMember.txt");

        //    using (StreamWriter write = new StreamWriter(path, true))
        //    {
        //        foreach (var staffMember in staff)
        //        {
        //            write.WriteLine(staffMember.Serialize());
        //        }
        //    }
        //}
        //public static List<StaffMember> ParsePlayersFromStaffMemberTxt()
        //{
        //    List<StaffMember> returnList = new List<StaffMember>();
        //    string path = String.Format(@"..\..\..\FootballStats\PersonInformation\StaffMember.txt");
        //    StringBuilder sb = new StringBuilder();

        //    using (StreamReader read = new StreamReader(path))
        //    {
        //        sb.Append(read.ReadToEnd());
        //    }
        //    string[] parseHelper = sb.ToString().Split(new[] { ";", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

        //    int ID = 0;
        //    string firstName = null;
        //    string middleName = null;
        //    string lastName = null;
        //    string dateOfBirth = null;
        //    Nationality nationality = Nationality.Bulgarian; // This doesnt matter because nationality is mendetory in the constructor.
        //    StaffPosition position = StaffPosition.NotSet;
        //    string clubAfiliation = null;
        //    decimal weaklyWage = 0;

        //    for (int i = 0; i < parseHelper.Length; i++)
        //    {
        //        if (i % 7 == 0)
        //        {
        //            //ID
        //            ID = int.Parse(parseHelper[i]);

        //        }
        //        else if (i % 7 == 1)
        //        {
        //            //Name
        //            string[] splitName = parseHelper[i].Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        //            firstName = splitName[0];
        //            middleName = splitName[1];
        //            lastName = splitName[2];
        //        }
        //        else if (i % 7 == 2)
        //        {
        //            //DateOfBirth
        //            dateOfBirth = parseHelper[i];
        //        }
        //        else if (i % 7 == 3)
        //        {
        //            //Nationality
        //            nationality = (Nationality)Enum.Parse(typeof(Nationality), parseHelper[i]);
        //        }
        //        else if (i % 7 == 4)
        //        {
        //            //Position
        //            position = (StaffPosition)Enum.Parse(typeof(StaffPosition), parseHelper[i]);
        //        }
        //        else if (i % 7 == 5)
        //        {
        //            //ClubAfiliation
        //            clubAfiliation = parseHelper[i];
        //        }
        //        else if (i % 7 == 6)
        //        {
        //            //WeaklyWage
        //            weaklyWage = Decimal.Parse(parseHelper[i]);
        //        }
        //        else
        //        {
        //            //TODO: implement custom exception
        //            throw new Exception("Staff member Not Saved Correctly!");
        //        }

        //        if (i % 7 == 6 && i > 0)
        //        {
        //            //Initialize Constructor
        //            StaffMember tempStaff = new StaffMember(firstName, middleName, lastName, dateOfBirth, nationality);
        //            tempStaff.PersonID = ID;
        //            tempStaff.StaffPosition = position;
        //            tempStaff.SetWeeklyWage(weaklyWage);
        //            tempStaff.AffiliatedClub = clubAfiliation;

        //            //Add Everything into the list that the method returns
        //            returnList.Add(tempStaff);

        //            //We need to defult every variable
        //            ID = 0;
        //            firstName = null;
        //            middleName = null;
        //            lastName = null;
        //            dateOfBirth = null;
        //            nationality = Nationality.Bulgarian; // This doesnt matter because nationality is mendetory in the constructor.
        //            position = StaffPosition.NotSet;
        //            clubAfiliation = null;
        //            weaklyWage = 0;
        //        }
        //    }

        //    return returnList;
        //}

        ////Referee
        //public static void SaveReferees(List<Referee> referes) 
        //{
        //    string path = String.Format(@"..\..\..\FootballStats\PersonInformation\Referee.txt");

        //    using (StreamWriter write = new StreamWriter(path, true))
        //    {
        //        foreach (var referee in referes)
        //        {
        //            write.WriteLine(referee.Serialize());
        //        }
        //    }
        //}
        //public static List<Referee> ParseRefereesFromRefereeTxt() 
        //{
        //    List<Referee> returnList = new List<Referee>();
        //    string path = String.Format(@"..\..\..\FootballStats\PersonInformation\Referee.txt");
        //    StringBuilder sb = new StringBuilder();

        //    using (StreamReader read = new StreamReader(path))
        //    {
        //        sb.Append(read.ReadToEnd());
        //    }
        //    string[] parseHelper = sb.ToString().Split(new[] { ";", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

        //    int ID = 0;
        //    string firstName = null;
        //    string middleName = null;
        //    string lastName = null;
        //    string dateOfBirth = null;
        //    Nationality nationality = Nationality.Bulgarian; // This doesnt matter because nationality is mendetory in the constructor.

        //    for (int i = 0; i < parseHelper.Length; i++)
        //    {
        //        if (i % 4 == 0)
        //        {
        //            //ID
        //            ID = int.Parse(parseHelper[i]);

        //        }
        //        else if (i % 4 == 1)
        //        {
        //            //Name
        //            string[] splitName = parseHelper[i].Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        //            firstName = splitName[0];
        //            middleName = splitName[1];
        //            lastName = splitName[2];
        //        }
        //        else if (i % 4 == 2)
        //        {
        //            //DateOfBirth
        //            dateOfBirth = parseHelper[i];
        //        }
        //        else if (i % 4 == 3)
        //        {
        //            //Nationality
        //            nationality = (Nationality)Enum.Parse(typeof(Nationality), parseHelper[i]);
        //        }
        //        else
        //        {
        //            //TODO: implement custom exception
        //            throw new Exception("Staff member Not Saved Correctly!");
        //        }

        //        if (i % 4 == 3 && i > 0)
        //        {
        //            //Initialize Constructor
        //            Referee tempRefferee = new Referee(firstName, middleName, lastName, dateOfBirth, nationality);
        //            tempRefferee.PersonID = ID;

        //            //Add Everything into the list that the method returns
        //            returnList.Add(tempRefferee);

        //            //We need to defult every variable
        //            ID = 0;
        //            firstName = null;
        //            middleName = null;
        //            lastName = null;
        //            dateOfBirth = null;
        //            nationality = Nationality.Bulgarian;
        //        }
        //    }

        //    return returnList;
        //}


        //TODO: AddDeletePerson wich can delete a file and then write everything from the world player list!!
        #endregion

        // Club Save/Load information
        #region Club Save/Load
        //public static void SaveClubInformation(List<Club> clubs)
        //{
        //    string path = String.Format(@"..\..\..\FootballStats\ClubInformation\ClubInformation.txt");

        //    foreach (var club in clubs)
        //    {
        //        using (StreamWriter write = new StreamWriter(path, true))
        //        {
        //            write.Write(club.ToString());
        //        }
        //    }
        //}
        //public static List<Club> ParseClubInformation()
        //{
        //    string path = String.Format(@"..\..\..\FootballStats\ClubInformation\ClubInformation.txt");
        //    StringBuilder sb = new StringBuilder();
        //    List<Club> parsedClubInformation = new List<Club>();

        //    using (StreamReader read = new StreamReader(path))
        //    {
        //        sb.Append(read.ReadToEnd());
        //    }
        //    string[] parseHelper = sb.ToString().Split(new[] {";", "\n", "\r"}, StringSplitOptions.RemoveEmptyEntries);

        //    Nationality nationality = Nationality.Bulgarian; // Doesnt matter because the nationality is mendetory for Club.
        //    string name = null;

        //    for (int i = 0; i < parseHelper.Length; i++)
        //    {
        //        if (i % 2 == 0)
        //        {
        //            name = parseHelper[i];
        //        }
        //        else if (i % 2 == 1)
        //        {
        //            nationality = (Nationality)Enum.Parse(typeof(Nationality), parseHelper[i]);
        //        }
        //        else
        //        {
        //            //TODO: implement custom exception
        //            throw new Exception("Player Not Saved Correctly!");
        //        }

        //        if (i % 2 == 1 && i > 0)
        //        {
        //            Club temp = new Club(name, nationality);
        //            parsedClubInformation.Add(temp);

        //            nationality = Nationality.Bulgarian;
        //            name = null;
        //        }
        //    }

        //    // Foreach All static lists of player and staf fmembers to find out afiliations.
        //    foreach (var club in parsedClubInformation)
        //    {
        //        foreach (var player in World.Players)
        //        {
        //            if (player.AffiliatedClub == club.Name)
        //            {
        //                club.Team.Add(player);
        //            }
        //        }

        //        foreach (var staff in World.Staff)
        //        {
        //            if (staff.AffiliatedClub == club.Name)
        //            {
        //                club.Staff.Add(staff);
        //            }
        //        }
        //    }

        //    return parsedClubInformation;
        //}

        //public static void DeleteClubInformation(string clubName)
        //{
        //    string path = String.Format(@"..\..\..\FootballStats\ClubInformation\ClubInformation.txt.txt");

        //    try
        //    {
        //        File.Delete(path);
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        Console.WriteLine("File is missing!");
        //    }
        //    catch(FileLoadException)
        //    {
        //        Console.WriteLine("Can't load file!");
        //    }       

        //}
        #endregion

        // Season Save/Load information
        #region Season Save/Load

        //private static void SaveMatchInformation(Match match, Season season)
        //{
        //    string path = String.Format(@"..\..\SeasonsDataBase\{2}\Matchs\{0}_vs_{1}.txt",
        //        match.HomeClub.Name.ToString(), match.AwayClub.Name.ToString(), season.SeasonID);

        //    using (StreamWriter write = new StreamWriter(path))
        //    {
        //        write.Write(match.ToString());
        //    }
        //}       

        //public static void SaveSeason(Season season) 
        //{
        //    string directoryCreatPath = String.Format(@"..\..\SeasonsDataBase\{0}\Matchs", season.SeasonID);
        //    Directory.CreateDirectory(directoryCreatPath);

        //    string path = String.Format(@"..\..\SeasonsDataBase\{0}\SeasonInformation.txt", season.SeasonID);

        //    using (StreamWriter write = new StreamWriter(path))
        //    {
        //        write.Write(season.ToString());
        //    }

        //    foreach (var match in season.Matches)
        //    {
        //        FootballStatsIO.SaveMatchInformation(match, season);
        //    }

        //}

        //public static string ReadSeasonInformation(string seasonID) 
        //{
        //    string path = String.Format(@"..\..\SeasonsDataBase\{0}\SeasonInformation.txt", seasonID);
        //    string returnValue = null;

        //    using (StreamReader read = new StreamReader(path))
        //    {
        //        returnValue = read.ReadToEnd();
        //    }

        //    return returnValue;
        //}

        //public static string ReadMatchInformationInSeason(string homeTeam, string awayTeam, string seasonID)
        //{
        //    string returnValue = null;
        //    string path = String.Format(@"..\..\SeasonsDataBase\{2}\Matchs\{0}_vs_{1}.txt",
        //        homeTeam, awayTeam, seasonID);

        //    try
        //    {
        //        using (StreamReader read = new StreamReader(path))
        //        {
        //            returnValue = read.ReadToEnd();
        //        }
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        Console.WriteLine("File not found.");
        //    }
        //    catch (FileLoadException)
        //    {
        //        Console.WriteLine("File can't load.");
        //    }


        //    return returnValue;
        //}

        //public static void DeleteSeason(string seasonID) 
        //{
        //    string path = String.Format(@"..\..\SeasonsDataBase\{0}", seasonID);

        //    try
        //    {
        //        Directory.Delete(path, true);
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        Console.WriteLine("File not found.");
        //    }
        //    catch (FileLoadException)
        //    {
        //        Console.WriteLine("File can't load.");
        //    }
        //}
        #endregion
    }
}
