namespace Xebia.AbuDhabi.Core
{
    public class OtherItem : Item, IOtherItem
    {
        public decimal Discount { get; private set; }

        public void ApplyDiscount(IDiscount discount)
        {
            Discount = Price * discount.GetDiscount();
        }
    }
}
