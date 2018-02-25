using System.Collections.Generic;
using CheckOut.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckOut.Tests
{
    [TestClass]
    public class CheckOutTests
    {
        private List<Item> _items;
        
        [TestInitialize]
        public void SetUp()
        {
            _items = new List<Item>
            {
                new Item("A", 50, 3, 130),
                new Item("B", 30, 2, 45),
                new Item("C", 20, 0, 0),
                new Item("D", 15, 0, 0)
            };
        }
        
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}