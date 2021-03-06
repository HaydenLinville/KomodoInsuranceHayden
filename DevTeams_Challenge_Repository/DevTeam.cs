using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DevTeam
    {

        public DevTeam() { }

        public DevTeam(int teamId, List<Developer> teamMember, string name )
        {
            TeamID = teamId;
            TeamMembers = teamMember;
            TeamName = name;

        }
        

        public int TeamID { get; set; }

        public List<Developer> TeamMembers { get; set; } = new List<Developer>();

        public string TeamName { get; set; }
    }
}
