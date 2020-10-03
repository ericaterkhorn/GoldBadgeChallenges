using ChallengeOne_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeOne_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        MenuRepository items = new MenuRepository();

        [TestMethod]
        public void AddItemToMenuTest()
        {
            //Arrange
            Menu menu = new Menu(1, "name", "descrip", "ingred", 7.99);

            //Act
            items.AddItemsToMenu(menu);

            //Assert
            int expected = 1;
            int actual = items.GetMenuList().Count;
            Assert.AreEqual(expected, actual);
         
        }

        [TestMethod]
        public void GetMenuItem()
        {
            //Arrange
            Menu menu = new Menu(1, "name", "descrip", "ingred", 7.99);
            Menu menu1 = new Menu(2, "name1", "descrip1", "ingred1", 8.99);
            Menu menu2 = new Menu(3, "name2", "descrip2", "ingred2", 9.99);

            items.AddItemsToMenu(menu);
            items.AddItemsToMenu(menu1);
            items.AddItemsToMenu(menu2);
            
            //Act
            items.GetMenuList();

            //Assert
            int expected = 3;
            int actual = items.GetMenuList().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteMenuItem()
        {
            //Arrange
            Menu menu = new Menu(1, "name", "descrip", "ingred", 7.99);

            //Act
            items.RemoveItemsFromListByName("name");

            //Assert
            int expected = 0;
            int actual = items.GetMenuList().Count;
            Assert.AreEqual(expected, actual);
        }
    }  

 }
        

     






   




    

