using ITCS_3112_Exercise_2.Domain;
namespace ITCS_3112_Exercise_2.Contracts;
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

    List<Domain.CheckoutService> ListActiveLoans();

    List<Domain.CheckoutService> FindDueSoon(TimeSpan window);

    List<Domain.CheckoutService> FindOverdue();


}