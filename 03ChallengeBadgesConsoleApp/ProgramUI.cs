using _03ChallengeBadgesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03ChallengeBadgesConsoleApp
{
    class ProgramUI
    {
        private readonly BadgesRepo _badgesRepo = new BadgesRepo();
        public void Run()
        {
            SeedBadges();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Hello Security Admin, What would you like to do? \n" +
                    "1. Add a Badge \n" +
                    "2. Edit a Badge \n" +
                    "3. List all Badges" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        DisplayAllBadges();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response between 1 and 4. \n" +
                            "Press any key to continue......");
                        Console.ReadKey();
                        break;
                }
            }

        }
        private void AddBadge()
        {
            Console.Clear();
            Badges newBadge = new Badges();
            Console.WriteLine("ADD A BADGE \n" +
                "\n");
            Console.WriteLine("What is the number on the badge:");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            Console.WriteLine("List a door that it needs access to:");
            newBadge.DoorNames = Console.ReadLine();
            Console.WriteLine("Any other doors (y/n)?");
            string response = Console.ReadLine();
            while (response.ToLower() == "y")
            {
                Console.WriteLine("List a door that it needs access to:");
                newBadge.DoorNames = Console.ReadLine();
                Console.WriteLine("Any other doors (y/n)?");
                response = Console.ReadLine();
            }
            Console.WriteLine("Looks like you're all done adding this badge. " +
                "\n" +
                "Press any key to return to the Main Menu.");
            Console.ReadKey();
            RunMenu();

        }
        private void UpdateBadge()
        {
            Console.Clear();
            Console.WriteLine("UPDATE A BADGE \n" +
                "\n");
            Console.WriteLine("What is the badge number you'd like to update?");
            //more needed here
            foreach 
            badgeToUpdate.BadgeID = int.Parse(Console.ReadLine());
            Claims badge = _badgesRepo.GetBadgeByID(badgeToUpdate);
            if (badge != null)
            {
                ShowBadge(badge);
            }
            else
            {
                Console.WriteLine("I'm sorry, no such badge exists.");
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }
        private void ShowBadge(Badges individualBadge)
        {
            Console.WriteLine($"Badge #: {individualBadge.BadgeID}\n" +
                                $"Door access to: {individualBadge.DoorNames}");
        }
        private void ShowDoors(Badges individualDoor)
        {
            foreach (var item in individualDoor.DoorNames)
            {
                Console.WriteLine(item);
            }
        }
        private void DisplayAllBadges()
        {
            Console.Clear();
            Console.WriteLine("LIST OF ALL BADGES \n" +
                "\n");
            Dictionary<int, Badges> displayAllBadges = _badgesRepo.GetAllBadges();
            foreach (var individualBadge in displayAllBadges)
            {           
                Console.WriteLine("Key \n" +
                                   $"Badge # {individualBadge.Value.BadgeID}");
                ShowDoors(individualBadge.Value);
            }
            Console.WriteLine("Press any key to continue......");
            Console.ReadKey();
        }
        private void SeedBadges()
        {
            Badges firstSeedBadge = new Badges(4756, new List<string> { "A11", "B1", "A7" });
            Badges secondSeedBadge = new Badges(3, new List<string> { "A2", "A3", "B1" });

            _badgesRepo.AddBadgeToDictionary(firstSeedBadge);
            _badgesRepo.AddBadgeToDictionary(secondSeedBadge);
        }
    }
}