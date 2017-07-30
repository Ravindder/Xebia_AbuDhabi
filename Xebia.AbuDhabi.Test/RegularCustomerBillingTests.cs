using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xebia.AbuDhabi.Core;

namespace Xebia.AbuDhabi.Test
{
    [TestClass]
    public class RegularCustomerBillingTests
    {
        IPercentageDiscount _percentageDiscount;
        IBillingService _billingService;

        ///Arrange
        [TestInitialize]
        public void Start()
        {
            _percentageDiscount = new RegularCustomer();
            _billingService = new BillingService(_percentageDiscount, new BillDiscount());
        }

        [TestMethod]
        public void BillWithNonGroseryItems()
        {
            //act
            _billingService.AddItem(new OtherItem { Name = "Laptop", Price = 50000 });
            _billingService.AddItem(new OtherItem { Name = "Mobile", Price = 20000 });

            var result = _billingService.GetBillDetails();

            //assert
            Assert.AreEqual(result.TotalAmount, 70000.00m);
            Assert.AreEqual(result.TotalDiscount, 3500.00m);
            Assert.AreEqual(result.TotalAmount - result.TotalDiscount, 66500.00m);
            Assert.AreEqual(result.BillDiscount, 3500.00m);
            Assert.AreEqual(result.TotalBill, 63000.00m);

        }

        [TestMethod]
        public void BillWithGroseryItems()
        {
            //act
            _billingService.AddItem(new GroceryItem { Name = "Oil", Price = 800 });
            _billingService.AddItem(new GroceryItem { Name = "Rice", Price = 1000 });

            var result = _billingService.GetBillDetails();
            
            //assert
            Assert.AreEqual(result.TotalAmount, 1800.00m);
            Assert.AreEqual(result.TotalDiscount, 0.00m);
            Assert.AreEqual(result.TotalAmount - result.TotalDiscount, 1800.00m);
            Assert.AreEqual(result.BillDiscount, 90.00m);
            Assert.AreEqual(result.TotalBill, 1710.00m);

        }

        [TestMethod]
        public void BillWithBothItems()
        {
            //act
            _billingService.AddItem(new OtherItem { Name = "Laptop", Price = 50000 });
            _billingService.AddItem(new OtherItem { Name = "Mobile", Price = 20000 });
            _billingService.AddItem(new GroceryItem { Name = "Rice", Price = 1000 });

            var result = _billingService.GetBillDetails();

            //assert
            Assert.AreEqual(result.TotalAmount, 71000.00m);
            Assert.AreEqual(result.TotalDiscount, 3500.00m);
            Assert.AreEqual(result.TotalAmount - result.TotalDiscount, 67500.00m);
            Assert.AreEqual(result.BillDiscount, 3550.00m);
            Assert.AreEqual(result.TotalBill, 63950.00m);

        }
    }
}
