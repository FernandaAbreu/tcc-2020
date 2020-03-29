﻿using System;

namespace domain.models
{
    public class PlanType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public IEnumerable<Payment> payments { get; set; }
    }


    
 
}