namespace Xebia.AbuDhabi.Core
{
    public class RegularCustomer : IPercentageDiscount
    {
        public decimal GetDiscount()
        {
            return 0.05m;
        }
    }
}
