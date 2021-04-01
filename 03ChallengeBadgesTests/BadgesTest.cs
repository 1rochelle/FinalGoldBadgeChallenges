using _03ChallengeBadgesLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03ChallengeBadgesTests
{
    [TestClass]
    public class BadgesTest
    {
        //Test Create method
        [TestMethod]
        public void AddBadgeToDirectory_ShouldAddBadge()
        {
            Badges addBadge = new Badges();
            BadgesRepo _addBadge = new BadgesRepo();
            bool addResult = _addBadge.AddBadgeToDictionary(addBadge);
            Assert.IsTrue(addResult);
        }
        //Test Read method
        [TestMethod]
        public void GetAllBadges_ShouldReturnAll()
        {
            Badges allBadges = new Badges();
            BadgesRepo allBadgesRepo = new BadgesRepo();
            allBadgesRepo.AddBadgeToDictionary(allBadges);
        }
        //Some private fields
        private BadgesRepo _repo;
        private Badges _newBadgeOne;
        private Badges _newBadgeTwo;
        //Some seed content to test methods
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgesRepo();
            _newBadgeOne = new Badges(322, new List<string>{ "A3", "B2", "N8" });
            _newBadgeTwo = new Badges(12, new List<string>{ "A4", "A3", "B1" });

        }
        //Test Update method
        [TestMethod]
        public void UpdateExistingBadge_ShouldUpdateBadge()
        {
            Badges updateBadge = new Badges();
            BadgesRepo allBadgesRepo = new BadgesRepo();
            _repo.AddBadgeToDictionary(updateBadge);
            //Dictionary<int, string> getTheBadges = _repo.GetAllBadges();
            //Badges getBadgeByID = _repo.UpdateExistingBadge();
            //Assert.AreEqual(updateBadge, getBadgeByID);


        }
      
    }
}
