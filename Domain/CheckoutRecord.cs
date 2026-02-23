namespace ITCS_3112_Exercise_2.Domain;

/// <summary>
/// CheckoutRecord exists to keep track of user requests.
/// It utilizes CheckoutDate, DueDate, Borrower, Item, and Receipt
/// to give the user an accurate representation of the item being checked
/// out.
/// </summary>
public class CheckoutRecord
{
    public DateTime CheckoutDate { get; set; }
    public DateTime DueDate { get; set; }
    public Person Borrower { get; set; }
    public Item Item { get; set; }
    public Receipt Receipt { get; private set; }
    
    
    /// <summary>
    /// Constructor for the CheckoutRecord class.
    /// Represents a completed checkout transaction that ties together an item,
    ///  borrower, dueDate, and summary.
    /// </summary>
    /// <param name="item">
    /// Item being checked out
    /// </param>
    /// <param name="borrower">
    /// Person borrowing the item
    /// </param>
    /// <param name="dueDate">
    /// Associated due date the item must be returned.
    /// </param>
    /// <param name="summary">
    /// Complete summary that ties everything together.
    /// </param>
    public CheckoutRecord(Item item, Person borrower, DateTime dueDate, string summary)
    {
        Item = item;
        Borrower = borrower;
        CheckoutDate = DateTime.Now;
        DueDate = dueDate; 
        
        Receipt = new Receipt { Summary = summary };
    }
}