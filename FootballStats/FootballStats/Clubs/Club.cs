namespace FootballStats.Clubs
{
    using System;
    using System.Collections.Generic;
    using FootballStats.Common;
    using FootballStats.Persons;

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

        #region Properties        

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

        public List<ClubAffiliatedPerson> PlayersAndStaff
        {
            get
            {
                List<ClubAffiliatedPerson> playersAndStaff = new List<ClubAffiliatedPerson>();
                playersAndStaff.AddRange(this.Team);
                playersAndStaff.AddRange(this.Staff);
                return playersAndStaff;
            }
        }

        public StaffMember Manager
        {
            get
            {
                if (this.HasManager())
                {
                    for (int i = 0; i < this.Staff.Count; i++)
                    {
                        if (this.Staff[i].StaffPosition == StaffPosition.Manager)
                        {
                            return this.Staff[i];
                        }
                    }
                }

                return null;
            }
        }

        #endregion

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
            if (!this.Team.Contains(player))
            {
                this.Team.Add(player);
                return;
            }

            string message = string.Format("{0} is already at this club!", player);
            throw new ClubException(message);
        }

        public void RemovePlayer(Player player)
        {
            if (this.Team.Contains(player))
            {
                this.Team.Remove(player);
                player.AffiliatedClub = "Free Agent";                
                return;
            }

            string message = string.Format("{0} is not playing for this club!", player);
            throw new ClubException(message);
        }

        public void AddStaffMember(StaffMember staffMember)
        {
            if (!this.Staff.Contains(staffMember))
            {
                this.Staff.Add(staffMember);
                return;
            }

            string message = string.Format("{0} is already at this club!", staffMember);
            throw new ClubException(message);
        }

        public void RemoveStaffMember(StaffMember staffMember)
        {
            if (this.Staff.Contains(staffMember))
            {
                staffMember.AffiliatedClub = "Free Agent";
                this.Staff.Remove(staffMember);
                return;
            }

            string message = string.Format("{0} does not exist!", staffMember);
            throw new ClubException(message);
        }

        public double TeamAverageAge()
        {
            if (this.Team.Count == 0)
            {
                string message = string.Format("Team {0} does not have any players!", this.Team);
                throw new ClubException(message);
            }

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
            int playersPerPosition = 0;

            foreach (var player in this.Team)
            {
                if (player.Position == position)
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
                if (staffMember.StaffPosition.Equals(StaffPosition.Manager))
                {
                    return true;
                }
            }

            return false;
        }

        public decimal AverageWageOfPlayers()
        {
            if (this.Team.Count == 0)
            {
                string message = string.Format("Team {0} does not have players!", this.Team);
                throw new ClubException(message);
            }

            decimal avregeWage = 0;

            foreach (var player in this.Team)
            {
                avregeWage += player.WeeklyWage();
            }

            return avregeWage / this.Team.Count;
        }

        public decimal AverageWageOfStaff()
        {
            if (this.Staff.Count == 0)
            {
                string message = string.Format("Team {0} does not have staff members!", this.Staff);
                throw new ClubException(message);
            }

            decimal avregeWage = 0;

            foreach (var staffmember in this.Staff)
            {
                avregeWage += staffmember.MonthlyWage();
            }

            return avregeWage / this.Team.Count;
        }

        public decimal HighestPlayerWage()
        {
            if (this.Team.Count == 0)
            {
                string message = string.Format("Team {0} does not have players!", this.Team);
                throw new ClubException(message);
            }

            decimal highestPlayerWage = 0;

            foreach (var player in this.Team)
            {
                if (player.WeeklyWage() > highestPlayerWage)
                {
                    highestPlayerWage = player.WeeklyWage();
                }
            }

            return highestPlayerWage;
        }

        public int CountPlayersWithSameNationality(Nationality nationality)
        {
            if (this.Team.Count == 0)
            {
                string message = string.Format("Team {0} does not have players!", this.Team);
                throw new ClubException(message);
            }

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
            if (this.Team.Contains(player))
            {
                return true;
            }

            return false;
        }

        #endregion

        public override bool Equals(object obj)
        {
            Club club = obj as Club;

            if (club == null)
            {
                return false;
            }

            if (this.Name != club.Name)
            {
                return false;                
            }

            if (this.Nationality != club.Nationality)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string stringValue = string.Format("{0}", this.Name);
            return stringValue.ToString();
        }        

        public string Serialize()
        {
            return string.Format("{0};{1}", this.Name, this.Nationality);
        }
    }
}
