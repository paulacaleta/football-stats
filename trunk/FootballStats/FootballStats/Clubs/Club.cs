namespace FootballStats.Clubs
{
    using System;
    using System.Collections.Generic;
    using FootballStats.Common;
    using FootballStats.Persons;
    using System.Text;

    public class Club : IClub, IClubStats
    {
        private const int ClubMaxLenght = 50;
        private const int ClubMinLenght = 2;

        private string name;
        private Nationality nationality;
        private List<Player> team = new List<Player>();
        private List<StaffMember> staff = new List<StaffMember>();

        public Club(string name, Nationality nationality)
        {
            this.Name = name;
            this.Nationality = nationality;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value != null)
                {
                    if (value.Length < ClubMinLenght)
                    {
                        string message = string.Format("Club name should be at least {0} characters.", ClubMinLenght);

                        throw new ArgumentOutOfRangeException(message);
                    }

                    if (value.Length > ClubMaxLenght)
                    {
                        string message = string.Format("Club name should be no longer than {0} characters.", ClubMaxLenght);

                        throw new ArgumentOutOfRangeException(message);
                    }

                    this.name = value;
                }
            }
        }

        public Nationality Nationality
        {
            get
            {
                return this.nationality;
            }

            set
            {
                this.nationality = value;
            }
        }

        public List<Player> Team
        {
            get
            {
                return this.team;
            }

            set
            {
                if (value is List<Player>)
                {
                    this.team = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Team.");
                }
            }
        }

        public List<StaffMember> Staff
        {
            get
            {
                return this.staff;
            }

            set
            {
                if (value is List<StaffMember>)
                {
                    this.staff = value;
                }
                else
                {
                    throw new ArgumentException("Invalid staff.");
                }
            }
        }

        #region Methods

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
            // TODO: verification
            this.Team.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            // TODO: verification
            this.Team.Remove(player);
        }

        public void AddStaffMember(StaffMember staffMember)
        {
            // TODO: verification
            this.Staff.Add(staffMember);
        }

        public void RemoveStaffMember(StaffMember staffMember)
        {
            // TODO: verification
            this.Staff.Remove(staffMember);
        }

        public double TeamAverageAge()
        {
            // TODO: verification
            double averageAge = 0;
            foreach (var player in this.Team)
            {
                averageAge += (double)player.GetAge();
            }

            return averageAge / this.Team.Count;
        }

        public int TotalPlayersAtClub()
        {
            return this.Team.Count;
        }

        public int TotalPlayersPerPosition(PlayerPosition position)
        {
            // TODO: verification ??
            int playersPerPosition = 0;

            foreach (var player in this.Team)
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
            foreach (var staffMember in this.Staff)
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
            // TODO: verification
            decimal avregeWage = 0;

            foreach (var player in this.Team)
            {
                avregeWage += player.MonthlyWage();
            }

            return avregeWage / this.Team.Count;
        }

        public decimal AverageWageOfStaff()
        {
            // TODO: verification
            decimal avregeWage = 0;

            foreach (var staffmember in this.Staff)
            {
                avregeWage += staffmember.MonthlyWage();
            }

            return avregeWage / this.Team.Count; // !
        }

        public decimal HighestPlayerWage()
        {
            // TODO: verification
            decimal highestPlayerWage = 0;

            foreach (var player in this.Team)
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
            // TODO: verification
            int count = 0;

            foreach (var player in this.Team)
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
            // TODO: verification
            // we may use this method to verify other methods
            if (this.Team.Contains(player))
            {
                return true;
            }

            return false;
        }

        #endregion

        public override string ToString()
        {
            string teamAndStaffForPrint = null;
            StringBuilder sb = new StringBuilder();
           
            if (this.Team.Count != 0 )
            {
                sb.AppendLine(new string('#', 80));
                sb.AppendLine("Team :");
                sb.AppendLine(new string('#', 80));
                sb.AppendLine();
                foreach (var player in this.Team)
                {
                    sb.Append(player.ToString());
                    sb.Append('\n');
                }
            }

            if (this.Staff.Count != 0)
            {
                sb.AppendLine(new string('#', 80));
                sb.AppendLine("Staff :");
                sb.AppendLine(new string('#', 80));
                sb.AppendLine();
                foreach (var player in this.Team)
                {
                    sb.Append(player.ToString());
                    sb.Append('\n');
                }
            }

            teamAndStaffForPrint = sb.ToString();

            string stringValue = String.Format("Club Name: {0}\nNationality: {1}\n{2}", name, nationality.ToString(), teamAndStaffForPrint ?? "null");

            return stringValue.ToString();
        }
    }
}
