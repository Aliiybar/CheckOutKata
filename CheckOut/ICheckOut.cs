﻿namespace CheckOut
{
    public interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}