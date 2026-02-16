namespace ITCS_3112_Exercise_2.Domain;

/// <summary>
/// Represents a customer who can check out items.
/// Demonstrates Inheritance (Derived Class).
/// </summary>
public class Customer : Person
{
    public List<Item> Item { get; set; } = new List<Item>();
}