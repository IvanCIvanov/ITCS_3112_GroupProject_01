
namespace ITCS_3112_Exercise_2.Domain;

    /// <summary>
    /// Represents a physical item from the inventory
    /// </summary>
    public class Item
    {
        public long Id { get; init; }
        public string Name { get; set; }
        public TypeEnum Type { get; set; }
        public ConditionEnum Condition { get; set; }
        public StatusEnum Status { get; set; }
        public string Damages { get; set; }
        
        
        /// <summary>
        /// Creates an item that can be used in the repository.
        /// </summary>
        /// <param name="id">
        /// Id of the item.
        /// </param>
        /// <param name="name">
        /// Name of the item.
        /// </param>
        /// <param name="type">
        /// Category of the item.
        /// </param>
        /// <param name="status">
        /// Availability of the item.
        /// </param>
        /// <param name="condition">
        /// Condition of the item.
        /// </param>
        public Item(long id, string name, TypeEnum type, StatusEnum status, ConditionEnum condition){
            Id = id;
            Name = name;
            Type = type;
            Status = status;
            Condition = condition;
        }

        /// <summary>
        /// Acts to override and return a string version regardless of original
        /// type.
        /// </summary>
        /// <returns>
        /// String receipt dictated by its insides.
        /// </returns>
        public override string ToString()
        {
            return $"{Id} | {Name} | {Type} | {Status} | {Condition} ";
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
    }
    
   
    
