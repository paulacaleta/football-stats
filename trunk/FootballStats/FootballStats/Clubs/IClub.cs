using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballStats.Common;
using FootballStats.Persons;

namespace FootballStats.Clubs
{
    public interface IClub
    {
        string Name { get; }
        Nationality Nationality { get; }
        string Location { get; }        
        List<Player> Team { get; }
        List<StaffMember> Staff { get; }

        void ChangeName(string newName);
        void ChangeNationality(Nationality newNationality);
        void ChangeLocation(string newLocation);
        void AddPlayer(Player player);
        void RemovePlayer(Player player);
        void AddStaffMember(StaffMember staffMember);
        void RemoveStaffMember(StaffMember staffMember);
    }
}
