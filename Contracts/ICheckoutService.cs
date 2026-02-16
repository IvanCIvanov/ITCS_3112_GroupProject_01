namespace ITCS_3112_Exercise_2.Contracts;
/// <summary>
/// Interface for the CheckoutService. 
/// </summary>

//Need to go back through and make sure it has proper xml documentation

public interface ICheckoutService
{
    ICatalog GetCatalog { get; }

    Receipt Checkout(string itemId, Borrower borrower, DateTime dueDate);

    Receipt ReturnItem(string itemId);
    
    void MarkLost(string itemId);

    List<CheckoutRecord> ListActiveLoans();

    List<CheckoutRecord> FindDueSoon(TimeSpan window);

    List<CheckoutRecord> FindOverdue();


}