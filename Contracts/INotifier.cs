using ITCS_3112_Exercise_2.Domain;
namespace ITCS_3112_Exercise_2;


/// <summary>
/// Defines the notification behavior for checkouts.
/// These are how users are alerted when their due date is coming soon
/// or if they have passed the threshold.
/// </summary>
public interface INotifier
{
    /// <summary>
    /// Sends an alert when the due date is within 24 hours.
    /// </summary>
    /// <param name="record">
    /// Checkout record containing all details about item.
    /// </param>
    void AlertDueSoon(CheckoutRecord record);
    
    /// <summary>
    /// Sends an alert for items that are overdue.
    /// </summary>
    /// <param name="record">
    /// Checkout record representing the overdue item.
    /// </param>
    void AlertOverdue(CheckoutRecord record);
}