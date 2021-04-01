using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03ChallengeBadgesLibrary
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<Badges> DoorNames { get; set; }

        public Badges()
        {

        }

        public Badges(int badgeID, List<Badges>doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
        }
    }
}
