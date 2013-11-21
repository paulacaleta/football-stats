namespace FootballStats.Persons
{
    using System;
    using System.Text;
    using FootballStats.Common;

    public class StaffMember : ClubAffiliatedPerson, IStaffMember
    {
        private StaffPosition staffPosition = StaffPosition.NotSet;

        public StaffMember(string firstName, string middleName, string lastName, string birthDate, Nationality nationality)
            : base(firstName, middleName, lastName, birthDate, nationality)
        {
        }

        public StaffPosition StaffPosition
        {
            get
            {
                return this.staffPosition;
            }
        }

        public void SetStaffPosition(StaffPosition newStaffPosition)
        {
            this.staffPosition = newStaffPosition;
        }

        public override string ToString()
        {
            string returnValue = string.Format("{0}\nPosition: {1}\n", base.ToString(), this.StaffPosition.ToString());

            return returnValue.ToString();
        }
    }
}
