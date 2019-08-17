using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    class UI
    {
        private readonly IDictionary<int, List<string>> _badgeAccessToRooms = new Dictionary<int, List<string>>();
        public void Run()
        {
            Menu();
            Console.ReadLine();
        }
        public void Menu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Hello Security Admin, what would you like to do?\n" +
               "1. Add Badge\n" +
               "2. Edit Badge Access\n" +
               "3. List All Badges and Access\n" +
               "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadgeAccess();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
                
                Console.Clear();
            }
        }
        public void AddBadge()
        {

        }

        public void EditBadgeAccess()
        {

        }

        public void ListAllBadges()
        {
             Console.WriteLine();
        }

    }
}
