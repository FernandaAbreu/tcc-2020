using System;

namespace domain.models
{
    public class Vacation
    {
        public int Id { get; set; }
        public int user_id { get; set; }
        public DateTime initDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Client client { get; set; }
    }


    
 
}