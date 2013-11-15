using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballStats.Common;
using FootballStats.Persons;

namespace FootballStats.Clubs
{
    public class Club : IClub
    {
        string name;
        Nationality nationality;
        List<Persons.Player> team;
        List<Persons.StaffMember> staff;

        int clubMaxLenght = 50;
        int clubMinLenght = 2;

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
                if (value is Nationality)
                {
                    this.nationality = value;
                }
                else
                {
                    throw new Exception("Unrecognisable nationality.");
                }
            }
        }
        public List<Persons.Player> Team
        {
            get { return this.team; }
        }
        public List<Persons.StaffMember> Staff
        {
            get { return this.staff; }
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
    }
}
