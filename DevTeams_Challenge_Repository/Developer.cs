using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public enum TeamAssignment { FrontEnd, BackEnd, Testing}
    public class Developer
    {

        public Developer() { }

        public Developer(string firstName, string lastname, int iD, bool pluralsight, TeamAssignment assignment)
        {
            FirstName = firstName;
            LastName = lastname;
            ID = iD;
            HasAccessToPluralsight = pluralsight;
            Assignment = assignment;
             


        }

        public string FirstName { get; set; }
        public int ID { get; set; }

        public string LastName { get; set; }

        public bool HasAccessToPluralsight { get; set; }

        public TeamAssignment Assignment { get; set; }

    }
}
