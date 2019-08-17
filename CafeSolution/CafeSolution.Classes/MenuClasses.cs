using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeSolution.Classes
{
    public class Menu
    {
        public int MenuNumber { get; set; }
        public string MenuName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<string> Ingredients = new List<string>();

        public Menu() { }

        public Menu(int menuNum, string menuName, string description, double price, List<string> ingredients)
        {
            MenuNumber = menuNum;
            MenuName = menuName;
            Description = description;
            Price = price;
            Ingredients = ingredients;
        }
    }


    public class MenuRepo
    {
        private readonly List<Menu> _menuList = new List<Menu>();

        public List<Menu> GetMenuItems()
        {
            return _menuList;
        }

        public void AddMenuItem(Menu newItem)
        {
            _menuList.Add(newItem);
        }

        public Menu GetMenuItemByMenuNumber(int menuNum)
        {
            foreach (Menu item in _menuList)
            {
                if (item.MenuNumber == menuNum)
                {
                    return item;
                }
            }
            return null;
        }

        public bool RemoveMenuItemByMenuNumber(int menuNum)
        {
            Menu item = GetMenuItemByMenuNumber(menuNum);
            bool result = _menuList.Remove(item);
            return result;
        }

        public void SeedMenu()
        {
            Menu item = new Menu(1, "Burger", "A classic burger", 5.99d, new List<string>());
            _menuList.Add(item);

            Menu item2 = new Menu(2, "Hot Dog", "An all beef hot dog", 3.99d, new List<string>());
            _menuList.Add(item2);

            Menu item3 = new Menu(3, "Pasta", "With spaghetti sauce", 7.99d, new List<string>());
            _menuList.Add(item3);
        }

        public void ListMenuItems()
        {
            throw new NotImplementedException();
        }
    }
}
