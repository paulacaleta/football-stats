using FootballStats.Common;

namespace FootballStats.Persons
{
    public interface IPerson
    {
        string GetName();
        Nationality Nationality { get; }
        int GetAge();
        void ChangeName(string firstName, string middleName, string lastName);
    }
}