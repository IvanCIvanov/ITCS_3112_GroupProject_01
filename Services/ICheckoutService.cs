using ITCS_3112_Exercise_2.Domain;
namespace ITCS_3112_Exercise_2.Contracts;
/// <summary>
/// Interface for the CheckoutService. 
/// </summary>

/// Need to go back through and make sure it has proper xml documentation

public interface ICheckoutService 
{
    ICatalog GetCatalog { get; }

    Receipt Checkout(long itemId, Customer customer, DateTime dueDate);
    Receipt ReturnItem(long itemId);
    void MarkLost(long itemId);
    public List<CheckoutRecord> ListActiveLoans();
    List<CheckoutRecord> FindDueSoon(TimeSpan window);
    List<CheckoutRecord> FindOverdue();


}