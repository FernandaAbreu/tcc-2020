using System;

namespace domain.models
{
    public class ClassClient
    {
        public int Id { get; set; }
        public int idRegistration { get; set; }
        public int idClass { get; set; }
   
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        
    }


    
 
}