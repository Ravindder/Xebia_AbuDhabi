namespace Xebia.AbuDhabi.Core
{
    public class Affiliate : IPercentageDiscount
    {
        public decimal GetDiscount()
        {
            return 0.1m;
        }
    }
}
