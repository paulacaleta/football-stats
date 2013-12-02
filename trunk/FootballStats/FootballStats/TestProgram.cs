namespace FootballStats
{
    using System;
    using System.Collections.Generic;
    using FootballStats.Persons;
    using FootballStats.Common;
    using FootballStats.Clubs;
    using FootballStats.Competitions;
    using FootballStats.IO;

    class TestProgram
    {
        static void Main()
        {
            //PlayerCreationTest();
            //Engine engine = new Engine();
            //engine.Run();
            TestInteroperability();
        }

        private static void TestInteroperability()
        {
            Club levski = new Club("Levski", Nationality.Bulgarian);

            List<Player> team = new List<Player>()
            {
                new Player("Baco", "Gacov", "Stoyanov", "15.10.1978", Nationality.Bulgarian),
                new Player("Gacov", "Gacov", "Gacov", "15.10.1979", Nationality.Cambodian),
                new Player("Baco", "Bacov", "Bacov", "15.10.1979", Nationality.Bulgarian),
                new Player("Baco", "Gacov", "Stoyanov", "15.10.1987", Nationality.Bulgarian),
                new Player("Baco", "Gacov", "Stoyanov", "15.10.1986", Nationality.Bulgarian),
                new Player("Baco", "Gacov", "Stoyanov", "15.10.1990", Nationality.Bulgarian),
                new Player("Baco", "Gacov", "Stoyanov", "15.10.1990", Nationality.Bulgarian),
                new Player("Baco", "Gacov", "Stoyanov", "15.10.1991", Nationality.Bulgarian),
                new Player("Baco", "Gacov", "Stoyanov", "15.10.1992", Nationality.Bulgarian),
                new Player("Baco", "Gacov", "Stoyanov", "15.10.1980", Nationality.Bulgarian),
                new Player("Baco", "Gacov", "Stoyanov", "15.10.1976", Nationality.Bulgarian),
                new Player("Baco", "Gacov", "Stoyanov", "15.10.1991", Nationality.Bulgarian),
                new Player("Baco", "Gacov", "Stoyanov", "15.10.1989", Nationality.Bulgarian),
                new Player("Baco", "Gacov", "Stoyanov", "15.10.1980", Nationality.Bulgarian)
            };

            List<StaffMember> staff = new List<StaffMember>()
            {
                new StaffMember("Baco", "Gacov", "Stoyanov", "15.10.1978", Nationality.Bulgarian),
                new StaffMember("Gacov", "Gacov", "Gacov", "15.10.1979", Nationality.Bulgarian),
                new StaffMember("Baco", "Bacov", "Bacov", "15.10.1979", Nationality.Bulgarian),
                new StaffMember("Baco", "Gacov", "Stoyanov", "15.10.1987", Nationality.Bulgarian),
                new StaffMember("Baco", "Gacov", "Stoyanov", "15.10.1986", Nationality.Bulgarian),
                new StaffMember("Baco", "Gacov", "Stoyanov", "15.10.1990", Nationality.Bulgarian),
                new StaffMember("Baco", "Gacov", "Stoyanov", "15.10.1990", Nationality.Bulgarian),
                new StaffMember("Baco", "Gacov", "Stoyanov", "15.10.1991", Nationality.Bulgarian),
                new StaffMember("Baco", "Gacov", "Stoyanov", "15.10.1992", Nationality.Bulgarian),
                new StaffMember("Baco", "Gacov", "Stoyanov", "15.10.1980", Nationality.Bulgarian),
                new StaffMember("Baco", "Gacov", "Stoyanov", "15.10.1976", Nationality.Bulgarian),
                new StaffMember("Baco", "Gacov", "Stoyanov", "15.10.1991", Nationality.Bulgarian),
                new StaffMember("Baco", "Gacov", "Stoyanov", "15.10.1989", Nationality.Bulgarian),
                new StaffMember("Baco", "Gacov", "Stoyanov", "15.10.1980", Nationality.Bulgarian)
            };

            levski.Team = team;
            levski.Staff = staff;         

            Player testMember = new Player("Baco", "Gacov", "Stoyanov", "15.10.1980", Nationality.Bulgarian);
            levski.AddPlayer(testMember);
            testMember.SetWeeklyWage(12345);

            Club cska = new Club("Cska", Nationality.Bulgarian);
            cska.Team = team;

            Match testMatch = new Match(levski, cska, "21/11/2013", new FinalScore(2, 2));
            testMatch.SetReferee(new Referee("Baco", "Gacov", "Stoyanov", "15.10.1980", Nationality.Bulgarian));

            Season testSeason = new Season("2013-2014");
            testSeason.AddClub(cska);
            testSeason.AddClub(levski);
            testSeason.AddMatch(testMatch);
            testSeason.AddReferee(new Referee("Baco", "Gacov", "Stoyanov", "15.10.1980", Nationality.Bulgarian));

            FootballStatsIO.SaveClubInformation(levski);

            Console.WriteLine(FootballStatsIO.LoadClubInformation("levski"));
        }

        private static void PlayerCreationTest()
        {
            Referee newRef = new Referee("Baco", "Gacov", "Stoyanov", "15.10.1978", Nationality.Bulgarian);

            Console.WriteLine(newRef.GetName());

            FootballStatsIO.DeleteSeason("2013-2014");

            Console.WriteLine();
        }
    }
}
