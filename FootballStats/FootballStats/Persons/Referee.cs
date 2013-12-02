namespace FootballStats.Persons
{
    using FootballStats.Common;

    public class Referee : Person
    {
        public Referee(string firstName, string middleName, string lastName, string birthDate, Nationality nationality)
            : base(firstName, middleName, lastName, birthDate, nationality)
        {
        }

        public override string Serialize()
        {
            return base.Serialize() + ";%";
        }
    }
}
