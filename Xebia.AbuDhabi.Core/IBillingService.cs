namespace Xebia.AbuDhabi.Core
{
    public interface IBillingService
    {
        void AddItem(Item item);
        Bill GetBillDetails();
        string PrintBill();
    }
}
