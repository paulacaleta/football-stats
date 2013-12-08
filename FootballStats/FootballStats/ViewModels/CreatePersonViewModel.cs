using System;
using System.Collections.Generic;
using FootballStats.Common;
using FootballStats.Competitions;
using FootballStats.Persons;

namespace FootballStats.ViewModels
{
    public class CreatePersonViewModel
    {
        // Shared
        public string PersonType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Nationality Nationality { get; set; }
        public string DateOfBirth { get; set; }

        // ClubAffiliated
        public decimal WeeklyWage { get; set; }

        public IEnumerable<string> PersonTypesList
        {
            get
            {
                return new List<string> { "Player", "Staff", "Referee" };
            }
        }

        // Player
        public PlayerPosition PlayerPosition { get; set; }

        // Staff
        public StaffPosition StaffPosition { get; set; }

        public bool CanExecute()
        {
            if (this.FirstName != null && this.LastName != null && this.DateOfBirth != null && this.Nationality != null)
            {
                return true;
            }
            return false;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute()
        {
            if (CanExecute())
            {                
                
                Person newPerson = CreatePerson(this.PersonType);
                if (newPerson is Referee)
                {
                    World.Referees.Add(newPerson as Referee);
                }
                else if (newPerson is Player)
                {
                    World.Players.Add(newPerson as Player);
                }
                else if (newPerson is StaffMember)
                {
                    World.Staff.Add(newPerson as StaffMember);
                }
                World.Save();
            }
            else
            {
                throw new InvalidProgramException("First name, last name, date of birth and nationality are mandatory!");
            }
        }

        private Person CreatePerson(string type)
        {
            if (type == "Player")
            {
                return CreatePlayer();
            }
            else if (type == "Staff")
            {
                return CreateStaff();
            }
            else if (type == "Referee")
            {
                return CreateReferee();
            }
            throw new NotImplementedException();
        }

        private Person CreateReferee()
        {
            Referee newReferee = new Referee(this.FirstName, this.MiddleName, this.LastName, this.DateOfBirth, this.Nationality);
            return newReferee;
        }

        private Person CreateStaff()
        {
            StaffMember newStaff = new StaffMember(this.FirstName, this.MiddleName, this.LastName, this.DateOfBirth, this.Nationality);
            newStaff.SetWeeklyWage(this.WeeklyWage);
            newStaff.SetStaffPosition(this.StaffPosition);
            return newStaff;
        }

        private Person CreatePlayer()
        {
            Player newPlayer = new Player(this.FirstName, this.MiddleName, this.LastName, this.DateOfBirth, this.Nationality);
            newPlayer.SetWeeklyWage(this.WeeklyWage);
            newPlayer.Position = this.PlayerPosition;
            return newPlayer;          
        }


    }
}
