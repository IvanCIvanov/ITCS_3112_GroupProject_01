using ITCS_3112_Exercise_2.Domain;
namespace ITCS_3112_Exercise_2.Contracts;

/// <summary>
/// Showcases different ways the Catalog is altered throughout the process.
/// </summary>
public interface ICatalog
{
    /// <summary>
    /// Shows all available items within the repository.
    /// </summary>
    /// <returns>
    /// List of available items.
    /// </returns>
    List<Item> GetAvailableItems();
    
    /// <summary>
    /// Shows all unavailable items in the repository.
    /// </summary>
    /// <returns>
    /// List of unavailable items.
    /// </returns>
    List<Item> GetUnavailableItems();
    
    /// <summary>
    /// Returns the query of the item being searched.
    /// </summary>
    /// <param name="query">
    /// User input that is checked against the list.
    /// </param>
    /// <returns>
    /// Information regarding the item being searched.
    /// </returns>
    List<Item> Search(string query);
    
    
}