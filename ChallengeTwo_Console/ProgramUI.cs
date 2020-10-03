using ChallengeTwo_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Console
{
    class ProgramUI

    {
        private ClaimsRepository _claimsRepo = new ClaimsRepository(); //when we add something, it creates repo and repo continues to exist

        public void Run()
        {
            SeedItemList();
            Menu();
        }

        private void Menu()
        {
            //#2 While loop to run until specific condition is met
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display options #1
                Console.WriteLine("Select a menu option: \n" +
                    "1. View all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit \n");

                //Get input
                string input = Console.ReadLine();

                //Evaluate input and act accordingly
                //#8 call the methods
                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        //add claim to list
                        break;
                    case "2":
                        //First you need to get next claim
                        //Second you need to display this claim *method to display claim any time you need it
                        ViewNextClaim();
                        //view next claim
                        break;
                    case "3":
                        AddClaimToList();
                        //add claim list
                        break;
                    case "4":
                        //exit
                        Console.WriteLine("Goodbye!"); //#6
                        keepRunning = false;  //#3
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue."); //#5
                Console.ReadKey();

                Console.Clear(); //#4 
            }
        }
        //#8 - inside class, outside other methods; write methods for display options
        //Add claim to list
        //methods void - get input but don't have to return anything
        private void AddClaimToList()
        {
            //#11 clear content
            Console.Clear();
            Claims newClaim = new Claims();

            //Claim ID
            Console.WriteLine("Enter the Claim ID:");
            string idAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(idAsString);

            //Type
            Console.WriteLine("Enter the claim type number: \n " +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string claimAsString = Console.ReadLine();
            int claimAsInt = int.Parse(claimAsString);
            newClaim.TypeOfClaim = (ClaimType)claimAsInt;

            //Description
            Console.WriteLine("Enter the incident description.:");
            newClaim.Description = Console.ReadLine();

            //Amount
            Console.WriteLine("Enter the amount of damage: ");
            string amountAsString = Console.ReadLine();
            newClaim.ClaimAmount = double.Parse(amountAsString);

            //Date of Incident
            Console.WriteLine("Enter the date of the incident (Year/Month/Day): ");
            string incidentDateAsString = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(incidentDateAsString);

            //Date of claim
            Console.WriteLine("Enter the date of the claim (Year/Month/Day)");
            string claimDateAsString = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(claimDateAsString);

            //Is valid
            //Console.WriteLine("Is the claim valid (y/n)? ");
            //string claimValidString = Console.ReadLine().ToLower();

            if ((newClaim.DateOfClaim - newClaim.DateOfIncident).TotalDays <= 30)
            {
                Console.WriteLine("Claim is valid.");
            }
            else
            {
                Console.WriteLine("Claim is not valid");
            }

            //#9 - once all properties are set, need to call repository and add to list - create _claimsRepo (at top of program UI)
            //#10 
            _claimsRepo.AddClaimToList(newClaim);
        }

        //Get Claims List
        private void ViewAllClaims()
        {
            Console.Clear();

            Queue<Claims> listOfClaims = _claimsRepo.GetClaimsList();

            foreach (Claims item in listOfClaims)
            {
                Console.WriteLine($"Claim ID: {item.ClaimID}\n" +
                    $"Claim Type: {item.TypeOfClaim}\n" +
                    $"Description: {item.Description}\n" +
                    $"Claim Amount: {item.ClaimAmount}\n" +
                    $"Date of Incident: {item.DateOfIncident}\n" +
                    $"Date of Claim: {item.DateOfClaim}\n" +
                    $"Valid: {item.IsValid}");

            }
        }
        
        //View next claim
        private void ViewNextClaim()

            //see all items, ask if agent wants to deal w/ claim now, when press y, claim pulled to top
            //press n, they go to main menu
        {
            Claims nextClaim = _claimsRepo.NextClaim();

            Console.WriteLine($"Claim ID: {nextClaim.ClaimID}\n" +
                    $"Claim Type: {nextClaim.TypeOfClaim}\n" +
                    $"Description: {nextClaim.Description}\n" +
                    $"Claim Amount: {nextClaim.ClaimAmount}\n" +
                    $"Date of Incident: {nextClaim.DateOfIncident}\n" +
                    $"Date of Claim: {nextClaim.DateOfClaim}\n" +
                    $"Valid: {nextClaim.IsValid}");

            Console.WriteLine("Do you want to deal with this claim now (enter y/n)? ");
            string inputAnswer = Console.ReadLine().ToLower();
            if (inputAnswer == "y")
            {
                _claimsRepo.RemoveClaim(nextClaim.ClaimID);
            }
           
        }

        //7 can't bring in content until add reference = challenge2 repo

        //9  - method to seed database to keep running so don't have to recreate each time
        //Seed method
        private void SeedItemList()
        {
            //Declare datetime variables and convert to datetime also
            
            DateTime dateOfIncident = new DateTime(2020, 01, 21);
            DateTime dateOfClaim = new DateTime(2020, 02, 01);

            Claims claimOne = new Claims(1, ClaimType.Car, "Accident on 69", 399.99, dateOfIncident, dateOfClaim, true);
            Claims claimTwo = new Claims(2, ClaimType.Home, "Basement flooded", 1399.99, dateOfIncident, dateOfClaim, true);
            Claims claimThree = new Claims(3, ClaimType.Theft, "Theft from car", 500.00, dateOfIncident, dateOfClaim, false);

            _claimsRepo.AddClaimToList(claimOne);
            _claimsRepo.AddClaimToList(claimTwo);
            _claimsRepo.AddClaimToList(claimThree);
        }

    }
}
