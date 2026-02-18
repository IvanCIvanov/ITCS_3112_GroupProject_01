namespace ITCS_3112_Exercise_2.Domain;

    /// <summary>
    /// Represents a single transaction where items are checked out.
    /// Demonstrates the Composition requirement (The "Whole").
    /// </summary>
    

    /// <summary>
    /// Represents a summary of the checkout transaction.
    /// Demonstrates the Composition requirement (The "Part").
    /// </summary>
    public class Receipt
    {
        public string Summary { get; set; }

        /// <summary>
        /// Prints the summary and the details of the items provided.
        /// </summary>
        /// <param name="item">The list of items to print on the receipt.</param>
        public void Print(Item item)
        {
            Console.WriteLine($"--- RECEIPT ---");
            Console.WriteLine($"Summary: {Summary}");
            Console.WriteLine($"- {item.Type} (Status: {item.Status}) (Damages: {item.Damages})");
            
        }
    }
