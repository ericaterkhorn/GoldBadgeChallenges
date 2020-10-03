using ChallengeThree_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_ConsoleApp
{
    class ProgramUI
    {
        //12 now properties are set, need to save it somewhere, call the repository and add to list
        private EmployeeBadgeRepository _badgeRepo = new EmployeeBadgeRepository();
        public void Run()
        {
            SeedContentList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true; //4
            while (keepRunning)
            {
                //Display options to user - 1
                Console.WriteLine("Hello Security Admin, What would you like to do?");
                Console.WriteLine("Please select a menu option:\n" +
                    "1. Add A New Badge\n" +
                    "2. Update A Badge\n" +
                    "3. View All Badges\n" +
                    "4. Exit");

                //Get user's input - 2
                string input = Console.ReadLine();

                //Evalute their input and act accordingly - 3
                //call methods below in switch cases - 12
                switch (input)
                {
                    case "1":
                        //Add A Badge
                        AddNewBadge();
                        break;
                    case "2":
                        //Edit a badge
                        UpdateABadge();
                        break;
                    case "3":
                        //View all badges
                        ViewAllBadges();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Goodbye."); //9
                        keepRunning = false; //5
                        break;
                    default: //10
                        Console.WriteLine("Please enter a valid selection.");
                        break;
                }

                Console.WriteLine("Please press any key to continue."); //8
                Console.ReadKey();
                Console.Clear();//6
            }
        }

        //methods won't return anything- 11
        //Add a new badge
        public void AddNewBadge()
        {
            Console.Clear();
            EmployeeBadge newEmployeeBadge = new EmployeeBadge();
            //declare it (newemployeebadge) first above so we can call the property below
            //BadgeID
            Console.WriteLine("What is the number on the badge:");
            string idAsString = Console.ReadLine();
            int idAsInt = int.Parse(idAsString);

            //DoorNames
            Console.WriteLine("List a door that it needs access to:");
            string doorNames = Console.ReadLine();

            Console.WriteLine("Any other doors (y/n)?");
            string inputAnswer = Console.ReadLine();

            while (inputAnswer == "y")
            {
                Console.WriteLine("List a door that it needs access to:");
                string inputDoorNames = Console.ReadLine();

                Console.WriteLine("Any other doors (y/n)?");

            }

            if (inputAnswer == "n")
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            //13
            _badgeRepo.AddBadgeToList(newEmployeeBadge);
        }

        //edit a badge
        public void UpdateABadge()
        {
            //Display all badges
            ViewAllBadges();

            //badge number to update
            EmployeeBadge badgeID = new EmployeeBadge();
            Console.WriteLine("Enter the badge ID to update:");
            string badgeIDAsString = Console.ReadLine();
            int badgeIDAsInt = int.Parse(badgeIDAsString);

            //display door access for badge number
            Console.WriteLine($"{badgeID.BadgeID} has access to {badgeID.DoorNames}");
            Console.WriteLine("What would you like to do? \n" +
                "1. Remove a door\n" +
                "2. Add a door");
            string inputAnswer1 = Console.ReadLine();
            switch (inputAnswer1)
            {
                case "1":
                    //remove door
                    Console.WriteLine("Which door would you like to remove?");
                    string doorNames = Console.ReadLine();
                    //how to remove door from badge
                    _badgeRepo.RemoveDoorsFromBadge(badgeID, doorNames);
                    break;

                case "2":
                    //add door
                    Console.WriteLine("Which door would you like to add?");
                    string doorNames1 = Console.ReadLine();
                    //need way to add door to badge
                    _badgeRepo.AddDoorToBadge(badgeID, doorNames1);

                    Console.WriteLine($"Door was removed. {badgeID.BadgeID} has access to {badgeID.DoorNames}.");
                    break;

            }

        }
            //View badges
            public void ViewAllBadges()
            {
                Console.Clear();
            
                Dictionary<int, EmployeeBadge> listOfEmployeeBadges = _badgeRepo.GetBadgeList();

                foreach (KeyValuePair<int, EmployeeBadge> item in listOfEmployeeBadges)
                {
                //get the value and then get the property of the value
                    Console.WriteLine($"Badge ID: {item.Value.BadgeID}\n" +
                    $"DoorAccess: ");
                foreach(string doors in item.Value.DoorNames)
                    {
                    Console.WriteLine(doors);
                    }
                }
            }

            //Seed content list
            private void SeedContentList()
            {
                EmployeeBadge badge1 = new EmployeeBadge(12345, new List<string>() { "A1", "B1", "C1" }, "Erica");
                EmployeeBadge badge2 = new EmployeeBadge(23456, new List<string>() { "B2", "C4", "D5" }, "Mike");
                EmployeeBadge badge3 = new EmployeeBadge(34567, new List<string>() { "C4", "A1", "D5" }, "Reagan");

                _badgeRepo.AddBadgeToList(badge1);
                _badgeRepo.AddBadgeToList(badge2);
                _badgeRepo.AddBadgeToList(badge3);
            }


    }
}
