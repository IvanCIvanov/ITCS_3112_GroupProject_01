namespace ITCS_3112_Exercise_2.Domain;
    /// <summary>
    /// Base class representing a person within the system.
    /// Demonstrates the Inheritance requirement (Base Class).
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Gets the unique identifier for the person. 
        /// Set to init to respect the {readonly} requirement in UML.
        /// </summary>
        public long Id { get; init; }
        public string Name { get; set; }
        public string Email { get; set; }


        /// <summary>
        /// Creates a Person based on the details given by the user.
        /// </summary>
        /// <param name="id">
        /// The id of the user.
        /// </param>
        /// <param name="name">
        /// The name of the user.
        /// </param>
        /// <param name="email">
        ///
        /// The email of the user.
        /// </param>
        protected Person(long id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
        
        
        
        
        
        
        
        
        
        
        
        
    }

    
