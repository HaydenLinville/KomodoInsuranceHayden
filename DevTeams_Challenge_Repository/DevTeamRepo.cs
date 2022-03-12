using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DevTeamRepo
    {

        private List<DevTeam> _devTeamDirectory = new List<DevTeam>();
        private readonly DeveloperRepo _developers = new DeveloperRepo();


        // need to figure out create new dev team
        // add developer to team
        // update team

        //c

        public bool AddNewTeam(DevTeam team)
        {
            int startingCount = _devTeamDirectory.Count();
            _devTeamDirectory.Add(team);
            bool wasAdded = (_devTeamDirectory.Count() > startingCount) ? true : false;
            return wasAdded;
        }

        public bool AddDeveloperToTeamById(int devId, int teamId)
        {
            
            Developer dev = _developers.GetDevById(devId);
            DevTeam dTeam = GetDevTeamById(teamId);
            if(dev != default && dTeam != default)
            {

            int startingCount = dTeam.TeamMembers.Count();
            dTeam.TeamMembers.Add(dev);
            return dTeam.TeamMembers.Count > startingCount ? true : false;

            }
            return false;
        }
        //r
        public List<DevTeam> GetAllTeams()
        {
            return _devTeamDirectory;
        }



        public DevTeam GetDevTeamById(int teamId)
        {
            return _devTeamDirectory.Where(d => d.TeamID == teamId).SingleOrDefault();
        }

        //u

        public bool UpdateExistingTeam(int teamId, DevTeam newTeam)
        {
            DevTeam oldTeam = GetDevTeamById(teamId);
            if(oldTeam != null)
            {
                oldTeam.TeamName = newTeam.TeamName;
                oldTeam.TeamMembers = newTeam.TeamMembers;
                oldTeam.TeamID = newTeam.TeamID;
                return true;
            }
            else
            {
                return false;
            }
        }



        //d
        //Jacob code take a look 
        public bool RemoveDeveloperFromTeamById(int devId, int teamId)
        {
            DevTeam dTeam = GetDevTeamById(teamId);
            Developer dev = dTeam.TeamMembers.Where(d => d.ID == devId).SingleOrDefault();
            if (dev != default)
            {
                return dTeam.TeamMembers.Remove(dev);
            }
            else
                return false; 
        }

        public bool RemoveTeamByTeamId(int teamID)
        {

            var team = GetDevTeamById(teamID);
            if (team != null)
            {
                bool deleteTeam = _devTeamDirectory.Remove(team);
                return deleteTeam;
            }
            else
                return false;

        }


        



    }
}
