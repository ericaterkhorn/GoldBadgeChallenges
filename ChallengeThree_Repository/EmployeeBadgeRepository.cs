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
        Dictionary<int, EmployeeBadge> badgeDictionary = new Dictionary<int, EmployeeBadge>();

        List<EmployeeBadge> _listofEmployeeBadges = new List<EmployeeBadge>();

        //Create
        public void AddBadgeToList(EmployeeBadge newEmployeeBadge)
        {
            //EmployeeBadge newEmployeeBadge = new EmployeeBadge(badgeID, doorNames, employeeName);
                                 //key                    //value
            badgeDictionary.Add(newEmployeeBadge.BadgeID, newEmployeeBadge); 
        }

        //Read - get badge list w/ all numbers and door access 
        public List<EmployeeBadge> GetBadgeList()
        {
            return _listofEmployeeBadges;
        }


        //Update doors on existing badge
        public bool UpdateDoorsOnBadge(int badgeID, EmployeeBadge newEmployeeBadge)
        {
            //Find the content
            EmployeeBadge oldBadge = GetBadgeByID(badgeID);

            //Update the content
            if(oldBadge != null)
            {
                oldBadge.DoorNames = newEmployeeBadge.DoorNames;
                return true;
            }
            else
            {
                return false;
            }

        }

        //Delete all doors from existing badge //verify if they are removed
        public bool RemoveDoorsFromBadge(EmployeeBadge employeeBadge, string doorWeWant)
        {
            List<string> DoorNames = employeeBadge.DoorNames;

            bool doorRemoved;

           // int initialCount = badgeDictionary.Count;
            
            if(badgeDictionary.Count > 0)
            {
                string door = doorWeWant;
                DoorNames.Remove(door);
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
        
            foreach (var employeeBadge in badgeDictionary)
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
