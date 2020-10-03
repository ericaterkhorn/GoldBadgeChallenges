using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Repository
{
    public class ClaimsRepository //make public
    {
        //#1 class level variable - create field 

        public Queue<Claims> _listofClaims = new Queue<Claims>(); 

        //Queue vs list - It represents a first-in, first out collection of object. It is used when you need a first-in, first-out access of items. When you add an item in the list, it is called enqueue, and when you remove an item, it is called deque.
        
        // #2 Create - add from outside and add to list, don't need to return anything
        public void AddClaimToList(Claims claim)
        {
            _listofClaims.Enqueue(claim);
        }

        //Read #3 build so accessible outside class; no parameters needed b/c single responsibility is just to get the one list
        public Queue<Claims> GetClaimsList()
        {
            return _listofClaims;
        }

        public Claims ViewClaim() 
        {
            return _listofClaims.Peek();
            
        }

        //Update
        public bool UpdateClaims(int originalClaimID, Claims newClaims)
        {
            //Find content
            Claims oldClaims = GetClaimByID(originalClaimID);
            
            //Update content
            if (oldClaims != null)
            {
                oldClaims.ClaimID = newClaims.ClaimID;
                oldClaims.TypeOfClaim = newClaims.TypeOfClaim;
                oldClaims.Description = newClaims.Description;
                oldClaims.ClaimAmount = newClaims.ClaimAmount;
                oldClaims.DateOfIncident = newClaims.DateOfIncident;
                oldClaims.DateOfClaim = newClaims.DateOfClaim;
                oldClaims.IsValid = newClaims.IsValid;

                return true;
            }
            else
            {
                return false;
            }   
        }

        //Delete
        public bool RemoveClaim(int id)
        {
            int initialCount = _listofClaims.Count;
            _listofClaims.Dequeue();

            if(initialCount > _listofClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
         
        }

        //#4 Helper methods  
        public Claims NextClaim()
        {
            if (_listofClaims.Count > 0)
            {
                return _listofClaims.First();
            }
            else
            {
                return null;
            }
        }

        public Claims GetClaimByID(int id)
        {
            foreach (Claims claim in _listofClaims) 
            {
                if(claim.ClaimID == id)  //claim class is a reference type to claim object
                {
                    return claim;
                }
            }

            return null;
        }

        public Claims GetClaimByType (ClaimType type)
        {
            foreach (Claims claim in _listofClaims)
            {
                if(claim.TypeOfClaim == type)
                {
                    return claim;
                }
            }

            return null;
        }


    }
}
