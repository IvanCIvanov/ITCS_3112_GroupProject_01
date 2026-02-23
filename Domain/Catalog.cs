using ITCS_3112_Exercise_2.Contracts;
namespace ITCS_3112_Exercise_2.Domain;

/// <summary>
/// Catalog works as a place to store information for the bookstore.
/// All items will be stored in a list that can be changed through adding
/// or deleting items on the list.
///
/// It can display what items are currently available or unavailable to users.
/// </summary>
public class Catalog : ICatalog
{
    private readonly IRepository _repository;

    /// <summary>
    /// Initializes a new instance of a Catalog class.
    /// </summary>
    /// <param name="repository"></param>
    /// The repository is used to store and manage items.
    /// 
    public Catalog(IRepository repository)
    {
        _repository = repository;
    }
    
    /// <summary>
    /// Reads through the list of all items within the repository
    /// to notify user what options are available.
    /// </summary>
    /// <returns></returns>
    /// Returns a full list of all items in repository available for checkout.
    public List<Item> GetAvailableItems()
    {
        var fullList = _repository.GetAllItems();
        return fullList.Where(i=>i.Status == StatusEnum.Available).ToList();
    }

    
    /// <summary>
    /// Reads through the list of all items within the repository to notify user
    /// of which items are not available for checkout.
    /// </summary>
    /// <returns></returns>
    /// Returns a list of all unavailable items in repository.
    public List<Item> GetUnavailableItems()
    {
        var fullList = _repository.GetAllItems();
        return fullList.Where(i=>i.Status != StatusEnum.Available).ToList();
    }
    
    /// <summary>
    /// Reads through list to find the item the user is looking for.
    /// </summary>
    /// <param name="query"></param>
    /// Query used to compare against items in list.
    /// <returns></returns>
    /// Returns a full list of matching items within the repository.
    public List<Item> Search(string query)
    {
        var fullList = _repository.GetAllItems();
        return (List<Item>)fullList
            .Where(i => i.Type.ToString() == query)
            .ToList();
    }
    
}