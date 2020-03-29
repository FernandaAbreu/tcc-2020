using System;
using System.Collections.Generic;

namespace domain.models
{
    public class TypePayment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public IEnumerable<Payment> payments { get; set; }
        public IEnumerable<Client> clients { get; set; }

    }


    
 
}