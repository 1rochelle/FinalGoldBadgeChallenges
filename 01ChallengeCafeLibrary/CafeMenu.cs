using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01ChallengeCafeLibrary
{
    public class CafeMenu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public double MealPrice { get; set; }
        public string MealDescription { get; set; }
        public string MealIngredients { get; set; }

        public CafeMenu()
        {

        }
        public CafeMenu(int mealNumber, string mealName, double mealPrice, string mealDescription, string mealIngredients)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealPrice = mealPrice;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
        }
    }
}
