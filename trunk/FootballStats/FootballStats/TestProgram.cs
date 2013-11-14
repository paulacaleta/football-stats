namespace FootballStats
{
    using System;
    using FootballStats.Persons;
    using FootballStats.Common;

    class TestProgram
    {
        static void Main()
        {
            PlayerCreationTest();
        }
  
        private static void PlayerCreationTest()
        {
            Console.WriteLine("TESTING PLAYER CREATION");
            Player p1 = new Player("Vlado", null, "Stoyanov", "15.10.2000", Nationality.Bulgarian);
            Console.WriteLine(p1.GetName());
            Console.WriteLine(p1.BirthDate.ToShortDateString());
            Console.WriteLine("Age: {0}",p1.GetAge());
            Console.WriteLine("Weekly wage: {0}",p1.WeeklyWage());
            Console.WriteLine("Setting weekly wage to 1000");
            p1.SetWeeklyWage(1000);
            Console.WriteLine("Yearly wage {0:0}",p1.YearlyWage());
            Console.WriteLine("Monthly wage {0:0}", p1.MonthlyWage());
            Console.WriteLine("Weekly wage {0:0}", p1.WeeklyWage());
            Console.WriteLine();

            Console.WriteLine("POSITIONS TEST");
            
            p1.AddPosition(PlayerPosition.GK);
            Console.WriteLine("Adding GK:");
            foreach (var pos in p1.Positions)
            {
                Console.WriteLine(pos);
            }
            Console.WriteLine("Adding FW:");
            p1.AddPosition(PlayerPosition.FW);
            foreach (var pos in p1.Positions)
            {
                Console.WriteLine(pos);
            }
            Console.WriteLine("Removing GK:");
            p1.RemovePosition(PlayerPosition.GK);
            foreach (var pos in p1.Positions)
            {
                Console.WriteLine(pos);
            }
        }
    }
}
