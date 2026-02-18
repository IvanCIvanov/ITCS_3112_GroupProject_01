namespace ITCS_3112_Exercise_2
{
    /// <summary>
    /// Represents a physical item from the inventory
    /// </summary>
    public class Item
    {
        public long Id { get; init; }
        public TypeEnum Type { get; set; }
        public StatusEnum Status { get; set; }
        public string Damages { get; set; }
        
    }
}