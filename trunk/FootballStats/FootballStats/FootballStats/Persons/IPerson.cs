namespace FootballStats.Persons
{
    using FootballStats.Common;

    public interface IPerson
    {
        Nationality Nationality { get; }

        string GetName();

        int GetAge();

        void ChangeName(string firstName, string middleName, string lastName);
    }
}