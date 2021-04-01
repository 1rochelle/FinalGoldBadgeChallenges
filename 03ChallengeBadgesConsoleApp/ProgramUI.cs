﻿using _03ChallengeBadgesLibrary;
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

            bool hasFilledRooms = false;
            while (hasFilledRooms == false)
            {
               hasFilledRooms= Setup(newBadge, hasFilledRooms);

               
            }
            bool isSuccessful = _badgesRepo.AddBadgeToDictionary(newBadge);
            if (isSuccessful)
            {
                Console.WriteLine("Looks like you're all done." +
                "\n" +
                "Press any key to return to the Main Menu.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Press any key to return to the Main Menu.");
                Console.ReadKey();
            }
           
        }

        private bool Setup(Badges newBadge,bool hasFilledRooms)
        {
            if (!hasFilledRooms)
            {
                Console.WriteLine("Please add a door number:");
                string userInputDoorNumber = Console.ReadLine();
                newBadge.DoorNames.Add(userInputDoorNumber);

                Console.WriteLine("Any other doors (y/n)?");

                string userInputOtherDoors = Console.ReadLine().ToLower();
                if (userInputOtherDoors == "y")
                {
                   hasFilledRooms= Setup(newBadge, hasFilledRooms);
                    return hasFilledRooms;
                }
               
                else
                {
                    hasFilledRooms = true;
                    return hasFilledRooms;
                }
            }
            return false;
        }
        private void UpdateBadge()
        {
            Console.Clear();
            Console.WriteLine("1. Update badge(FULL UPDATE) \n" +
                "2. Remove a door \n" +
                "3. Add a door \n");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    FullUpdate();
                    break;
                case "2":
                    RemoveDoor();
                    break;
                case "3":
                    AddDoor();
                    break;
                default:
                    RunMenu();
                    break;
            }
        }

        private void AddDoor()
        {
            throw new NotImplementedException();
        }

        private void RemoveDoor()
        {
            Console.Clear();
            //display all my doors and badges with the dictionary
            //ask the user to please select the badge
            //console.clear
            //display single badge and details
            //please input the door # for removal
            //we need to get a method off of the _badgesRepo RemoveDoor
            //signal to user that door was removed
            Console.ReadKey();
        }

        private void FullUpdate()
        {
            Console.WriteLine("UPDATE A BADGE \n" +
                "\n");
            Console.WriteLine("What is the badge number you'd like to update?");
            Badges newBadgeData = new Badges();
            int userInputForOldBadge = int.Parse(Console.ReadLine());

            Badges badge = _badgesRepo.GetBadgeByID(userInputForOldBadge);

            if (badge != null)
            {
                ShowBadge(badge);


                bool hasFilledRooms = false;
                while (hasFilledRooms == false)
                {
                    hasFilledRooms = Setup(newBadgeData, hasFilledRooms);


                }

                bool isSuccessful = _badgesRepo.UpdateExistingBadge(userInputForOldBadge, newBadgeData);
                if (isSuccessful)
                {
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Failure.");
                }
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
            Console.WriteLine($"Badge #: {individualBadge.BadgeID}");
            ShowDoors(individualBadge);
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