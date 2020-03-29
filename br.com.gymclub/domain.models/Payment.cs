using System;
using System.Collections.Generic;

namespace domain.models
{
    public class Payment
    {
        public int Id { get; set; }
        public int idRegistration { get; set; }
        public int idTypePlan { get; set; }
        public DateTime PaymentDay { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public IEnumerable<Client> Users { get; set; }
        public TypePayment TypePayment { get; set; }
        public PlanType planType { get; set; }
    }


    
 
}