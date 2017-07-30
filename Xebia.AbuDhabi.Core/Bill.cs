using System;
using System.Collections.Generic;
using System.Text;

namespace Xebia.AbuDhabi.Core
{
    public class Bill: IOtherItem
    {
        public Bill()
        {
            Items = new HashSet<Item>();
        }

        IPercentageDiscount _percentageDiscount;
        public Bill(IPercentageDiscount percentageDiscount)
        {
            _percentageDiscount = percentageDiscount;
            Items = new HashSet<Item>();
        }

        public ICollection<Item> Items { get; set; }

        public decimal TotalAmount { get; private set; }
        public decimal TotalDiscount { get; private set; }
        public decimal BillDiscount { get; private set; }
        public decimal TotalBill
        {
            get
            {
                return TotalAmount - TotalDiscount- BillDiscount;
            }
        }

        public void CalculateTheBill()
        {
            foreach (var item in Items)
            {
                if (item is OtherItem oterItem)
                {
                    oterItem.ApplyDiscount(_percentageDiscount);
                    TotalDiscount = TotalDiscount + oterItem.Discount;
                }
                TotalAmount = TotalAmount + item.Price;
            }
        }

        public void ApplyDiscount(IDiscount discount)
        {
            BillDiscount = TotalAmount * discount.GetDiscount();
        }

        public override string ToString()
        {
            var billDetails = new StringBuilder();
            billDetails.AppendFormat("{0} Bill details : \n", _percentageDiscount.GetType().Name);
            billDetails.AppendFormat(" Total Amount : {0} \n", TotalAmount);
            billDetails.AppendFormat(" Total Discount : {0} \n", TotalDiscount);
            billDetails.AppendFormat(" Total Bill : {0} \n", TotalAmount - TotalDiscount);
            billDetails.AppendFormat(" Discount on Bill : {0} \n", BillDiscount);
            billDetails.AppendFormat(" Bill to be paid : {0} \n", TotalBill);

            return billDetails.ToString();
        }
    }
}
