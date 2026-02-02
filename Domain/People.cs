namespace ITCS_3112_Exercise_2.Domain
{
    /// <summary>
    /// Base class representing a person within the system.
    /// Demonstrates the Inheritance requirement (Base Class).
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Gets the unique identifier for the person. 
        /// Set to init to respect the {readonly} requirement in UML.
        /// </summary>
        public int Id { get; init; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Represents a customer who can check out items.
    /// Demonstrates Inheritance (Derived Class).
    /// </summary>
    public class Customer : Person
    {
        public List<Item> Item { get; set; } = new List<Item>();
    }

    /// <summary>
    /// Represents an employee who manages items.
    /// Demonstrates Inheritance (Derived Class).
    /// </summary>
    public class Employee : Person
    {
        public List<Item> Item { get; set; } = new List<Item>();
    }
}