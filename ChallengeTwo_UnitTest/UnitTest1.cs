using System;
using ChallengeTwo_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeTwo_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        ClaimsRepository item = new ClaimsRepository();

        [TestMethod]
        public void AddClaimToListTest()
        {
            //Arrange

            DateTime dateofIncident = new DateTime(2020, 01, 01);
            DateTime dateOfClaim = new DateTime(2020, 02, 01);

            Claims claimItem = new Claims(1, ClaimType.Car, "Accident", 230.00, dateofIncident, dateOfClaim, true);

            //Act
            item.AddClaimToList(claimItem);

            //Assert
            int expected = 1;
            int actual = item.GetClaimsList().Count;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void ViewAllClaimsTest()
        {
            //Arrange

            DateTime dateofIncident = new DateTime(2020, 01, 01);
            DateTime dateOfClaim = new DateTime(2020, 02, 01);

            Claims claimItem = new Claims(1, ClaimType.Car, "Accident", 230.00, dateofIncident, dateOfClaim, true);
            Claims claimItem1 = new Claims(2, ClaimType.Home, "Theft", 300.00, dateofIncident, dateOfClaim, true);
            Claims claimItem2 = new Claims(3, ClaimType.Theft, "ID", 500.00, dateofIncident, dateOfClaim, false);

            item.AddClaimToList(claimItem);
            item.AddClaimToList(claimItem1);
            item.AddClaimToList(claimItem2);

            //Act
            item.GetClaimsList();

            //Assert
            int expected = 3;
            int actual = item.GetClaimsList().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveClaim()
        {
            //Arrange
            DateTime dateofIncident = new DateTime(2020, 01, 01);
            DateTime dateOfClaim = new DateTime(2020, 02, 01);

            Claims claimItem = new Claims(1, ClaimType.Car, "Accident", 230.00, dateofIncident, dateOfClaim, true);

            item.AddClaimToList(claimItem);
            //Act
            item.RemoveClaim(1);

            //Assert
            int expected = 0;
            int actual = item.GetClaimsList().Count;
            Assert.AreEqual(expected, actual);
        }

    }
    
}
