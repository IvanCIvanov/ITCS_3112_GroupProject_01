namespace ITCS_3112_Exercise_2
{
    /// <summary>
    /// Represents the different categories of items available in the system.
    /// </summary>
    public enum TypeEnum
    {
        Book,
        NewsPaper,
        GameConsole,
        VrHeadset,
        Dvd,
        Cassette
    }

    /// <summary>
    /// Represents the current status of an item.
    /// </summary>
    public enum StatusEnum
    {
        Available,
        Unavailable,
        CheckedOut,
        Reserved
    }
}