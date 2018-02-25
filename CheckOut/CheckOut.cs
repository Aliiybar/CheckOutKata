using System;
using System.Collections.Generic;
using CheckOut.Models;

namespace CheckOut
{
    public class CheckOut : ICheckOut
    {
        private readonly List<string> _basket = new List<string>();
        private readonly List<Item> _items;
        public int TotalItemCount = 0;
        
        public CheckOut(List<Item> items)
        {
            _items = items;
        }
       
        public void Scan(string item)
        {
            if (_items.Exists(k => k.Sku == item))
            {
              _basket.Add(item);
              TotalItemCount += 1;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            
        }
         

        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }
    }


}