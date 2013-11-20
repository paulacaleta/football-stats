using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStats
{
    public class Player
    {
        private string name;
        private string dateOfBirth;

        public Player(string name, string dateOfBirth) 
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
        }
        

        public override string ToString()
        {
            string returnValue = String.Format("Name: {0}, Date of birth: {1}", name, dateOfBirth.ToString());

            return returnValue.ToString();
        }
    }
}
