using ITCS_3112_Exercise_2.Contracts;
namespace ITCS_3112_Exercise_2.Services;

/// <summary>
/// Used to create a current time reference for checkouts.
/// </summary>
public class SystemClock : IClock
{
    /// <summary>
    /// Returns the current time.
    /// </summary>
    /// <returns>
    /// Returns the current time.
    /// </returns>
    public DateTime GetTime()
    {
        return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
    }
}