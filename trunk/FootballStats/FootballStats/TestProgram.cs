﻿namespace FootballStats
{
    using System;
    using System.Collections.Generic;
    using FootballStats.Persons;
    using FootballStats.Common;
    using FootballStats.Clubs;
    using FootballStats.Competitions;

    class TestProgram
    {
        static void Main()
        {
            PlayerCreationTest();
            //ClubTest();
            //Engine engine = new Engine();
            //engine.Run();
            //TestInteroperability();
        }

        private static void TestInteroperability()
        {
            Player ivanov = new Player("Ivan", "Ivanov", "Petrov", "10.11.1990", Nationality.Bulgarian);
            
            Club cska = new Club("CSKA", Nationality.Bulgarian);
            World.AddClub(cska);
            cska.AddPlayer(ivanov);

            cska.AddPlayer(ivanov);

            Club levski = new Club("Levski", Nationality.Bulgarian);
            Player iliev = new Player("Plamen", "Petrov", "Iliev", "5.6.1998", Nationality.Bulgarian);
            World.AddClub(levski);
            levski.AddPlayer(iliev);

            Competition comp = new Competition("A Group", Nationality.Bulgarian);
            World.AddCompetition(comp);            
            Season s = new Season(1);
            comp.AddSeason(s);
            
        }

        private static void ClubTest()
        {
            Console.WriteLine("Testing Club class :\n\n");
            Random rdm = new Random();

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

            foreach (var player in team)
            {
                player.SetWeeklyWage(rdm.Next(300, 600));
            }
            
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

            foreach (var staffMember in staff)
            {
                staffMember.SetWeeklyWage(rdm.Next(200, 400));
            }

            Club testClub = new Club("NekvoIme", Nationality.Bulgarian);
            Player playerToTestAddAndRemove = new Player("Test", "Player", "Testing", "15.10.1940", Nationality.Bulgarian);
            StaffMember staStaffMemberToTestAddAndRemove = new StaffMember("Test", "Player", "Testing", "15.10.1940", Nationality.Bulgarian);

            testClub.AddPlayer(playerToTestAddAndRemove);
            testClub.RemovePlayer(playerToTestAddAndRemove);
            testClub.AddStaffMember(staStaffMemberToTestAddAndRemove);
            testClub.RemoveStaffMember(staStaffMemberToTestAddAndRemove);

            Console.WriteLine("Player's average wage: {0:C2}",testClub.AverageWageOfPlayers());
            Console.WriteLine("Staff's average wage: {0:C2}", testClub.AverageWageOfStaff());
            Console.WriteLine("Team average age: {0}",(int)(testClub.TeamAverageAge()));
            Console.WriteLine("This club higest wage : {0:C2}", testClub.HighestPlayerWage());
            Console.WriteLine("Total players at club: {0}", testClub.TotalPlayersAtClub());
            Console.WriteLine("Players with Bulgarian nationality : {0}", testClub.CountPlayersWithSameNationality(Nationality.Bulgarian));
        } 
        private static void PlayerCreationTest()
        {
            Console.WriteLine("TESTING PLAYER CREATION");
            Player firstPlayer = new Player("Vlado", null, "Stoyanov", "8.6.1987", Nationality.Bulgarian);
            Console.WriteLine(firstPlayer.GetName());
            Console.WriteLine(firstPlayer.BirthDate.ToShortDateString());
            Console.WriteLine("Age: {0}",firstPlayer.GetAge());
            Console.WriteLine("Weekly wage: {0}",firstPlayer.WeeklyWage());
            Console.WriteLine("Setting weekly wage to 1000");
            firstPlayer.SetWeeklyWage(1000);
            Console.WriteLine("Yearly wage {0:0}",firstPlayer.YearlyWage());
            Console.WriteLine("Monthly wage {0:0}", firstPlayer.MonthlyWage());
            Console.WriteLine("Weekly wage {0:0}", firstPlayer.WeeklyWage());
            Console.WriteLine();

            Console.WriteLine("POSITIONS TEST");
            
            firstPlayer.AddPosition(PlayerPosition.GK);
            Console.WriteLine("Adding GK:");
            foreach (var pos in firstPlayer.Positions)
            {
                Console.WriteLine(pos);
            }

            Console.WriteLine("Adding FW:");
            firstPlayer.AddPosition(PlayerPosition.FW);
            foreach (var pos in firstPlayer.Positions)
            {
                Console.WriteLine(pos);
            }

            Console.WriteLine("Removing GK:");
            firstPlayer.RemovePosition(PlayerPosition.GK);
            foreach (var pos in firstPlayer.Positions)
            {
                Console.WriteLine(pos);
            }
        }
    }
}
