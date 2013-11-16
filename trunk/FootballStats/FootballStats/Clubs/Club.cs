using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballStats.Common;
using FootballStats.Persons;

namespace FootballStats.Clubs
{
    public class Club : IClub, IClubStats
    {
        string name;
        Nationality nationality;
        List<Persons.Player> team;
        List<Persons.StaffMember> staff;

        int clubMaxLenght = 50;
        int clubMinLenght = 2;

        public Club(string name, Nationality nationality, List<Persons.Player> team, List<Persons.StaffMember> staff) 
        {
            this.Name = name;
            this.Nationality = nationality;
            this.Team = team;
            this.Staff = staff;
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (value != null)
                {
                    if (value.Length < clubMinLenght)
                    {
                        string message = string.Format(
                            "Club name should be at least {0} characters.", clubMinLenght);

                        throw new ArgumentOutOfRangeException(message);
                    }

                    if (value.Length > clubMaxLenght)
                    {
                        string message = string.Format(
                            "Club name should be no longer than {0} characters.", clubMaxLenght);

                        throw new ArgumentOutOfRangeException(message);
                    }

                    this.name = value;
                }
            }
        }
        public Common.Nationality Nationality
        {
            get { return this.nationality; }

            set
            {
                this.nationality = value;
            }
        }
        public List<Persons.Player> Team
        {
            get { return this.team; }

            private set
            {
                if (value is List<Persons.Player>)
                {
                    this.team = value;
                }
                else
                {
                    throw new Exception("Invalid Team.");
                }
            }
        }
        public List<Persons.StaffMember> Staff
        {
            get { return this.staff; }

            private set
            {
                if (value is List<Persons.StaffMember>)
                {
                    this.staff = value;
                }
                else
                {
                    throw new Exception("Invalid staff.");
                }
            }
        }

        //Methods
        public void ChangeName(string newName)
        {
            this.Name = newName;
        }
        public void ChangeNationality(Common.Nationality newNationality)
        {
            this.Nationality = newNationality;
        }
        public void AddPlayer(Persons.Player player)
        {
            this.team.Add(player);
        }
        public void RemovePlayer(Persons.Player player)
        {
            this.team.Remove(player);
        }
        public void AddStaffMember(Persons.StaffMember staffMember)
        {
            this.staff.Add(staffMember);
        }
        public void RemoveStaffMember(Persons.StaffMember staffMember)
        {
            this.staff.Remove(staffMember);
        }


        public double TeamAverageAge() 
        {
            double averageAge = 0;
            foreach (var player in this.team)
            {
                averageAge += (double)player.GetAge();
            }

            return averageAge / this.team.Count;
        }
        public int TotalPlayersAtClub() 
        {
            return this.team.Count;
        }
        public int TotalGoalkeepers() 
        {
            int totalGK = 0;
            foreach (var player in team)
            {
                if (player.Positions.Contains(PlayerPosition.GK))
                {
                    totalGK++;
                }
            }

            return totalGK;
        }
        public int TotalDefenders() 
        {
            int totalDF = 0;
            foreach (var player in team)
            {
                if (player.Positions.Contains(PlayerPosition.DF))
                {
                    totalDF++;
                }
            }

            return totalDF;
        }
        public int TotalForwards() 
        {
            int totalFW = 0;
            foreach (var player in team)
            {
                if (player.Positions.Contains(PlayerPosition.FW))
                {
                    totalFW++;
                }
            }

            return totalFW;
        }
        public bool HasManager() 
        {
            foreach (var staffMember in staff)
            {
                if (staffMember.StaffPosition.Equals(StaffPosition.Coach))
                {
                    return true;
                }
            }

            return false;
        }
        public decimal AverageWageOfPlayers() 
        {
            decimal avregeWage = 0;
            
            foreach (var player in this.team)
            {
                avregeWage += player.MonthlyWage();
            }

            return avregeWage;
        }
        public decimal AverageWageOfStaff() 
        {
            decimal avregeWage = 0;

            foreach (var staffmember in this.staff)
            {
                avregeWage += staffmember.MonthlyWage();
            }

            return avregeWage;
        }
        public decimal HighestPlayerWage() 
        {
            decimal highestWage = 0;

            foreach (var staffmember in staff)
            {
                if (staffmember.MonthlyWage() > highestWage)
                {
                    highestWage = staffmember.MonthlyWage();
                }
            }

            foreach (var player in team)
            {
                if (player.MonthlyWage() > highestWage)
                {
                     highestWage = player.MonthlyWage();
                }
            }

            return highestWage;
        }
    }
}
