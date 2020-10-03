using ChallengeOne_Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Console
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            SeedList();
            Menu();
        }  
        
        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

            
            //Display user options
            Console.WriteLine("Select a menu option: \n" +
                "1. Add Item to Menu \n" +
                "2. Get Menu List\n" +
                "3. Remove Items from Menu\n" +
                "4. Exit\n");

            //Get the user input
            string input = Console.ReadLine();

            //Evaluate the user input and act accordingly
            switch (input)
            {
                case "1":
                    // Add Item to Menu
                    AddItemsToMenu();
                    break;
                case "2":
                    //Get Menu List
                    GetMenuList();
                    break;
                case "3":
                    //Remove Items from menu
                    RemoveItemsFromMenu();
                    break;
                case "4":
                    //Exit
                     Console.WriteLine("Please come back!");
                    keepRunning = false;
                    break;
                default:
                    Console.Write("Please enter a valid number.");
                    break;
            }
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //void b/c they do something - doesn't return anything
        //Add items to menu
        private void AddItemsToMenu()
        {
            Console.Clear();
            Menu newItems = new Menu();
            //Meal name
            Console.WriteLine("Enter the meal name: ");
            newItems.MealName = Console.ReadLine();

            //Meal number
            Console.WriteLine("Enter the meal number (1, 2, 3): ");
            string mealNumbersAsString = Console.ReadLine();
            newItems.MealNumber = int.Parse(mealNumbersAsString);

            //Meal description
            Console.WriteLine("Enter the meal description: ");
            newItems.MealDescription = Console.ReadLine();

            //Meal ingredients
            Console.WriteLine("Enter the ingredients (sandwich, salad, fries, drink): ");
            newItems.MealIngredients = Console.ReadLine();

            //Meal price
            Console.WriteLine("Enter the price (8.99, 9.99, 10.99): ");
            string mealPriceAsString = Console.ReadLine();
            newItems.MealPrice = double.Parse(mealPriceAsString);

            _menuRepo.AddItemsToMenu(newItems);

        }

        //Get menu list
        private void GetMenuList()
        {
            Console.Clear();

            List<Menu> listOfMenuItems = _menuRepo.GetMenuList();

            foreach(Menu item in listOfMenuItems)
            {
                Console.WriteLine($"MealName: {item.MealName}, MealNumber: {item.MealNumber}, MealDescription: {item.MealDescription}, MealIngred: {item.MealIngredients}, MealPrice: {item.MealPrice}");
            }

        }
        //Remove items from menu
        private void RemoveItemsFromMenu()
        {
            GetMenuList();
            // Get the item to delete
            Console.WriteLine("Enter the item to remove:");

            string input = Console.ReadLine();


            //Call delete method
            bool wasDeleted = _menuRepo.RemoveItemsFromListByName(input);

            //If deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("The item was successfully removed.");
            }
            //If not, state it can't be deleted
            else
            {
                Console.WriteLine("The item could not be removed. ");
            }

        }

        //Seed method
        private void SeedList()
        {
            Menu mealOne = new Menu(1, "Healthy", "Your healthier choice", "Sandwich, Salad, Drink", 8.99);
            Menu mealTwo = new Menu(2, "Hungry", "It's ok, you need fuel", "Sandwich, Fries, Milkshake", 10.99);
            Menu mealThree = new Menu(3, "In between", "Some good, some bad.", "Salad, Fries, Drink/Milkshake", 9.99);

            _menuRepo.AddItemsToMenu(mealOne);
            _menuRepo.AddItemsToMenu(mealTwo);
            _menuRepo.AddItemsToMenu(mealThree);
        }

        
    }
    
}
