using ITCS_3112_Exercise_2.Domain;
namespace ITCS_3112_Exercise_2;

/// <summary>
/// Dictates how the item will be treated according to its status.
/// </summary>
public interface IPolicy
{
    /// <summary>
    /// Shows whether an item can or cannot be checkedout.
    /// </summary>
    /// <param name="item">
    /// Item that is being checked out.
    /// </param>
    /// <returns>
    /// Returns True if can be checked out and False otherwise.
    /// </returns>
    bool CanCheckout(Item item);
}