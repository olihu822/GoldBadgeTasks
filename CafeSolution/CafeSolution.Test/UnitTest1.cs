using System;
using System.Collections.Generic;
using CafeSolution.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeSolution.Test
{
    [TestClass]                                                                                      
    public class UnitTest1
    {
        private List<Menu> _menuList = new List<Menu>();
        private MenuRepo _menuRepo = new MenuRepo();
        public List<string> ingredients = new List<string>();

        [TestMethod]
        public void ShouldList()
        {
            foreach (Menu item in _menuRepo.GetMenuItems())
            {
                Console.WriteLine(item);
            }

            _menuRepo.ListMenuItems();

            var expected = 3;
            var actual = _menuRepo.GetMenuItems().Count;

            Assert.AreEqual(expected, actual);
        }

        public void ShouldAddNew()
        {
            Menu item = new Menu(5, "Sushi", "Fresh fish on rice", 10.99d, ingredients);

            _menuRepo.AddMenuItem(item);

            var expected = 4;
            var actual = _menuRepo.GetMenuItems().Count;

            Assert.AreEqual(expected, actual);
        }

        public void ShouldRemove()
        {

            Menu GetMenuItemByMenuNumber(int menuNum)
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

            Menu itemToRemove = GetMenuItemByMenuNumber(2);

            _menuList.Remove(itemToRemove);

            var expected = 2;
            var actual = _menuRepo.GetMenuItems().Count;

            Assert.AreEqual(expected, actual);
        }
    }
}



