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

        //This is our POCO class. It will define our properties and constructors of our Developer objects.
        //Developer objects should have the following properties
            //ID (int)
            //FirstName
            //LastName
            //a bool that shows whether they have access to the online learning tool Pluralsight.
            //TeamAssignment - use the enum declared above this class
        public string FirstName { get; set; }
        public int ID { get; set; }

        public string LastName { get; set; }

        public bool HasAccessToPluralsight { get; set; }

        public TeamAssignment Assignment { get; set; }

    }
}
