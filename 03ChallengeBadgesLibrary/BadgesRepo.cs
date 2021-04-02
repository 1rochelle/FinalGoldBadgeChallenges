using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03ChallengeBadgesLibrary
{
    public class BadgesRepo
    {
        

        Dictionary<int, Badges> _badgesDictionary = new Dictionary<int, Badges>();




        public bool AddBadgeToDictionary(Badges badge)
        {
            _badgesDictionary.Add(badge.BadgeID, badge);
            return true;
        }
        //Read: show all badges
        public Dictionary<int, Badges> GetAllBadges()
        {
            return _badgesDictionary;
        }
        //Read: get badge by ID so update can work
        public Badges GetBadgeByID(int badgeID)
        {
            foreach(var findBadge in _badgesDictionary)
            {
                if(badgeID == findBadge.Key)
                {
                    return findBadge.Value;
                }
            }
            return null;

        }
        //Update: update door access
        public bool UpdateExistingBadge(int oldBadgeID, Badges updateBadge)
        {
            Badges oldBadge = GetBadgeByID(oldBadgeID);
            if(oldBadge != null)
            {               
                oldBadge.DoorNames = updateBadge.DoorNames;
                return true;
            }
            return false;
        }
        //Delete
        public bool DeleteExistingRoom(int badgeID, string roomNumber)
        {
            foreach (var item in _badgesDictionary)
            {
                if (item.Key == badgeID)
                {
                    foreach (var door in item.Value.DoorNames)
                    {
                        if (door == roomNumber)
                        {
                            item.Value.DoorNames.Remove(door);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool AddNewRoom(int badgeID, string roomNumber)
        {
            Badges oldBadge = GetBadgeByID(badgeID);

            if(oldBadge != null)
            {
                oldBadge.DoorNames.Add(roomNumber);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
