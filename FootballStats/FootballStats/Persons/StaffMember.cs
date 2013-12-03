namespace FootballStats.Persons
{
    using System;
    using System.Text;
    using FootballStats.Common;

    public class StaffMember : ClubAffiliatedPerson, IStaffMember
    {
        private StaffPosition staffPosition = StaffPosition.NotSet;
        private string affiliatedClub;

        public StaffMember(string firstName, string middleName, string lastName, string birthDate, Nationality nationality)
            : base(firstName, middleName, lastName, birthDate, nationality)
        {
            this.AfiliatedClub = "NotSet";
        }

        public string AfiliatedClub
        {
            get { return this.affiliatedClub; }
            set { this.affiliatedClub = value; }
        }

        public StaffPosition StaffPosition
        {
            get
            {
                return this.staffPosition;
            }
            set 
            {
                this.staffPosition = value;
            }
        }

        public void SetStaffPosition(StaffPosition newStaffPosition)
        {
            this.staffPosition = newStaffPosition;
        }

        public override string Serialize()
        {
            string returnValue = string.Format("{0};{1};{2};{3}", base.Serialize(), this.StaffPosition.ToString(), this.AfiliatedClub, this.WeeklyWage());

            return returnValue.ToString();
        }
    }
}
