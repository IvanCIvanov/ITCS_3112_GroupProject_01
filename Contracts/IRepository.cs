namespace ITCS_3112_Exercise_2.Contracts;

public interface IRepository
{
    // Basic CRUD
    void AddItem(Item item);
    Item GetItemById(long id);
    List<Item> GetAllItems();
    void DeleteItem(Item item);
    
    
    // We might also need methods for CheckoutRecords later





}