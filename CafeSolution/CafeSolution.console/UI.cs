using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeSolution.Classes;

namespace CafeSolution.console
{
    class UI
    {
        private readonly MenuRepo _menuRepo = new MenuRepo();

        public void Run()
        {
            _menuRepo.SeedMenu();
            Menu();
            Console.ReadLine();
        }

        public void Menu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Welcome to Komodo Cafe, would you like to\n" +
               "1. See all Menu items\n" +
               "2. Add a new Menu item\n" +
               "3. Remove a Menu item\n" +
               "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ListMenuItems();
                        break;
                    case "2":
                        AddMenuItem();
                        break;
                    case "3":
                        RemoveMenuItemByMenuNumber();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        Console.ReadKey();
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.Clear();
            }
        }

        public void ListMenuItems()
        {
            foreach (Menu item in _menuRepo.GetMenuItems())
            {
                Console.WriteLine($"The number {item.MenuNumber}, {item.MenuName}. {item.Description}. It costs ${item.Price}");
            }
            Console.ReadLine();
        }

        public void AddMenuItem()
        {
            Console.WriteLine("Please input the new item's menu number.");
            string inputMenuNumber = Console.ReadLine();
            int menuNum = int.Parse(inputMenuNumber);

            Console.WriteLine("Please input the new item's menu name.");
            string inputMenuName = Console.ReadLine();

            Console.WriteLine("Please input the new item's description.");
            string inputDescription = Console.ReadLine();

            Console.WriteLine("Please input the new item's price.");
            string inputPrice = Console.ReadLine();
            double menuPrice = double.Parse(inputPrice);

            //empty list
            List<string> placeholder = new List<string>();

            Menu newItem = new Menu(menuNum, inputMenuName, inputDescription, menuPrice, placeholder);
            _menuRepo.AddMenuItem(newItem);

            Console.WriteLine($"{inputMenuName} has been completely added to the Menu.");
        }

        public void RemoveMenuItemByMenuNumber()
        {
            //?do we need to list the items first
            Console.WriteLine("Please input the menu number you would like to remove.");
            string userInput = Console.ReadLine();
            int menuNumber = int.Parse(userInput);
            bool success = _menuRepo.RemoveMenuItemByMenuNumber(menuNumber);
            if (success)
            {
                Console.WriteLine("Menu item removed Successfully.");
            }
            else
            {
                Console.WriteLine("Menu item could not be removed.");
            }

        }
    }
}

