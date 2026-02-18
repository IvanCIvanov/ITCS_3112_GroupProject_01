namespace ITCS_3112_Exercise_2;
/// <summary>
/// Interface for the CheckoutService. 
/// </summary>

/// Need to go back through and make sure it has proper xml documentation

public interface ICheckoutService 
{
    ICatalog GetCatalog { get; }

    Receipt Checkout(string itemId, Customer customer, DateTime dueDate);

    Receipt ReturnItem(string itemId);
    
    void MarkLost(string itemId);

    List<CheckoutRecord> ListActiveLoans();

    List<CheckoutRecord> FindDueSoon(TimeSpan window);

    List<CheckoutRecord> FindOverdue();


}