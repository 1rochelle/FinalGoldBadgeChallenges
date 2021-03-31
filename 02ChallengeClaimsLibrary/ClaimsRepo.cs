using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02ChallengeClaimsLibrary
{
    public class ClaimsRepo
    {
        protected readonly Queue<Claims> _currentClaims = new Queue<Claims>();

        //Create new claim
        public bool AddClaimToQueue(Claims newClaim)
        {
            int startingCount = _currentClaims.Count;
            _currentClaims.Enqueue(newClaim);
            bool wasAdded = (_currentClaims.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read all claims
        public Queue<Claims> GetEntireQueue()
        {
            return _currentClaims;
        }
        //helper method to display next claim on list
        public Claims DisplayNextClaim()
        {
            //access location
            return _currentClaims.Peek();
        }
        //Update, no update needed
        //Delete a claim from the list
        public void DeleteClaim()
        {
            _currentClaims.Dequeue();
        }
    }
}
