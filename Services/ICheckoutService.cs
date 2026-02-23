using ITCS_3112_Exercise_2.Domain;
namespace ITCS_3112_Exercise_2.Contracts;
/// <summary>
/// Defines the contract for checkout-related operations.
/// Handles item checkout, returns, and loan tracking.
/// </summary>

/// Need to go back through and make sure it has proper xml documentation

public interface ICheckoutService 
{
    /// <summary>
    /// 
    /// </summary>
    ICatalog GetCatalog { get; }

    /// <summary>
    /// Checks out an item to borrower for set amount of time.
    /// </summary>
    /// <param name="itemId">
    /// ID of checked out item
    /// </param>
    /// <param name="customer">
    /// Customer checking out the item in question.
    /// </param>
    /// <param name="dueDate">
    /// Current due date the customer must return the item by.
    /// </param>
    /// <returns>
    /// A receipt representing the completed checkout.
    /// </returns>
    Receipt Checkout(long itemId, Customer customer, DateTime dueDate);
    
    /// <summary>
    /// Returns a previously checked out item.
    /// </summary>
    /// <param name="itemId">
    /// ID of the returned item.
    /// </param>
    /// <returns>
    /// Receipt confirming the return of the item.
    /// </returns>
    Receipt ReturnItem(long itemId);
    
    /// <summary>
    /// Changing the status of an item to Lost.
    /// </summary>
    /// <param name="itemId">
    /// ID of the item lost.
    /// </param>
    void MarkLost(long itemId);
    
    /// <summary>
    /// Shows all loans active within the system.
    /// </summary>
    /// <returns>
    /// Returns list of items tha must be returned.
    /// </returns>
    public List<CheckoutRecord> ListActiveLoans();
    
    /// <summary>
    /// Details all of the items that are due within the next 24 hours.
    /// </summary>
    /// <param name="window">
    /// Amount of time left before the item is overdue.
    /// </param>
    /// <returns>
    /// Returns a receipt that alerts the user how much time they have left
    /// before it is overdue.
    /// </returns>
    List<CheckoutRecord> FindDueSoon(TimeSpan window);
    
    /// <summary>
    /// Details all of the items are currently overdue within the system.
    /// </summary>
    /// <returns>
    /// Returns a list of items that have gone beyond their due date.
    /// </returns>
    List<CheckoutRecord> FindOverdue();


}