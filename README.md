# Xebia_AbuDhabi
Abu Dhabi retail wbesite

Code structure:
I've used decorator pattern to design this billing system along with SOLID principles.

Decorator Pattern Details are below.

Components: IDiscount,IPercentageDiscount

ConcreteComponents : Affiliate,Employee and RegularCustomer

Decorator : IBillingService

ConcreteDecorator : BillingService and Bill

UnitTests:
I've used default Microsoft's TestFramework to design and run the tests.
Please add the following packages from nuget to run the tests
  1. MSTest.TestAdapter.1.1.11
  2. MSTest.TestFramework.1.1.11

Thanks for the great assignment.
