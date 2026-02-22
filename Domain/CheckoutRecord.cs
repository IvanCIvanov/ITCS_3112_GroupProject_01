namespace ITCS_3112_Exercise_2.Domain;

public class CheckoutRecord
{
    public DateTime CheckoutDate { get; set; }
    public DateTime DueDate { get; set; }
    public Person Borrower { get; set; }
    public Item Item { get; set; }
    public Receipt Receipt { get; private set; }
    
    public CheckoutRecord(Item item, Person borrower, DateTime dueDate, string summary)
    {
        Item = item;
        Borrower = borrower;
        CheckoutDate = DateTime.Now;
        DueDate = dueDate; 
        
        Receipt = new Receipt { Summary = summary };
    }
}