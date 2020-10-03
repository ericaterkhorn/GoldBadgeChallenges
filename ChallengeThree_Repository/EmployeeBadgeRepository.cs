using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Repository
{
    public class EmployeeBadgeRepository
    {
        //Dicationary collecton of key value pairs
        //key = badgeID
        //value = Badge
        private Dictionary<int, EmployeeBadge> _badgeDictionary = new Dictionary<int, EmployeeBadge>();

        //Create
        public void AddBadgeToList(EmployeeBadge newEmployeeBadge)
        {
            //EmployeeBadge newEmployeeBadge = new EmployeeBadge(badgeID, doorNames, employeeName);
                                 //key                    //value
            _badgeDictionary.Add(newEmployeeBadge.BadgeID, newEmployeeBadge); 
        }

        //Read - get badge list w/ all numbers and door access 
        public Dictionary<int, EmployeeBadge> GetBadgeList()
        {
            return _badgeDictionary;
        }

        //Update doors on existing badge
        
        public bool AddDoorToBadge(EmployeeBadge employeeBadge, string doorWeWant)
        {
            bool doorAdded;

            if(_badgeDictionary.Count < 0)
            {
                string door = doorWeWant;
                employeeBadge.DoorNames.Add(door);
                doorAdded = true;
            }
            else
            {
                doorAdded = false;
            }
            return doorAdded;
        }

        //Delete all doors from existing badge //verify if they are removed
        public bool RemoveDoorsFromBadge(EmployeeBadge employeeBadge, string doorWeWant)
        {
            bool doorRemoved;
            
            if(_badgeDictionary.Count > 0)
            {
                string door = doorWeWant;
                employeeBadge.DoorNames.Remove(door);
                doorRemoved = true;
            }
                      
            else
            {
                doorRemoved = false;
            }

            return doorRemoved;
        }

        //Helper methods
        public EmployeeBadge GetBadgeByID(int badgeIDInput)// get instance of employee badge id - need two values here
        {
            EmployeeBadge newEmployeeBadge = new EmployeeBadge();
        
            foreach (var employeeBadge in _badgeDictionary)
            {
                if (employeeBadge.Key == badgeIDInput)
                {
                   return newEmployeeBadge;
                   //Console.WriteLine($"Badge: {employeeBadge.Value} {employeeBadge.Key}");
                }
                else
                {
                    Console.WriteLine("Sorry - no badge found.");
                }
            }
            return null;
        }

    }

}
