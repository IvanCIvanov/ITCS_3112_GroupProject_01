using ITCS_3112_Exercise_2.Contracts;
namespace ITCS_3112_Exercise_2.Domain;

public class Catalog : ICatalog
{
    private readonly IRepository _repository;

    public Catalog(IRepository repository)
    {
        _repository = repository;
    }
    public List<Item> GetAvailableItems()
    {
        var fullList = _repository.GetAllItems();
        return fullList.Where(i=>i.Status == StatusEnum.Available).ToList();
    }

    public List<Item> GetUnavailableItems()
    {
        var fullList = _repository.GetAllItems();
        return fullList.Where(i=>i.Status != StatusEnum.Available).ToList();
    }

    public List<Item> Search(string query)
    {
        var fullList = _repository.GetAllItems();
        return (List<Item>)fullList.Where(i => i.Type.ToString() == query);
    }
    
}