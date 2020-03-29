using System;
using System.Collections.Generic;

namespace domain.models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int state_id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public IEnumerable<User> Users { get; set; }
        public State state { get; set; }
    }


    
 
}