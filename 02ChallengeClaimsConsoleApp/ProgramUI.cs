using _02ChallengeClaimsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02ChallengeClaimsConsoleApp
{
    class ProgramUI
    {
        private readonly ClaimsRepo _claimsRepo = new ClaimsRepo();
        public void Run()
        {
            SeedClaimsQueue();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Komodo Insurance Claims: \n" +
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit application");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response between 1 and 4 \n" +
                            "Press any key to continue........");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claims> queueOfClaims = _claimsRepo.GetEntireQueue();
            foreach (Claims individualClaim in queueOfClaims)
            {
                DisplayQueue();
            }
        }
        private void DisplayQueue()
        {
            Console.Clear();
            Queue<Claims> queueOfClaims = _claimsRepo.GetEntireQueue();
            foreach (Claims eachClaim in queueOfClaims)
            {
                //going to need some work to look like the instructions****************
                Console.WriteLine($"Claim ID: {eachClaim.ClaimID}\n" +
                                    $"Claim Type: {eachClaim.ClaimType}\n" +
                                    $"Description: {eachClaim.Description}\n" +
                                    $"Claim Amount: {eachClaim.ClaimAmount}\n" +
                                    $"Date of Incident: {eachClaim.DateOfIncident}\n" +
                                    $"Date of Claim: {eachClaim.DateOfClaim}\n");
            }
            Console.WriteLine("Press any key to continue......");
            Console.ReadKey();
        }
        private void SeedClaimsQueue()
        {
            Claims stolenYappyDog = new Claims(1, ClaimType.Theft, "dog stolen from backyard", 1000.00, new DateTime(2021, 1, 21), new DateTime(2021, 2, 3));
            Claims beaterGotBeat = new Claims(2, ClaimType.Car, "beater car ran over nail", 500.00, new DateTime(2020, 3, 5), new DateTime(2020, 7, 1));
            Claims wallpaperExplosion = new Claims(3, ClaimType.Home, "wallpaper, glue, walls... there was an explosion", 5000.00, new DateTime(1 / 27 / 21), new DateTime(2 / 3 / 21));

            _claimsRepo.AddClaimToQueue(stolenYappyDog);
            _claimsRepo.AddClaimToQueue(beaterGotBeat);
            _claimsRepo.AddClaimToQueue(wallpaperExplosion);

        }
        private void TakeCareOfNextClaim()
        {
            Claims nextClaim = _claimsRepo.DisplayNextClaim();
            if (nextClaim != null)
            {
                Console.WriteLine($"Claim ID: {nextClaim.ClaimID}\n" +
                     $"Claim Type: {nextClaim.ClaimType}\n" +
                     $"Description: {nextClaim.Description}\n" +
                     $"Claim Amount: {nextClaim.ClaimAmount}\n" +
                     $"Date of Incident: {nextClaim.DateOfIncident}\n" +
                     $"Date of Claim: {nextClaim.DateOfClaim}\n");
                Console.WriteLine("Do you want to deal with this claim now? (Please type Y/N).");
                string response = Console.ReadLine();
                if (response.ToUpper() == "Y")
                {
                    _claimsRepo.DeleteClaim();
                    Console.WriteLine("Claim was successfully removed.");
                }
                else
                {
                    Console.WriteLine("You'll deal with this claim later. \n" +
                        "Press any key to continue......");
                    Console.ReadKey();
                    RunMenu();
                }
            }
        }
        private void AddNewClaim()
        {
            Console.Clear();
            Claims item = new Claims();
            Console.WriteLine("Enter the information for this new claim below:");
            Console.WriteLine("Please select which claim type you're entering. Select 1, 2, or 3:\n" +
                "1. Car \n" +
                "2. Home \n" +
                "3. Theft");
            int claimType = int.Parse(Console.ReadLine());
            item.ClaimType = (ClaimType)claimType;
            Console.WriteLine("Please provide a description of the events surrounding this claim:");
            item.Description = Console.ReadLine();
            Console.WriteLine("Please enter the monetary amount for this claim:");
            item.ClaimAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the date that this event occurred:");
            item.DateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the date that this claim was filed:");
            item.DateOfClaim = DateTime.Parse(Console.ReadLine());
            _claimsRepo.AddClaimToQueue(item);
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
        }
    }
}
