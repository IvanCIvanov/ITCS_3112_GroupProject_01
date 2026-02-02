namespace ITCS_3112_Exercise_2.Domain
{
    /// <summary>
    /// Represents a single transaction where items are checked out.
    /// Demonstrates the Composition requirement (The "Whole").
    /// </summary>
    public class CheckoutRecord
    {
        public DateTime CheckoutDate { get; set; }
        public DateTime DueDate { get; set; }
        public Person Borrower { get; set; }
        public List<Item> Item { get; set; } = new List<Item>();

        /// <summary>
        /// Composition: The CheckoutRecord "owns" the Receipt.
        /// The Receipt is instantiated here and its lifecycle is tied to this record.
        /// </summary>
        public Receipt Receipt { get; private set; }

        public CheckoutRecord(string summary)
        {
            this.CheckoutDate = DateTime.Now;
            this.DueDate = DateTime.Now.AddDays(7);
            // Instantiating the Receipt inside the constructor ensures Composition.
            Receipt = new Receipt { Summary = summary };
        }
    }

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
        /// <param name="Item">The list of items to print on the receipt.</param>
        public void Print(List<Item> Item)
        {
            Console.WriteLine($"--- RECEIPT ---");
            Console.WriteLine($"Summary: {Summary}");
            Console.WriteLine($"Items Count: {Item.Count}");
            foreach (var i in Item)
            {
                Console.WriteLine($"- {i.Type} (Status: {i.Status}) (Damages: {i.Damages})");
            }
        }
    }
}