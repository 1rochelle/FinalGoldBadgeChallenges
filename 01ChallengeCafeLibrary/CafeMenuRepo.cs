using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01ChallengeCafeLibrary
{
    public class CafeMenuRepo
    {
        public List<CafeMenu> MenuItems = new List<CafeMenu>();

        //Create
        public bool AddMealToMenu(CafeMenu newMenuItem)
        {
            int startingCount = MenuItems.Count;
            MenuItems.Add(newMenuItem);
            bool wasAdded = (MenuItems.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<CafeMenu> ViewEntireMenu()
        {
            return MenuItems;
        }

        public CafeMenu GetMenuItemByID(int mealNumber)
        {
            foreach (CafeMenu content in MenuItems)
            {
                if (content.MealNumber == mealNumber)
                {
                    return content;
                }
            }
            return null;
        }

        //(no update functionality for this challenge)
        //Delete
        public bool DeleteItemFromMenu(CafeMenu existingItem)
        {
            bool deleteItem = MenuItems.Remove(existingItem);
            return deleteItem;
        }
    }
}
