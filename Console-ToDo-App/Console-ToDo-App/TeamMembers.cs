using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ToDo_App
{
    public class TeamMembers
    {
        private Dictionary<int, string> teamMembers;
        public Dictionary<int, string> teamMember { get => teamMembers; set => teamMembers = value; }

        public TeamMembers()
        {
            teamMembers = new Dictionary<int, string>();
        }
    }
}
