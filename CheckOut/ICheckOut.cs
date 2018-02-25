namespace CheckOut
{
    public interface ICheckOut
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}