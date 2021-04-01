using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03ChallengeBadgesLibrary
{
    public class BadgesRepo
    {
        protected readonly List<Badges> _currentBadgePermissions = new List<Badges>();

        Dictionary<int, string> badgesDictionary = new Dictionary();

        //somehow show how dictionary key is BadgeID and value is DoorNames

        //Read: show all badges
        public List<Badges> GetAllBadges()
        {
            return _currentBadgePermissions;
        }
    }
}
