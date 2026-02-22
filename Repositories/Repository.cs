using ITCS_3112_Exercise_2.Contracts;
namespace ITCS_3112_Exercise_2.Domain;

public class Repository : IRepository
{
    /// Singular Repository
    private List<Item> _inventory = new List<Item>();
    private List<CheckoutRecord> _records = new List<CheckoutRecord>(); // Added record storage

    public Repository()
    {
        _inventory.Add(new Item(295002835, "Oculus Rift", TypeEnum.VrHeadset, StatusEnum.Available, ConditionEnum.Good) { Damages = "None" }); 
        _inventory.Add(new Item(491002837,"Prince of Persia", TypeEnum.Dvd, StatusEnum.Unavailable, ConditionEnum.Poor) { Damages = "Minor Scratches." });
        _inventory.Add(new Item(100200399,"Canon EOS R100 Camera", TypeEnum.Camera, StatusEnum.Lost, ConditionEnum.Unknown) { Damages = "Unknown" });
    }

    public void AddItem(Item item)
    {
        if (_inventory.Any(i => i.Id == item.Id)) throw new Exception("Item with this ID already exists.");
        _inventory.Add(item);
    }

    public Item GetItemById(long id) => _inventory.FirstOrDefault(i => i.Id == id);
    public List<Item> GetAllItems() => _inventory;
    public List<Item> GetAllAvailableItems() => _inventory.Where(i => i.Status == StatusEnum.Available).ToList();
    public List<Item> GetAllUnavailableItems() => _inventory.Where(i => i.Status != StatusEnum.Available).ToList();
    public void DeleteItem(Item item) => _inventory.Remove(item);

    // New Implementations
    public void AddCheckoutRecord(CheckoutRecord record) => _records.Add(record);
    public List<CheckoutRecord> GetAllCheckoutRecords() => _records;
}