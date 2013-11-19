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
        private string name;
        private Nationality nationality;
        private List<Player> team = new List<Player>();
        private List<StaffMember> staff = new List<StaffMember>();

        int clubMaxLenght = 50;
        int clubMinLenght = 2;

        public Club(string name, Nationality nationality) 
        {
            this.Name = name;
            this.Nationality = nationality;
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
        public Nationality Nationality
        {
            get { return this.nationality; }

            set
            {
                this.nationality = value;
            }
        }
        public List<Player> Team
        {
            get { return this.team; }

            private set
            {
                if (value is List<Player>)
                {
                    this.team = value;
                }
                else
                {
                    throw new Exception("Invalid Team.");
                }
            }
        }
        public List<StaffMember> Staff
        {
            get { return this.staff; }

            private set
            {
                if (value is List<StaffMember>)
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
        public void ChangeNationality(Nationality newNationality)
        {
            this.Nationality = newNationality;
        }
        public void AddPlayer(Player player)
        {
            this.team.Add(player);
        }
        public void RemovePlayer(Player player)
        {
            this.team.Remove(player);
        }
        public void AddStaffMember(StaffMember staffMember)
        {
            this.staff.Add(staffMember);
        }
        public void RemoveStaffMember(StaffMember staffMember)
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
        public int TotalPlayersPerPosition(PlayerPosition position)
        {
            int playersPerPosition = 0;

            foreach (var player in team)
            {
                if (player.Positions.Contains(position))
                {
                    playersPerPosition++;
                }
            }

            return playersPerPosition;
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

            return avregeWage / this.team.Count;
        }
        public decimal AverageWageOfStaff() 
        {
            decimal avregeWage = 0;

            foreach (var staffmember in this.staff)
            {
                avregeWage += staffmember.MonthlyWage();
            }

            return avregeWage / this.team.Count;
        }
        public decimal HighestPlayerWage() 
        {
            decimal highestPlayerWage = 0;

            foreach (var player in team)
            {
                if (player.MonthlyWage() > highestPlayerWage)
                {
                    highestPlayerWage = player.MonthlyWage();
                }
            }

            return highestPlayerWage;
        }
        public int CountPlayersWithSameNationality(Nationality nationality) 
        {
            int count = 0;

            foreach (var player in this.team)
            {
                if (player.Nationality.Equals(nationality))
                {
                    count++;
                }
            }

            return count;
        } 

        public bool ContainsPlayer(Player player)
        {
            if (Team.Contains(player))
            {
                return true;
            }
            return false;
        }
    }
}
