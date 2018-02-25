using System;
using System.Collections.Generic;
using System.Linq;
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
            var total = 0;
            foreach (var s in _basket.Distinct())
            {
                var item = _items.FirstOrDefault(k => k.Sku == s);
                var itemCountInBasket =  _basket.Count(k => k == s);
                if (item.DiscountQuantity > 0 && itemCountInBasket >= item.DiscountQuantity)
                {
                    int itemCountToBeDiscounted = itemCountInBasket / item.DiscountQuantity;
                    int itemCountNotToBeDiscounted = itemCountInBasket % item.DiscountQuantity;
                    total += (itemCountToBeDiscounted * item.DiscountedTotal) + (itemCountNotToBeDiscounted * item.UnitPrice);
                } 
                else
                {
                    total += itemCountInBasket * item.UnitPrice;
                }
            }

            return total;
        }
    }


}