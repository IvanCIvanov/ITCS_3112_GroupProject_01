using ITCS_3112_Exercise_2.Domain;
namespace ITCS_3112_Exercise_2.Contracts;

public interface ICatalog
{
    List<Item> GetAvailableItems();
    List<Item> GetUnavailableItems();
    List<Item> Search(string query);
    
    
}