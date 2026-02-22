namespace ITCS_3112_Exercise_2
{
    /// <summary>
    /// Represents the different categories of items available in the system.
    /// </summary>
    public enum TypeEnum
    {
        Laptop,
        Sensor,
        Camera,
        Cable,
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
        Lost,
        Reserved
    }

    public enum ConditionEnum
    {
        Good,
        Bad,
        Okay,
        Poor,
        Unknown
    }
}