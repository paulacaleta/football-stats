using FootballStats.Common;
using FootballStats.Competitions;
using FootballStats.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootballStats.ViewModels
{
    public class CreatePersonViewModel : ICommand
    {
        // Shared
        public string PersonType { get; set; }

        public 
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Nationality Nationality { get; set; }
        public string DateOfBirth { get; set; }

        // ClubAffiliated
        public decimal WeeklyWage { get; set; }

        // Player
        public IList<PlayerPosition> PlayerPositions { get; set; }

        // Staff
        public StaffPosition StaffPosition { get; set; }

        public bool CanExecute(object parameter)
        {
            if (this.FirstName != null && this.LastName != null && this.DateOfBirth != null && this.Nationality != null)
            {
                return true;
            }
            return false;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (this.PersonType == "player")
            {
                CreatePlayer();
            }
            else if (this.PersonType == "staff")
            {
                CreateStaff();
            }
            else if (this.PersonType == "referee")
            {
                CreateReferee();
            }
        }

        private void CreateReferee()
        {
            Referee newReferee = new Referee(this.FirstName, this.MiddleName, this.LastName, this.DateOfBirth, this.Nationality);
            // TODO: Add where?
        }

        private void CreateStaff()
        {
            StaffMember newStaff = new StaffMember(this.FirstName, this.MiddleName, this.LastName, this.DateOfBirth, this.Nationality);
            newStaff.SetWeeklyWage(this.WeeklyWage);
            newStaff.SetStaffPosition(this.StaffPosition);
            // TODO: Add where?
        }

        private void CreatePlayer()
        {
            Player newPlayer = new Player(this.FirstName, this.MiddleName, this.LastName, this.DateOfBirth, this.Nationality);
            newPlayer.SetWeeklyWage(this.WeeklyWage);
            foreach (var pos in this.PlayerPositions)
            {
                newPlayer.AddPosition(pos);
            }
            // TODO: Add where?
        }

        
    }
}
