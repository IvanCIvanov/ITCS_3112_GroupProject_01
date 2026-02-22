using ITCS_3112_Exercise_2.Contracts;
namespace ITCS_3112_Exercise_2.Domain;



public class CheckoutService : ICheckoutService
{
    public ICatalog GetCatalog { get; }
    private readonly IRepository _repository;
    private readonly IClock _clock;
    private readonly IPolicy _policy; // Integrated the policy

    public CheckoutService(IRepository repository, IClock clock, IPolicy policy)
    {
        _repository = repository;
        _clock = clock;
        _policy = policy;
        GetCatalog = new Catalog(repository);
    }
    
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

    public void MarkLost(long itemId)
    {
        var item = _repository.GetItemById(itemId);
        if (item != null) item.Status = StatusEnum.Lost;
    }

    public List<CheckoutRecord> ListActiveLoans()
    {
        return _repository.GetAllCheckoutRecords()
            .Where(r => r.Item.Status == StatusEnum.CheckedOut)
            .ToList();
    }

    public List<CheckoutRecord> FindDueSoon(TimeSpan window)
    {
        var now = _clock.GetTime();
        return _repository.GetAllCheckoutRecords()
            .Where(r => r.Item.Status == StatusEnum.CheckedOut && 
                        r.DueDate >= now && 
                        (r.DueDate - now) <= window)
            .ToList();
    }

    public List<CheckoutRecord> FindOverdue()
    {
        var now = _clock.GetTime();
        return _repository.GetAllCheckoutRecords()
            .Where(r => r.Item.Status == StatusEnum.CheckedOut && r.DueDate < now)
            .ToList();
    }
}