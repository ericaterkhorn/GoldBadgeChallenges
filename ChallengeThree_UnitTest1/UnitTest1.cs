using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using ChallengeThree_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeThree_UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        EmployeeBadgeRepository item = new EmployeeBadgeRepository();

        [TestMethod]
        public void AddBadgeToList()
        //Arrange
        {
        List<string> doorNames = new List<string>();
        EmployeeBadge badge = new EmployeeBadge(12345, doorNames, "Erica");

         //Act
        item.AddBadgeToList(badge);

         //Assert
         int expected = 1;
         int actual = item.GetBadgeList().Count;
         Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ViewAllBadges()
        {
            //Arrange
            List<string> doorNames = new List<string>();
            EmployeeBadge badge = new EmployeeBadge(12345, doorNames, "Erica");

            item.AddBadgeToList(badge);
            
            //Act
            item.GetBadgeList();

            //Assert
            int expected = 1;
            int actual = item.GetBadgeList().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateBadges()
        {
            //Arrange
            List<string> doorNames = new List<string>();
            EmployeeBadge badge = new EmployeeBadge(12345, doorNames, "Erica");

            item.AddBadgeToList(badge);

            //Act
            

            //Assert
            

        }
    }
}
