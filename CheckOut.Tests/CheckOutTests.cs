using System;
using System.Collections.Generic;
using CheckOut.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckOut.Tests
{
    [TestClass]
    public class CheckOutTests
    {
        private List<Item> _items;
        private CheckOut _checkOut;
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
            _checkOut = new CheckOut(_items);  
        }
        
        [TestMethod]
        public void Scan_WhenValidSKUPassed_IncreasesTotalItemCount()
        {
            _checkOut.Scan("A");

            Assert.IsTrue(_checkOut.TotalItemCount == 1);
        }
        
        [TestMethod]
        public void Scan_WhenInValidSKUPassed_ThrowsArguementOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _checkOut.Scan("Z"));  
        }        
        
        [TestMethod]
        public void GetTotalPrice_OneNotDiscounted_ReturnsNotDiscountedTotal()
        { 
            _checkOut.Scan("A");

            var result = _checkOut.GetTotalPrice();

            Assert.IsTrue(result == 50);
        }    
        
        [TestMethod]
        public void GetTotalPrice_OneOfEach_ReturnsNotDiscountedTotal()
        { 
            _checkOut.Scan("A");
            _checkOut.Scan("B");
            _checkOut.Scan("C");
            _checkOut.Scan("D");    
            
            var result = _checkOut.GetTotalPrice();
            
            Assert.IsTrue(result == 115);
        }
        
        [TestMethod]
        public void GetTotalPrice_TwoOfDiscountedItemsAndOneNonDiscountedItem_ReturnsDiscountedTotal()
        { 
            _checkOut.Scan("A");
            _checkOut.Scan("B");
            _checkOut.Scan("B");   
           
            var result = _checkOut.GetTotalPrice();
       
            Assert.IsTrue(result == 95);
        }        
        
        [TestMethod]
        public void GetTotalPrice_ThreeOfDiscountedTwoOfDiscountedAndOneNonDiscounted_ReturnsDiscountedTotal()
        { 
            _checkOut.Scan("A");
            _checkOut.Scan("B");
            _checkOut.Scan("B");   
            _checkOut.Scan("A");
            _checkOut.Scan("A");
            _checkOut.Scan("C");
             
            var result = _checkOut.GetTotalPrice();
            
            Assert.IsTrue(result == 195);
        }               
        
        [TestMethod]
        public void GetTotalPrice_TwoPlusOneDiscounted_ReturnsDiscountedTotal()
        { 
            _checkOut.Scan("A");
            _checkOut.Scan("B");
            _checkOut.Scan("B"); 
            _checkOut.Scan("B");
            
            var result = _checkOut.GetTotalPrice();
             
            Assert.IsTrue(result == 125);
        }          
        
        [TestMethod]
        public void GetTotalPrice_TwoDiscountedTimesTwoAndTwoNotDiscounted_ReturnsDiscountedTotal()
        { 
            _checkOut.Scan("A");
            _checkOut.Scan("B");
            _checkOut.Scan("A");
            _checkOut.Scan("B");            
            _checkOut.Scan("B"); 
            _checkOut.Scan("B");
            
            var result = _checkOut.GetTotalPrice();
             
            Assert.IsTrue(result == 190);
        }      
    }      
}