namespace FootballStats.Persons
{
    using System;
    using System.Text;
    using FootballStats.Common;

    public class StaffMember : ClubAffiliatedPerson, IStaffMember
    {
        private StaffPosition staffPosition = StaffPosition.NotSet;
        private string afiliatedClub;

        public StaffMember(string firstName, string middleName, string lastName, string birthDate, Nationality nationality)
            : base(firstName, middleName, lastName, birthDate, nationality)
        {
            this.AfiliatedClub = "NotSet";
        }

        public string AfiliatedClub
        {
            get { return this.afiliatedClub; }
            set { this.afiliatedClub = value; }
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
            string returnValue = string.Format("{0};{1};{2};{3}", base.ToString(), this.StaffPosition.ToString(), this.AfiliatedClub, this.WeeklyWage());

            return returnValue.ToString();
        }
    }
}
