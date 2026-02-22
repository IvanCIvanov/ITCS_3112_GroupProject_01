using ITCS_3112_Exercise_2.Contracts;
namespace ITCS_3112_Exercise_2.Services;

public class SystemClock : IClock
{
    public DateTime GetTime()
    {
        return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
    }
}