using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges.Classes
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> BadgeAccessToRooms = new List<string>();

        public Badge() { }

        public Badge(int badgeID, List<string> badgeAccessToRooms)
        {
            BadgeID = badgeID;
            BadgeAccessToRooms = badgeAccessToRooms;
        }
    }

    public class BadgeRepo
    {
        IDictionary<int, List<string>> _badgeAccessToRooms = new Dictionary<int, List<string>>();

        public void CreateDictionary()
        {                                                                   //key       //value
            IDictionary<int, List<string>> badgeAccessToRooms = new Dictionary<int, List<string>>();

            List<string> allRooms = new List<string>() { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };

            badgeAccessToRooms.Add(00, allRooms); //Test Badge
        }

        public void GetBadgeID()
        {
            if (_badgeAccessToRooms.ContainsKey(111))
            {
                List<string> accessRooms = _badgeAccessToRooms[111];
                Console.WriteLine("Badge 111 has access to");

                foreach (string room in accessRooms)
                {
                    Console.WriteLine(room);
                }
            }
        }

        public void UpdateDoors()
        {
            if (_badgeAccessToRooms.ContainsKey(111))
            {
                List<string> currentRooms = _badgeAccessToRooms[111];
                printListOnLine(currentRooms);
                if (currentRooms.Contains("A1"))
                    currentRooms.Add("A1");
                printListOnLine(currentRooms);
            }
        }

        //helper
        public void printListOnLine(List<string> listOfItems)
        {
            foreach (string item in listOfItems)
                Console.Write(" " + item);
                Console.WriteLine();
        }


        public void DeleteDoorFromBadge()
        {
                if (_badgeAccessToRooms.ContainsKey(111))
                    {
                        List<string> currentRooms = _badgeAccessToRooms[111];
                        printListOnLine(currentRooms);
                        if (currentRooms.Contains("A1"))
                            currentRooms.Remove("A1");
                        printListOnLine(currentRooms);
                    }
        }

        public void GetBadgeAccessList()
        {
            foreach (var badge in _badgeAccessToRooms)
            {
                Console.WriteLine("Badge Number : " + badge.Key + " has access to ");
                foreach (string room in badge.Value)
                {
                    Console.WriteLine(" " + room);
                }
                Console.WriteLine();
            }
        }
    }
}

