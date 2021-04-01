using _01ChallengeCafeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01ChallengeCafeTests
{
    [TestClass]
    public class CafeUnitTest
    {
        //Test the Create method
        [TestMethod]
        public void AddMealToMenu_ShouldAdd()
        {
            CafeMenuRepo _cafeRepo = new CafeMenuRepo();
            CafeMenu content = new CafeMenu(1, "Spaghetti", 14.99, "pasta and sauce", "tomato, garlic, pasta");
            bool wasAdded = _cafeRepo.AddMealToMenu(content);
            Assert.IsTrue(wasAdded);
        }
        //Test the Read method
        [TestMethod]
        public void ViewEntireMenu_ShouldShowAll()
        {
            CafeMenu content = new CafeMenu();
            CafeMenuRepo repo = new CafeMenuRepo();
            repo.AddMealToMenu(content);
            List<CafeMenu> allMenuItems = repo.ViewEntireMenu();

            bool directoryHasContent = allMenuItems.Contains(content);
            Assert.IsTrue(directoryHasContent);
        }
        //Private fields
        private CafeMenuRepo _repo;
        private CafeMenu _menuItemOne;
        private CafeMenu _menuItemTwo;

        //Arrange Part
        [TestInitialize]
        public void Arrange()
        {
            //Creating seed content
            _repo = new CafeMenuRepo();
            _menuItemOne = new CafeMenu(5, "Pizza", 7.99, "cheese, sauce, & Heaven", "pizza dough, cheese, pepperoni");
            _menuItemTwo = new CafeMenu(3, "Cereal", 2.99, "muesli and skim milk", "rolled oats, dried fruit, sugar, skim milk");
            //Adding seed content to my list (here in unit test)
            _repo.AddMealToMenu(_menuItemOne);
            _repo.AddMealToMenu(_menuItemTwo);
        }
        //Test the Delete method
        [TestMethod]
        public void DeleteItemFromMenu_ShouldDelete()
        {
            CafeMenu item = _repo.GetMenuItemByID(5);
            bool removeItem = _repo.DeleteItemFromMenu(item);
            Assert.IsTrue(removeItem);
        }
    }
}
