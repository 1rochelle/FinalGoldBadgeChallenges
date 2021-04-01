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

        //somehow show how dictionary key is BadgeID and value is DoorNames


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

    }
}
