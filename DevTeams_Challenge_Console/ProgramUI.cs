using DevTeams_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Console
{
    //Start with the main menu here
    //Menu options we'll need and the methods you'll need to make

    //CreateNewDeveloper();
    //DisplayAllDevelopers();


    //DisplayDevelopersByTeam();
    //DisplayDeveloperById();
    //UpdateExistingDeveloper();
    //DeleteExistingDeveloper();


    public class ProgramUI
    {
        //This class will be how we interact with our user through the console. When we need to access our data, we will call methods from our Repo class.

        private DevTeamRepo _teamRepo = new DevTeamRepo();

        public void Run()
        {
            SeedContent();
            Menu();
        }

        // Could 


        //createnew deve team();
        //add developer to devteam ();


        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
               // bool showDev = true;
                //if (showDev)
                //{
                    
                    Console.Clear();

                    Console.WriteLine("Enter the number that corresponds to the option you would like: \n" +
                        "1. Add developer \n" +
                        "2. Show me all developers \n" +
                        "3. Show developers by skill set \n" +
                        "4. Show developers by ID \n" +
                        "5. Update developer info \n" +
                        "6. Remove developer \n" +
                        "7. Create a new team \n" +
                        "8. Show me all teams \n" +
                        "9. Add a developer to a team \n" +
                        "10. Remove a devloper from a team \n" +
                        "11. Add multiple developers to a team \n" +
                        "12. Remove multiple developers from a team \n" +
                        "13. Display team by ID \n" +
                        "14. Update team \n" +
                        "15. Remove team\n" +
                        "16. Check developers that need Pluralsight\n" +
                        "17. Exit \n");

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
                            DisplayDevelopersBySkillSet();
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
                            CreateNewTeam();
                            break;
                        case "8":
                            DisplayAllTeams();
                            break;
                        case "9":
                            AddDeveloperToTeam();
                            break;
                        case "10":
                            RemoveDeveloperFromTeam();
                            break;
                        case "11":
                            AddMultipleDevelopersToTeam();
                            break;
                        case "12":
                            RemoveMultipleDevelopersFromTeam();
                            break;
                        case "13":
                            DisplayTeamByTeamId();
                            break;
                        case "14":
                            UpdateTeam();
                            break;
                        case "15":
                            DeleteExistingTeam();
                            break;
                        case "16":
                            DisplayDevelopersNeedPluralsight();
                            break;
                        case "17":
                        case "e":
                        case "exit":
                        case "Exit":
                            continueToRun = false;
                            break;
                        default:
                            Console.WriteLine("Error input was not one of the options above. To retry Prease any key to contniue...");
                            Console.ReadKey(); //might come back and plug in the AnyKey helper
                            break;


                    }


               // }
                


            }
        }
        //Developer 
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer dev = new Developer();
            //DevTeam team = new DevTeam();

            //First Name
            Console.Write("What is the first name of the new Developer? ");
            dev.FirstName = Console.ReadLine();

            //Last Name
            Console.Write("What is the last name of the new Developer? ");
            dev.LastName = Console.ReadLine();

            //ID
            Console.Write("What is the temporary ID number of the new Developer? ");
            dev.ID = int.Parse(Console.ReadLine());


            //HasAccessToPluralsight
            Console.Write("Do they have access to Pluralsight? \n" +
                "1. Yes\n" +
                "2. No\n");
            string pluralSightAnswer = Console.ReadLine();
            switch (pluralSightAnswer.ToLower())
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


            Console.Write("What skill set does the new Developer have? \n" +
                "1. FrontEnd \n" +
                "2. BackEnd \n" +
                "3. Testing \n");

            string assignmentAnswer = Console.ReadLine();

            switch (assignmentAnswer.ToLower())
            {
                case "1":
                case "frontend":
                default:
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


            if (_teamRepo.CreateNewDeveloper(dev))
            {
                Console.WriteLine("New Developer added!");
                Console.Write("Would you like to add the new developer to a team?\n" +
                    "1. Yes \n" +
                    "2. No \n");
                string teamAnswer = Console.ReadLine();
                switch(teamAnswer.ToLower())
                {
                    case "1":
                    case "yes":
                        AddDeveloperToTeam();
                        break;
                    case "2":
                    case "no":
                    default:
                        break;
                }//checking to see if it works
                
            }
            else
            {
                Console.WriteLine("Something went wrong Developer not added");
            }

            AnyKey();
            



        }


        private void UpdateExistingDeveloper()
        {

            Console.Clear();
            List<Developer> listOfDevs = _teamRepo.GetAllDevs();
            foreach (Developer dev in listOfDevs)
            {
                ShowDevs(dev);

            }


            Console.Write("Please provide the ID number of the developer you would like to update: ");
            int answer = int.Parse(Console.ReadLine());

            Developer oldDev = _teamRepo.GetDevById(answer);

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
                    default:
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


        private void DisplayDevelopersNeedPluralsight()
        {
            Console.Clear();
            List<Developer> listOfPluralsight = _teamRepo.GetDevsNeedPluralsight();
            foreach (Developer dev in listOfPluralsight)
            {
                ShowDevs(dev);
            }
            AnyKey();
        }

        private void DisplayAllDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevs = _teamRepo.GetAllDevs();
            foreach (Developer dev in listOfDevs)
            {
                ShowDevs(dev);

            }
            AnyKey();

        }

        private void DisplayDevelopersBySkillSet()
        {
            Console.Clear();

            TeamAssignment assignment = new TeamAssignment();


            Console.Write("What team would you like to see?: \n" +
                "1. FrontEnd \n" +
                "2. BackEnd \n" +
                "3. Testing \n");
            string answer = Console.ReadLine();

            switch (answer.ToLower())
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



            List<Developer> displayDevTeam = _teamRepo.GetDevsByAssignment(assignment);
            foreach (Developer dev in displayDevTeam)
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

            Developer dev = _teamRepo.GetDevById(iD);
            if (dev != null)
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

            List<Developer> devList = _teamRepo.GetAllDevs();

            foreach (Developer dev in devList)
            {
                ShowDevs(dev);
            }

            Console.Write("Enter the ID number of the individual you would like to delete: ");

            int userAnser = int.Parse(Console.ReadLine());

            if (_teamRepo.RemoveDevById(userAnser))
            {
                Console.WriteLine("Developer successfully deleted! You must now remove that developer from any teams they were on.");
                AnyKey();
                RemoveDeveloperFromTeam();
            }
            else
            {
                Console.WriteLine("No Developer found by that ID");
            }
            AnyKey();

        }


        //DevTeam

        private void DisplayAllTeams()
        {
            Console.Clear();
            List<DevTeam> listDevTeams = _teamRepo.GetAllTeams();
            foreach (DevTeam team in listDevTeams)
            {
                ShowTeam(team);
            }

            AnyKey();

        }


        private void DisplayTeamByTeamId()
        {
            Console.Clear();
            Console.Write("What team ID are you looking for? ");
            int answer = int.Parse(Console.ReadLine());

            DevTeam devTeams = _teamRepo.GetDevTeamById(answer);
            ShowTeam(devTeams);
            AnyKey();
        }


        private void AddDeveloperToTeam()
        {
            
            
            DisplayAllDevelopers();

            Console.Write("What is the ID of the Developer you would like to add? ");
            int devId = int.Parse(Console.ReadLine());

            DisplayAllTeams();

            Console.Write("What is the Team ID of the Team you would like the new Developer on? ");
            int teamId = int.Parse(Console.ReadLine());

            if(_teamRepo.AddDeveloperToTeamById(devId, teamId))
            {
                Console.WriteLine("It Worked good job!");
            }
            else
            {
                Console.WriteLine("Dev ID or Team ID not found!");
            }
            AnyKey();
        }


        private void CreateNewTeam()
        {
            Console.Clear();
            DevTeam team = new DevTeam();
            //team name
            Console.Write("What is the name of this team?  ");

            team.TeamName = Console.ReadLine();
            //teamID
           // Console.Write("What is the temporary team ID? ");
            //team.TeamID = int.Parse(Console.ReadLine());


            if(_teamRepo.AddNewTeam(team))
            {

                Console.WriteLine("New Team Created! Let's add some team memebers!");
                AnyKey();

                bool keepRunning = true;
                while(keepRunning)
                {
                    Console.Write("Would you like to: \n" +
                        "1. Create new Developer to add to my team. \n" +
                        "2. Add exisiting Developer to my team. \n" +
                        "3. Add multiple exisiting Developers to my team. \n" +
                        "4. Exit. \n");

                    string answer = Console.ReadLine();
                    switch(answer.ToLower())
                    {
                        case "1":
                            CreateNewDeveloper();
                            break;
                        case "2":
                            AddDeveloperToTeam();
                            break;
                        case "3":
                            AddMultipleDevelopersToTeam();
                            break;
                        case "4":
                        case "exit":
                        case "e":
                        default:
                            keepRunning = false;
                            break;
                    }

                }
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }
            AnyKey();

        }

        private void RemoveMultipleDevelopersFromTeam()
        {
            Console.Clear();
            DisplayAllTeams();
            Console.Write("Enter the ID numbers of the developers you would like to remove (please separate them with a space)  ");
            string devId = Console.ReadLine();
            var splitId = devId.Split(' ');

            //DisplayAllDevelopers();
            Console.Write("What is the team ID? ");
            int teamId = int.Parse(Console.ReadLine());
            foreach(var id in splitId)
            {
                _teamRepo.RemoveDeveloperFromTeamById(int.Parse(id), teamId);
            }
            Console.WriteLine("You removed all selected developers! \n");

            AnyKey();
        }


        private void AddMultipleDevelopersToTeam()
        {
            ///Com back to this 
            Console.Clear();
            DisplayAllDevelopers();
            Console.Write("Please enter the ID numbers of the developers you would like to add (please separate them with a space) ");
            string devID = Console.ReadLine();
            var splitId = devID.Split(' ');

            DisplayAllTeams();
            Console.Write("What is the team ID you would like to add these developers to? ");
            int teamId = int.Parse(Console.ReadLine());
            foreach(var id in splitId)
            {
                _teamRepo.AddDeveloperToTeamById(int.Parse(id), teamId);
                    

            }
            Console.WriteLine("Awesome job adding developers to team! \n");

        }

        private void UpdateTeam()
        {
            Console.Clear();

            List<DevTeam> devTeamList = _teamRepo.GetAllTeams();
            foreach(DevTeam devTeam in devTeamList)
            {
                ShowTeam(devTeam);
            }

            Console.Write("What Team by ID would you like to update? ");
            int answer = int.Parse(Console.ReadLine());

            DevTeam oldTeam = _teamRepo.GetDevTeamById(answer);

            if(oldTeam != null)
            {
                Console.Write("Please enter the new name of the team: ");
                string newName = Console.ReadLine();
                if (newName != "")
                {
                    oldTeam.TeamName = newName;
                }


                bool keepGoing = true;
                while (keepGoing)
                {

                Console.Write("Please select what you would like to edit \n" +
                    "1. Add developers \n" +
                    "2. Remove developers \n" +
                    "3. I am done editing \n");
                string reponse = Console.ReadLine();
                switch (reponse.ToLower())
                {
                    case "1":
                            AddMultipleDevelopersToTeam();
                        //AddDeveloperToTeam();
                        break;
                    case "2":
                            RemoveMultipleDevelopersFromTeam();
                        //RemoveDeveloperFromTeam();
                        break;
                    case "3":
                            keepGoing = false;
                        break;
                }
                }

            }
            else Console.WriteLine("No team found to update");
            AnyKey();
        }


        private void RemoveDeveloperFromTeam()
        {
            Console.Clear();
            List<DevTeam> teamList = _teamRepo.GetAllTeams();
            foreach(DevTeam team in teamList)
            {
                ShowTeam(team);
            }

            Console.Write("Please enter the Team ID you want to focus on: ");
            int teamId = int.Parse(Console.ReadLine());

            Console.Write("Please enter the Developer ID you would like to remove: ");
            int devId = int.Parse(Console.ReadLine());

            if (_teamRepo.RemoveDeveloperFromTeamById(devId, teamId))
            {
                Console.WriteLine("Developer successfully deleted!");
            }
            else
            {
                Console.WriteLine("No developer ID or team ID found.");
            }
            AnyKey();
        }


        private void DeleteExistingTeam()
        {
            Console.Clear();

            List<DevTeam> teamList = _teamRepo.GetAllTeams();
            foreach (DevTeam team in teamList)
            {
                ShowTeam(team);
            }

            Console.Write("Enter the team ID number of the team you would like to delete: ");
            int userAnser = int.Parse(Console.ReadLine());

            if (_teamRepo.RemoveTeamByTeamId(userAnser))
            {
                Console.WriteLine("Team successfully deleted!");

            }
            else
            {
                Console.WriteLine("No Team found by that ID");
            }
            AnyKey();
        }


        private void SeedContent()
        {
            Developer bill = new Developer("Bill", "Johnson", 334, true, TeamAssignment.Testing);
            Developer jill = new Developer("Jill", "Long", 223, true, TeamAssignment.FrontEnd);
            Developer crunchy = new Developer("Princess Crunchy", "The Unforgiving", 009, false, TeamAssignment.BackEnd);
            Developer ted = new Developer("Ted", "Danson", 559, false, TeamAssignment.FrontEnd);
            Developer meryl = new Developer("Meryl", "Streep", 444, true, TeamAssignment.Testing);
            Developer jim = new Developer("Jimmy", "Johns", 111, false, TeamAssignment.BackEnd);

            _teamRepo.CreateNewDeveloper(bill);
            _teamRepo.CreateNewDeveloper(jill);
            _teamRepo.CreateNewDeveloper(crunchy);
            _teamRepo.CreateNewDeveloper(ted);
            _teamRepo.CreateNewDeveloper(meryl);
            _teamRepo.CreateNewDeveloper(jim);

            List<Developer> teamA = new List<Developer>();
            List<Developer> teamB = new List<Developer>();

            teamA.Add(bill);
            teamA.Add(jill);
            teamA.Add(crunchy);
            teamB.Add(ted);
            teamB.Add(meryl);
            teamB.Add(jim);

            DevTeam devTeam = new DevTeam(10, teamA, "Team A");
            DevTeam devTeam2 = new DevTeam(20, teamB, "Team B");

            _teamRepo.AddNewTeam(devTeam);
            _teamRepo.AddNewTeam(devTeam2);

        }


        private void ShowTeam(DevTeam team)
        {

            Console.WriteLine($"Team name : {team.TeamName} \n" +
                $"Team ID: {team.TeamID}");
            

            string nameFirst;
            string nameLast;
            int teamId;
            foreach(Developer dev in team.TeamMembers)
            {

                nameFirst = dev.FirstName;
                nameLast = dev.LastName;
                teamId = dev.ID;

                Console.WriteLine($"Team memebers: {nameFirst} {nameLast} ID: {teamId}");
            }
            Console.WriteLine();

        }

        private void ShowDevs(Developer developer)
        {
            Console.WriteLine($"Developer's Name : {developer.FirstName} {developer.LastName} \n" +
                $"Developer ID number: {developer.ID} \n" +
                $"Do they have access to Pluralsight: {(developer.HasAccessToPluralsight ? "Yes" : "No")}\n" +
                $"Developer team: {developer.Assignment}\n");
        }

        private void AnyKey()
        {
            Console.WriteLine("Press any key to contniue...");
            Console.ReadKey();

        }

    }
}
