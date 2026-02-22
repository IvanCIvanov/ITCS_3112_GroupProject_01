namespace ITCS_3112_Exercise_2.Domain;

public class Policy : IPolicy
{
    public bool CanCheckout(Item item)
    {
        // Business Rule: Only available items with known conditions can be checked out.
        return item != null && item.Status == StatusEnum.Available;
    }
}