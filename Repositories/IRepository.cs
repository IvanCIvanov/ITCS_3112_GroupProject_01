using ITCS_3112_Exercise_2.Domain;
namespace ITCS_3112_Exercise_2.Contracts;

public interface IRepository
{
    // Basic CRUD
    void AddItem(Item item);
    Item GetItemById(long id);
    List<Item> GetAllItems();
    List<Item> GetAllAvailableItems();
    List<Item> GetAllUnavailableItems();
    void DeleteItem(Item item);
    
    // Added for CheckoutService support
    void AddCheckoutRecord(CheckoutRecord record);
    List<CheckoutRecord> GetAllCheckoutRecords();
    
    
    // We might also need methods for CheckoutRecords later





}