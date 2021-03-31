using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02ChallengeClaimsLibrary
{
    public enum ClaimType { Car = 1, Home, Theft }
    public class Claims
    {
        public int ClaimID { get; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan interval = DateOfIncident - DateOfClaim;
                int convertedInterval = Convert.ToInt32(interval.TotalDays);
                if (convertedInterval <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Claims()
        {

        }
        public Claims(int claimID, ClaimType claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
