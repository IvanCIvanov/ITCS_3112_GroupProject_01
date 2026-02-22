using ITCS_3112_Exercise_2.Contracts;
namespace ITCS_3112_Exercise_2.Domain;



public class CheckoutService : ICheckoutService
{
    
    
    public ICatalog GetCatalog { get; }
    public IRepository _repository;
    public IClock _clock;

    /// <summary>
    /// Composition: The CheckoutRecord "owns" the Receipt.
    /// The Receipt is instantiated here and its lifecycle is tied to this record.
    /// </summary>
    ///

    public CheckoutService(IRepository repository, IClock clock)
    {
        _repository = repository;
        _clock = clock;
    }
    
    
    
    public Receipt Checkout(long itemId, Customer customer, DateTime dueDate)
    {
        throw new NotImplementedException();
    }

    public Receipt ReturnItem(long itemId)
    {
        throw new NotImplementedException();
    }

    public void MarkLost(long itemId)
    {
        throw new NotImplementedException();
    }

    public List<Domain.CheckoutService> ListActiveLoans()
    {
        throw new NotImplementedException();
    }

    public List<Domain.CheckoutService> FindDueSoon(TimeSpan window)
    {
        throw new NotImplementedException();
    }

    public List<Domain.CheckoutService> FindOverdue()
    {
        throw new NotImplementedException();
    }
}