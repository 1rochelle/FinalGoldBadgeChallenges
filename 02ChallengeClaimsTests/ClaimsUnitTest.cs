using _02ChallengeClaimsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02ChallengeClaimsTests
{
    [TestClass]
    public class ClaimsUnitTest
    {
        //Testing the Create method
        [TestMethod]
        public void AddClaimToQueue_ShouldAddClaim()
        {
            Claims newClaim = new Claims(1, ClaimType.Car, "in auto accident", 32.01, new DateTime(2009, 2, 1), new DateTime(2009, 9, 5));
            ClaimsRepo _claimsTest = new ClaimsRepo();
            bool addResult = _claimsTest.AddClaimToQueue(newClaim);
            Assert.IsTrue(addResult);
        }
        //Here's some private fields
        private ClaimsRepo _claimsTest;
        private Claims _newClaimOne;
        private Claims _newClaimTwo;

        //Testing the Read method
        [TestMethod]
        public void GetEntireQueue_ShouldGetAllClaims()
        {
            Claims content = new Claims();
            ClaimsRepo repo = new ClaimsRepo();
            repo.AddClaimToQueue(content);
            Queue<Claims> allClaims = repo.GetEntireQueue();
            bool directoryHasContent = allClaims.Contains(content);
            Assert.IsTrue(directoryHasContent);
        }
        [TestMethod]
        public void DisplayNextClaim_ShouldDisplayNextClaim()
        {
            Claims content = new Claims();
            ClaimsRepo repo = new ClaimsRepo();
            repo.AddClaimToQueue(content);
            Queue<Claims> getTheClaimsCollection = repo.GetEntireQueue();
            Claims getTheNextClaim = repo.DisplayNextClaim();
            Assert.AreEqual(content, getTheNextClaim);
        }
        [TestMethod]
        public void DeleteClaim_ShouldDeleteClaim()
        {
            Claims content = new Claims();
            ClaimsRepo repo = new ClaimsRepo();
            repo.AddClaimToQueue(content);
            Queue<Claims> getTheClaimsCollection = repo.GetEntireQueue();
            repo.DeleteClaim();
            bool directoryHasContent = getTheClaimsCollection.Contains(content);
            Assert.IsFalse(directoryHasContent);
        }

    }
}
