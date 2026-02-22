namespace ITCS_3112_Exercise_2.Domain;

public class Notifier : INotifier
{
    public void AlertDueSoon(CheckoutRecord record)
    {
        Console.WriteLine($"[NOTIFIER] REMINDER: {record.Item.Name} borrowed by {record.Borrower.Name} is due soon ({record.DueDate:yyyy-MM-dd}).");
    }

    public void AlertOverdue(CheckoutRecord record)
    {
        Console.WriteLine($"[NOTIFIER] URGENT: {record.Item.Name} borrowed by {record.Borrower.Name} is OVERDUE!");
    }
}