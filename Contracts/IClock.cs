namespace ITCS_3112_Exercise_2.Contracts;

/// <summary>
/// Used as a reference point in the CheckoutService.
/// </summary>
public interface IClock
{
    /// <summary>
    /// Gives the current time that is used as a refernce in CheckoutService.
    /// </summary>
    /// <returns>
    /// Returns the current time.
    /// </returns>
    public DateTime GetTime();
}