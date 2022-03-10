using DevTeams_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Console
{
    public class ProgramUI
    {
        //This class will be how we interact with our user through the console. When we need to access our data, we will call methods from our Repo class.

        private DevTeamsRepo _repo = new DevTeamsRepo();
        

        public void Run()
        {
            SeedContent();
            Menu();
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number that corresponds to the option you would like: \n" +
                    "1. Add developer \n" +
                    "2. Show me all developers \n" +
                    "3. Show developers by Team \n" +
                    "4. Show developers by ID \n" +
                    "5. Update developer info \n" +
                    "6. Remove developer \n" +
                    "7. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateNewDeveloper();
                        break;
                    case "2":
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        DisplayDevelopersByTeam();
                        break;
                    case "4":
                        DisplayDevelopersById();
                        break;
                    case "5":
                        UpdateExistingDeveloper();
                        break;
                    case "6":
                        DeleteExistingDeveloper();
                        break;
                    case "7":
                    case "exit":
                    case "Exit":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Error input was not one of the options above. To retry Prease any key to contniue...");
                        Console.ReadKey(); //might come back and plug in the AnyKey helper
                        break;


                }
            }


            




            //Start with the main menu here
            //Menu options we'll need and the methods you'll need to make

            //CreateNewDeveloper();
            //DisplayAllDevelopers();


            //DisplayDevelopersByTeam();
            //DisplayDeveloperById();
            //UpdateExistingDeveloper();
            //DeleteExistingDeveloper();
        }

        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer dev = new Developer();

            //First Name
            Console.Write("What is the first name of the new Developer? ");
            dev.FirstName = Console.ReadLine();

            //Last Name
            Console.Write("What is the last name of the new Developer? ");
            dev.LastName = Console.ReadLine();

            //ID
            Console.Write("What is the three digit ID number of the new Developer? ");
            dev.ID = int.Parse(Console.ReadLine());


            //HasAccessToPluralsight
            Console.Write("Do they have access to Pluralsight? \n" +
                "1. Yes\n" +
                "2. No\n");
            string pluralSightAnswer = Console.ReadLine();
            switch(pluralSightAnswer.ToLower())
            {
                case "1":
                case "yes":
                    dev.HasAccessToPluralsight = true;
                    break;
                case "2":
                case "no":
                default:
                    dev.HasAccessToPluralsight = false;
                    break;

            }


            Console.Write("What team is the new Developer on? \n" +
                "1. FrontEnd \n" +
                "2. BackEnd \n" +
                "3. Testing \n");

            string assignmentAnswer = Console.ReadLine();

            switch (assignmentAnswer.ToLower())
            {
                case "1":
                case "frontend":
                default://if something goes wrong check here
                    dev.Assignment = TeamAssignment.FrontEnd;
                    break;
                case "2":
                case "backend":
                    dev.Assignment = TeamAssignment.BackEnd;
                    break;
                case "3":
                case "testing":
                    dev.Assignment = TeamAssignment.Testing;
                    break;
            }

            //Assignment (which team)



        }


        private void UpdateExistingDeveloper()
        {

            Console.Clear();
            List<Developer> listOfDevs = _repo.GetAllDevs();
            foreach (Developer dev in listOfDevs)
            {
                ShowDevs(dev);

            }


            Console.Write("Please provide the ID number of the developer you would like to update: ");
            int answer = int.Parse(Console.ReadLine());

            Developer oldDev = _repo.GetDevById(answer);

            if (oldDev != null)
            {

                Console.Write("Please enter new first name: ");
                string newName = Console.ReadLine();
                if (newName != "")
                {
                    oldDev.FirstName = newName;
                }

                Console.Write("Please enter new last name: ");
                string newLast = Console.ReadLine();
                if (newLast != "")
                {
                    oldDev.LastName = newLast;
                }

                Console.Write("Please enter the new ID number: ");
                string newiD = Console.ReadLine();

                if (newiD != "")
                {
                    oldDev.ID = int.Parse(newiD);
                }

                Console.Write("Do they have access to Pluralsight? \n" +
                "1. Yes\n" +
                "2. No\n");
                string pluralSightAnswer = Console.ReadLine();
                switch (pluralSightAnswer.ToLower())
                {
                    case "1":
                    case "yes":
                        oldDev.HasAccessToPluralsight = true;
                        break;
                    case "2":
                    case "no":
                    default:
                        oldDev.HasAccessToPluralsight = false;
                        break;

                }

                Console.Write("What team is the new Developer on? \n" +
               "1. FrontEnd \n" +
               "2. BackEnd \n" +
               "3. Testing \n");

                string assignmentAnswer = Console.ReadLine();

                switch (assignmentAnswer.ToLower())
                {
                    case "1":
                    case "frontend":
                    default://if something goes wrong check here
                        oldDev.Assignment = TeamAssignment.FrontEnd;
                        break;
                    case "2":
                    case "backend":
                        oldDev.Assignment = TeamAssignment.BackEnd;
                        break;
                    case "3":
                    case "testing":
                        oldDev.Assignment = TeamAssignment.Testing;
                        break;
                }


            }
            else
                Console.WriteLine("No one to update");
            AnyKey();


        }





        private void DisplayAllDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevs = _repo.GetAllDevs();
            foreach(Developer dev in listOfDevs)
            {
                ShowDevs(dev);

            }
            AnyKey(); 

        }

        private void DisplayDevelopersByTeam()
        {
            Console.Clear();

            TeamAssignment assignment = new TeamAssignment();


            Console.Write("What team would you like to see?: \n" +
                "1. FrontEnd \n" +
                "2. BackEnd \n" +
                "3. Testing \n");
            string answer = Console.ReadLine();

            switch(answer.ToLower())
            {
                case "1":
                case "frontend":
                    assignment = TeamAssignment.FrontEnd;
                    break;
                case "2":
                case "backend":
                    assignment = TeamAssignment.BackEnd;
                    break;
                case "3":
                case "testing":
                    assignment = TeamAssignment.Testing;
                    break;
            }



            List<Developer> displayDevTeam = _repo.GetDevsByAssignment(assignment);
            foreach( Developer dev in displayDevTeam)
            {
                ShowDevs(dev);
                
            }
            AnyKey();

        }


        private void DisplayDevelopersById()
        {
            Console.Clear();

            Console.Write("Enter ID: ");
            int iD = int.Parse(Console.ReadLine());

            Developer dev = _repo.GetDevById(iD);
            if(dev != null)
            {
                ShowDevs(dev);
            }
            else
            {
                Console.WriteLine("No ID found");
            }
            AnyKey();

        }




        private void DeleteExistingDeveloper()
        {
            Console.Clear();

            List<Developer> devList = _repo.GetAllDevs();

            foreach (Developer dev in devList)
            {
                ShowDevs(dev);
            }

            Console.Write("Enter the ID number of the individual you would like to fire: ");

            int userAnser = int.Parse(Console.ReadLine());

            if (_repo.RemoveDevById(userAnser))
            {
                Console.WriteLine("Developer successfully fired!");
            }
            else
            {
                Console.WriteLine("No Developer found by that ID");
            }
            AnyKey();

        }




        // Helpermethods you should write
        // A method to print a developer's first and last name, useful in display all
        // private void DisplayDevBasicInfo(Developer dev) {}

        // A method to print a developers full information, useful when showing one developer
        // private void DisplayDevFullInfo(Developer dev) {}


        private void SeedContent()
        {
            Developer bill = new Developer("Bill", "Johnson", 334, true, TeamAssignment.Testing);
            Developer jill = new Developer("Jill", "Long", 223, true, TeamAssignment.FrontEnd);
            Developer crunchy = new Developer("Princess Crunchy", "The Unforgiving", 009, false, TeamAssignment.BackEnd);
            Developer ted = new Developer("Ted", "Danson", 559, false, TeamAssignment.FrontEnd);
            Developer meryl = new Developer("Meryl", "Streep", 444, true, TeamAssignment.Testing);
            Developer jim = new Developer("Jimmy", "Johns", 111, false, TeamAssignment.BackEnd);

            _repo.CreateNewDeveloper(bill);
            _repo.CreateNewDeveloper(jill);
            _repo.CreateNewDeveloper(crunchy);
            _repo.CreateNewDeveloper(ted);
            _repo.CreateNewDeveloper(meryl);
            _repo.CreateNewDeveloper(jim);
        }

        private void ShowDevs(Developer developer)
        {
            //ask someone how to make hasaccesstopluralsight yes or no
            string answer = (developer.HasAccessToPluralsight) ? "yes" : "No";
            Console.WriteLine($"Developer's Name : {developer.FirstName} {developer.LastName} \n" +
                $"Developer ID number: {developer.ID} \n" +
                $"Do they have access to Pluralsight: {answer}\n" +
                $"Developer team: {developer.Assignment}\n");

        }


        private void AnyKey()
        {
            Console.WriteLine("Press any key to contniue...");
            Console.ReadKey();
        
        }


    }
}
