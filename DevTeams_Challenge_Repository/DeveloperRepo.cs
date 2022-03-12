using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DeveloperRepo
    {
        //This is our Repository class that will hold our directory (which will act as our database) and methods that will directly talk to our directory.

        private readonly List<Developer> _devDirectory = new List<Developer>();


        //added readonly 
        // C

        public bool CreateNewDeveloper(Developer developer)
        {
            int startingCount = _devDirectory.Count();
            _devDirectory.Add(developer);
            bool wasAdded = (_devDirectory.Count() > startingCount) ? true : false;
            return wasAdded;

        }



        // R
        public List<Developer> GetAllDevs()
        {
            return _devDirectory;
        }

        public List<Developer> GetDevsByAssignment(TeamAssignment assignment)
        {
            List<Developer> devList = new List<Developer>();
            foreach(Developer teamMember in _devDirectory)
            {
                if(teamMember.Assignment == assignment)
                {
                    devList.Add(teamMember);
                }
            }
            return devList;
        }
        public Developer GetDevById(int iD)
        {
            foreach(Developer number in _devDirectory)
            {
                
                if(number.ID == iD)
                {
                    return number;
                }
            }
            return null;
        }


        //Jacob's code 
        public List<Developer> GetByTeamAssignment(TeamAssignment assignment)
        {
            return _devDirectory.Where(d => d.Assignment == assignment).ToList();
        }


        // U
        public bool UpdateExistingDeveloper(int oldId, Developer newDeveloper)
        {
            Developer firedDeveloper = GetDevById(oldId);
            if(firedDeveloper != null)
            {
                firedDeveloper.FirstName = newDeveloper.FirstName;
                firedDeveloper.ID = newDeveloper.ID;
                firedDeveloper.LastName = newDeveloper.LastName;
                firedDeveloper.HasAccessToPluralsight = newDeveloper.HasAccessToPluralsight;
                firedDeveloper.Assignment = newDeveloper.Assignment;

                return true;
            }
            else
            {
                return false;
            }
   

        }
        // D
        public bool RemoveDeveloper(Developer firedDeveloper)
        {
            bool deleteDeveloper = _devDirectory.Remove(firedDeveloper);
            return deleteDeveloper;
        }
        

        public bool RemoveDevById(int id)
        {
            var dev = GetDevById(id);
            if (dev != null)
            {
                bool deleteDev = _devDirectory.Remove(dev);
                return deleteDev;
            }
            else
                return false;
        }

        
    }
}
