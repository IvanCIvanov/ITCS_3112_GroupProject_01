using ITCS_3112_Exercise_2.Contracts;
namespace ITCS_3112_Exercise_2.Domain;


/// <summary>
///Creates a new instance of the CheckoutService.
/// 
/// </summary>
public class CheckoutService : ICheckoutService
{
    public ICatalog GetCatalog { get; }
    private readonly IRepository _repository;
    private readonly IClock _clock;
    private readonly IPolicy _policy; // Integrated the policy

    /// <summary>
    /// Initializes a new instance of CheckoutService.
    /// Service that handles checkout-related logic.
    /// Applies polices and updates item status.
    /// </summary>
    /// <param name="repository">
    /// The repository used to access and modify items.
    /// </param>
    /// <param name="clock">
    /// Clock abstraction used for getting current time.
    /// </param>
    /// <param name="policy">
    /// Policy that defines rules for the checkout operations.
    /// </param>
    public CheckoutService(IRepository repository, IClock clock, IPolicy policy)
    {
        _repository = repository;
        _clock = clock;
        _policy = policy;
        GetCatalog = new Catalog(repository);
    }
    
    /// <summary>
    /// Updates and changes how items are perceived through changing the StatusEnum
    /// and keeps an accurate representation of items by updating the CheckoutRecord.
    /// </summary>
    /// <param name="itemId">
    /// The item id that is being checked out.
    /// </param>
    /// <param name="customer">
    /// The borrower checking out the item.
    /// </param>
    /// <param name="dueDate">
    /// The current dueDate for when the customer must return the item.
    /// </param>
    /// <returns>
    /// This will return a receipt that shows the item's current status.
    /// </returns>
    /// <exception cref="Exception">
    /// If an item fails to meet the requirements, an exception will be thrown.
    /// </exception>
    public Receipt Checkout(long itemId, Customer customer, DateTime dueDate)
    {
        var item = _repository.GetItemById(itemId);
        
        // Use the Policy to enforce business rules
        if (!_policy.CanCheckout(item))
        {
            throw new Exception("Policy Violation: Item cannot be checked out.");
        }

        item.Status = StatusEnum.CheckedOut;
        var record = new CheckoutRecord(item, customer, dueDate, $"Checked out {item.Name} to {customer.Name}");
        _repository.AddCheckoutRecord(record);
        
        return record.Receipt;
    }

    /// <summary>
    /// Once a user has indicated they would like to return an item,
    /// they can enter their item ID. The repository list should update
    /// to reflect this.
    /// </summary>
    /// <param name="itemId">
    /// Item being returned.
    /// </param>
    /// <returns>
    /// Returns a receipt that alerts the user if their item has been successfully
    /// returned.
    /// </returns>
    /// <exception cref="Exception">
    /// If an item is not entered or is not currently checked out, it cannot be returned.
    /// As such, this throws an error alerting the user.
    /// </exception>
    public Receipt ReturnItem(long itemId)
    {
        var item = _repository.GetItemById(itemId);
        if (item == null || item.Status != StatusEnum.CheckedOut)
        {
            throw new Exception("Item cannot be returned (it may not be checked out).");
        }

        item.Status = StatusEnum.Available;
        return new Receipt { Summary = $"Item {item.Name} returned successfully." };
    }

    /// <summary>
    /// Users can mark items lost through this and update the repository list.
    /// </summary>
    /// <param name="itemId">
    /// The item that is lost.
    /// </param>
    public void MarkLost(long itemId)
    {
        var item = _repository.GetItemById(itemId);
        if (item != null) item.Status = StatusEnum.Lost;
    }

    /// <summary>
    /// Lists all active loans wihthin the repository.
    /// Responds accordingly if items are returned.
    /// </summary>
    /// <returns>
    /// Returns a list of all active loans.
    /// </returns>
    public List<CheckoutRecord> ListActiveLoans()
    {
        return _repository.GetAllCheckoutRecords()
            .Where(r => r.Item.Status == StatusEnum.CheckedOut)
            .ToList();
    }

    /// <summary>
    /// Returns a list of items that are due within the next 24 hours.
    /// </summary>
    /// <param name="window">
    /// Amount of time the user has left before their item is overdue.
    /// </param>
    /// <returns>
    /// Returns a list of items that will soon be overdue.
    /// </returns>
    public List<CheckoutRecord> FindDueSoon(TimeSpan window)
    {
        var now = _clock.GetTime();
        return _repository.GetAllCheckoutRecords()
            .Where(r => r.Item.Status == StatusEnum.CheckedOut && 
                        r.DueDate >= now && 
                        (r.DueDate - now) <= window)
            .ToList();
    }

    /// <summary>
    /// This works to look through the repository and return any items that are
    /// currently overdue.
    /// </summary>
    /// <returns>
    /// Returns a list of overdue items.
    /// </returns>
    public List<CheckoutRecord> FindOverdue()
    {
        var now = _clock.GetTime();
        return _repository.GetAllCheckoutRecords()
            .Where(r => r.Item.Status == StatusEnum.CheckedOut && r.DueDate < now)
            .ToList();
    }
}