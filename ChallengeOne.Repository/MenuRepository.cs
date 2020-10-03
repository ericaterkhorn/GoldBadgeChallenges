using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Repository
{
    public class MenuRepository
    {
        private List<Menu> _listMenu = new List<Menu>();

        //Create
        public void AddItemsToMenu(Menu items)
        {
            _listMenu.Add(items);
        } 

        //Read
        public List<Menu> GetMenuList()
        {
            return _listMenu;
        }

        //Update

        //Delete
        public bool RemoveItemsFromListByName(string mealName)
        {
            Menu items = GetMealByName(mealName);

            if (items == null)
            {
                return false;
            }

            int initialCount = _listMenu.Count;
            _listMenu.Remove(items);

            if(initialCount > _listMenu.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveItemsFromListByIngredients(string mealIngredients)
        {
            Menu items = GetMealByIngredients(mealIngredients);

            if (items == null)
            {
                return false;
            }

            int initialCount = _listMenu.Count;
            _listMenu.Remove(items);

            if (initialCount > _listMenu.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Methods
        public Menu GetMealByNumber(int mealNumber)
        {
            foreach (Menu items in _listMenu)
            {
                if (items.MealNumber == mealNumber)
                {
                    return items;
                }
            }

            return null;
        }

        public Menu GetMealByName(string mealName)
        {
            foreach (Menu items in _listMenu)
            {
                if (items.MealName.ToLower() == mealName.ToLower())
                {
                    return items;
                }
            }

            return null;
        }

        public Menu GetMealByIngredients(string mealIngredients)
        {
            foreach (Menu items in _listMenu)
            {
                if (items.MealIngredients.ToLower() == mealIngredients.ToLower())
                {
                    return items;
                }
            }

            return null;
        }

        public Menu GetMealByPrice(double mealPrice)
        {
            foreach (Menu items in _listMenu)
            {
                if (items.MealPrice == mealPrice)
                {
                    return items;
                }
            }

            return null;
        }

        public Menu GetMealByDescription(string mealDescription)
        {
            foreach (Menu items in _listMenu)
            {
                if (items.MealDescription.ToLower() == mealDescription.ToLower())
                {
                    return items;
                }
            }

            return null;
        }
    }
}
