namespace FootballStats.Persons
{
    public interface IStaffMember
    {
        StaffPosition StaffPosition { get; }

        void SetStaffPosition(StaffPosition newStaffPosition);
    }
}
