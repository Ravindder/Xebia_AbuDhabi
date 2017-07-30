using System.Collections.Generic;

namespace Xebia.AbuDhabi.Core
{
    public class BillingService
    {
        Bill _bill;
        IBillDiscount _billDiscount;

        public BillingService(IPercentageDiscount percentageDiscount, IBillDiscount billDiscount)
        {
            _bill = new Bill(percentageDiscount);
            _billDiscount = billDiscount;
        }

        public void AddItem(Item item)
        {
            _bill.Items.Add(item);
        }

        public string PrintBill()
        {
            _bill.CalculateTheBill();
            _bill.ApplyDiscount(_billDiscount);

            return _bill.ToString();
        }
    }
}
