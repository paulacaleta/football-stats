using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FootballStats;
using FootballStats.Common;

namespace FootballStats.Persons
{
    public class StaffMember : ClubAffiliatedPerson, IStaffMember
    {
        private StaffPosition staffPosition = StaffPosition.NotSet;
        
        public StaffMember(string firstName, string middleName, string lastName, string birthDate, Nationality nationality)
            : base(firstName, middleName, lastName, birthDate, nationality)
        {
        }

        public StaffPosition StaffPosition
        {
            get { return this.staffPosition; }
        }

        public void SetStaffPosition(StaffPosition newStaffPosition)
        {
            this.staffPosition = newStaffPosition;
        }
    }
}
