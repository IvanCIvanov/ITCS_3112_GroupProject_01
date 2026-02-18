using ITCS_3112_Exercise_2.Contracts;
namespace ITCS_3112_Exercise_2.Domain;

public class Repository : IRepository
{
    /// Singular Repository
    private List<Item> _inventory = new List<Item>();

    public void AddItem(Item item)
    {
        // Simple validation to prevent duplicate IDs
        if (_inventory.Any(i => i.Id == item.Id))
        {
            throw new Exception("Item with this ID already exists.");
        }
        _inventory.Add(item);
    }

    public Item GetItemById(long id)
    {
        // Returns the item or null if not found
        return _inventory.FirstOrDefault(i => i.Id == id);
    }

    public List<Item> GetAllItems()
    {
        return _inventory;
    }

    public void DeleteItem(Item item)
    {
        // TODO: Add Try-Catch 
        _inventory.Remove(item);
    }



}