namespace ITCS_3112_Exercise_2.Domain;

/// <summary>
/// Creates an instance class for Policy, which will dictate the business rules
/// of the classes.
/// </summary>
public class Policy : IPolicy
{
    /// <summary>
    /// Dictates whether an item can or cannot be checked out depending on
    /// their status.
    /// </summary>
    /// <param name="item">
    /// Item being checked out.
    /// </param>
    /// <returns>
    /// Returns True if the item can be checked out and False if not.
    /// </returns>
    public bool CanCheckout(Item item)
    {
        // Business Rule: Only available items with known conditions can be checked out.
        return item != null && item.Status == StatusEnum.Available;
    }
}