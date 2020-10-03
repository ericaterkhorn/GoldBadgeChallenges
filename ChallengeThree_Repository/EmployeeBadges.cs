using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Repository
{
    public class EmployeeBadge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
        public string EmployeeName { get; set; }

        public EmployeeBadge() { }

        public EmployeeBadge(int badgeID, List<string> doorNames, string employeeName)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
            EmployeeName = employeeName;
        }

        public EmployeeBadge(int badgeID, List<string> doorNames)
        {
            DoorNames = doorNames;
        }
    }
}
