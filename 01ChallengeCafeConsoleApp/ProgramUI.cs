using _01ChallengeCafeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01ChallengeCafeConsoleApp
{
    public class ProgramUI
    {
        private readonly CafeMenuRepo _menuItems = new CafeMenuRepo();
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Cafe! \n" +
                    "1. Add New Item to the Menu \n" +
                    "2. Delete an Item from the Menu \n" +
                    "3. View Entire Menu \n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddMealToMenu();
                        break;
                    case "2":
                        DeleteFromMenu();
                        break;
                    case "3":
                        ViewMenu();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid response between 1 and 4 to continue \n" +
                            "Press any key to continue.....");
                        Console.ReadKey();
                        break;

                }
            }
        }
        private void AddMealToMenu()
        {
            Console.Clear();
            CafeMenu item = new CafeMenu();
            Console.WriteLine("You have a new item to add to the menu! Wonderful!!");
            Console.WriteLine("Please enter the number of this menu item:");
            item.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the name of this menu item:");
            item.MealName = Console.ReadLine();
            Console.WriteLine("Please enter the price of this menu item:");
            item.MealPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the description of this menu item:");
            item.MealDescription = Console.ReadLine();
            //create another option to add ingredients to existing men item
            //Console.WriteLine("Please enter the ingredients of this menu item:");
            //item.MealIngredients = Console.ReadLine();

            _menuItems.AddMealToMenu(item);
            Console.WriteLine("Press any key to continue......");
            Console.ReadKey();
        }
        private void ViewMenu()
        {
            Console.Clear();
            List<CafeMenu> menuItems = _menuItems.ViewEntireMenu();
            foreach (CafeMenu menu in menuItems)
            {
                Console.WriteLine($"Menu #: {menu.MealNumber}\n" +
                                $"Meal name: {menu.MealName}\n" +
                                $"Meal price: {menu.MealPrice}\n" +
                                $"Meal description: {menu.MealDescription}\n" +
                                $"Meal ingredients: {menu.MealIngredients}\n");
            }
            Console.WriteLine("Press any key to continue......");
            Console.ReadKey();
        }
        private void DeleteFromMenu()
        {
            ViewMenu();
            Console.WriteLine("Which item number would you like to remove?");
            int itemToDelete = int.Parse(Console.ReadLine());
            Console.WriteLine($"Do you want to delete menu item number {itemToDelete}? Y/N");
            string response = Console.ReadLine();
            if (response.ToUpper() == "Y")
            {
                CafeMenu menuItem = _menuItems.GetMenuItemByID(itemToDelete);
                if (menuItem != null)
                {
                    _menuItems.DeleteItemFromMenu(menuItem);
                    Console.WriteLine($"{menuItem.MealName} was successfully removed.");
                }
                else
                {
                    Console.WriteLine("I'm sorry! I can't find that menu item.");
                }
            }
            else
            {
                RunMenu();
            }

            Console.WriteLine("Press any key to continue........");
            Console.ReadKey();

        }
    }
}
