using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStats
{
    class Program
    {
        static void Main(string[] args)
        {
           
            List<Player> playersOfClub = new List<Player>()
            {
                new Player("Pesho", "1990"), new Player("Pesho", "1990"), new Player("Pesho", "1990"),
                new Player("Pesho", "1990"), new Player("Pesho", "1990"), new Player("Pesho", "1990"), 
                new Player("Pesho", "1990"), new Player("Pesho", "1990"), new Player("Pesho", "1990")
            };

            Club levski = new Club("Levski", playersOfClub);

            List<Player> playersOfClubTwo = new List<Player>()
            {
                new Player("Gosho", "1990"), new Player("Gosho", "1990"), new Player("Gosho", "1990"),
                new Player("Gosho", "1990"), new Player("Gosho", "1990"), new Player("Gosho", "1990"), 
                new Player("Gosho", "1990"), new Player("Gosho", "1990"), new Player("Gosho", "1990")
            };

            Club cska = new Club("Cska", playersOfClubTwo);

            ReadWriteClubDataBase.WriteInFile(levski.GetTeam(), "Levski");
            ReadWriteClubDataBase.WriteInFile(cska.GetTeam(), "Cska");

           // Console.WriteLine(ReadWriteClubDataBase.ReadInformationAbouthClub("Levski"));
           // Console.WriteLine(ReadWriteClubDataBase.ReadInformationAbouthClub("Cska"));

            Match derbi = new Match(levski, cska);
            Console.WriteLine();
            Console.WriteLine(derbi.ToString());

            while (true)
            {
                
            }
        }
    }
}
