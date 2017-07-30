using System;

namespace Xebia.AbuDhabi.Core
{
    public class BillDiscount : IBillDiscount
    {
        public decimal GetDiscount()
        {
            return 0.05m;
        }
    }
}
