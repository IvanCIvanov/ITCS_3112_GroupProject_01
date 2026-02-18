namespace ITCS_3112_Exercise_2;

/// <summary>
/// Represents an employee who manages items.
/// Demonstrates Inheritance (Derived Class).
/// </summary>
public class Employee : Person
{
    public List<Item> Item { get; set; } = new List<Item>();
}