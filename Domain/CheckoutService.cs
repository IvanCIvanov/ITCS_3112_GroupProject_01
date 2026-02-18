using ITCS_3112_Exercise_2.Contracts;
namespace ITCS_3112_Exercise_2.Domain;



public class CheckoutService : ICheckoutService
{
    
    public DateTime CheckoutDate { get; set; }
    public DateTime DueDate { get; set; }
    public Person Borrower { get; set; }
    public Item Item { get; set; }
    public Receipt Receipt { get; private set; }
    public ICatalog GetCatalog { get; }

    /// <summary>
    /// Composition: The CheckoutRecord "owns" the Receipt.
    /// The Receipt is instantiated here and its lifecycle is tied to this record.
    /// </summary>
    
    public CheckoutService(string summary, Customer borrower, ICatalog getCatalog)
    {
        Borrower = borrower;
        GetCatalog = getCatalog;
        CheckoutDate = DateTime.Now;
        DueDate = DateTime.Now.AddDays(7);
        // Instantiating the Receipt inside the constructor ensures Composition.
        Receipt = new Receipt { Summary = summary };
    }
    
    public Receipt Checkout(string itemId, Customer customer, DateTime dueDate)
    {
        throw new NotImplementedException();
    }

    public Receipt ReturnItem(string itemId)
    {
        throw new NotImplementedException();
    }

    public void MarkLost(string itemId)
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