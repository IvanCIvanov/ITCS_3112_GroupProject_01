
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
        public StatusEnum Status { get; set; } = StatusEnum.Available;
        public string Damages { get; set; }
        
        
        public Item(long id, string name, TypeEnum type, StatusEnum status, ConditionEnum condition){
            Id = id;
            Name = name;
            Type = type;
            Status = StatusEnum.Available;
            Condition = condition;
        }

        public override string ToString()
        {
            return $"{Id} | {Name} | {Type} | {Status} | {Condition} ";
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
    }
    
   
    
