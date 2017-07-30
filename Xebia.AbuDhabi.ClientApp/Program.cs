using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xebia.AbuDhabi.Core;

namespace Xebia.AbuDhabi.ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Billing(new Employee());
            Billing(new RegularCustomer());
            Billing(new Affiliate());
            Console.ReadKey();

        }

        private static void Billing(IPercentageDiscount percentageDiscount)
        {
            var billingService = new BillingService(percentageDiscount, new BillDiscount());
            billingService.AddItem(new OtherItem { Name = "Laptop", Price = 50000 });
            billingService.AddItem(new OtherItem { Name = "Mobile", Price = 20000 });
            billingService.AddItem(new GroceryItem { Name = "Rice", Price = 1000 });
            Console.WriteLine(billingService.PrintBill());
        }

    }
}
