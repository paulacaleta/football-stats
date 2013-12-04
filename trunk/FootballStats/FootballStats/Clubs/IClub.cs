namespace FootballStats.Clubs
{
    using System.Collections.Generic;
    using FootballStats.Common;
    using FootballStats.Persons;

    public interface IClub
    {
        string Name { get; }

        Nationality Nationality { get; }

        StaffMember Manager { get; }

        List<Player> Team { get; }

        List<StaffMember> Staff { get; }

        void ChangeName(string newName);

        void ChangeNationality(Nationality newNationality);

        void AddPlayer(Player player);

        void RemovePlayer(Player player);

        void AddStaffMember(StaffMember staffMember);

        void RemoveStaffMember(StaffMember staffMember);

        bool ContainsPlayer(Player player);
    }
}
