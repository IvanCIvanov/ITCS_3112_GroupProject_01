namespace ITCS_3112_Exercise_2.Domain;

/// <summary>
/// Creates an instance that will notify the user on their due date
/// and if they are overdue.
/// </summary>
public class Notifier : INotifier
{
    /// <summary>
    /// Notifies the user if they are near their due date.
    /// </summary>
    /// <param name="record">
    /// Record of the due date.
    /// </param>
    public void AlertDueSoon(CheckoutRecord record)
    {
        Console.WriteLine($"[NOTIFIER] REMINDER: {record.Item.Name} borrowed by {record.Borrower.Name} is due soon ({record.DueDate:yyyy-MM-dd}).");
    }

    /// <summary>
    /// Notifies the user if they are over their due date.
    /// </summary>
    /// <param name="record">
    /// Record of the due date.
    /// </param>
    public void AlertOverdue(CheckoutRecord record)
    {
        Console.WriteLine($"[NOTIFIER] URGENT: {record.Item.Name} borrowed by {record.Borrower.Name} is OVERDUE!");
    }
}