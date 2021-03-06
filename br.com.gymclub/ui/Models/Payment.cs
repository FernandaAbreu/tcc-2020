﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.models
{
    public class Payment
    {
        public int Id { get; set; }
        public int idRegistration { get; set; }
        public int idTypePlan { get; set; }
        public int idTypePayment { get; set; }
        public DateTime? PaymentDay { get; set; }
        [Display(Name = "Data de vencimento")]
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Client client { get; set; }
        public TypePayment TypePayment { get; set; }
        [Display(Name = "Tipo de Plano")]
        public PlanType planType { get; set; }
    }


    
 
}