using ITCS_3112_Exercise_2.Contracts;
namespace ITCS_3112_Exercise_2.Domain;

public class Repository : IRepository
{
    /// Singular Repository
    private List<Item> _inventory = new List<Item>();

    public Repository()
    {
        _inventory.Add(new Item(295002835, "Oculus Rift", TypeEnum.VrHeadset,StatusEnum.Available, ConditionEnum.Good)
        {
            Damages = "None"
        }); 
        
        _inventory.Add(new Item(491002837,"Prince of Persia", TypeEnum.Dvd,StatusEnum.Unavailable, ConditionEnum.Poor)
        {
            Damages = "Minor Scratches on Display Side."
        });
        
        _inventory.Add(new Item(100200399,"Canon EOS R100 Mirrorless Camera", TypeEnum.Camera,StatusEnum.Lost, ConditionEnum.Unknown)
        {
            Damages = "Unknown - never returned to library."
        });
    }

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

    public List<Item> GetAllAvailableItems()
    {
        return _inventory.Where(i => i.Status == StatusEnum.Available).ToList();
    }
    
    public List<Item> GetAllUnavailableItems()
    {
        return _inventory.Where(i => i.Status != StatusEnum.Available).ToList();
    }

    public void DeleteItem(Item item)
    {
        // TODO: Add Try-Catch 
        _inventory.Remove(item);
    }



}