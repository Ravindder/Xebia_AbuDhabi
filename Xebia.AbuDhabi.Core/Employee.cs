namespace Xebia.AbuDhabi.Core
{
    /// <summary>
    /// A store employee class
    /// Store employee has 30% discount on total bill
    /// </summary>
    public class Employee : StoreEmployee, IPercentageDiscount
    {
        public decimal GetDiscount()
        {
            return 0.30m;
        }
    }
}
