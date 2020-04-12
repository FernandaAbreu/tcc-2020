using System;
using System.Collections.Generic;

namespace api.models
{
    public class Client
    {
        public int IdRegistration { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public int idCity { get; set; }
        public int idState { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public int idPlanType { get; set; }
        public int idTypePayment { get; set; }
        public int idUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public User User { get; set; }
        public State state { get; set; }
        public City city { get; set; }
        public  PlanType planType { get; set; }
        public TypePayment typePayment { get; set; }
        public IEnumerable<Vacation> vacations { get; set; }
        public IEnumerable<Payment> payments { get; set; }
        public IEnumerable<Evaluation> evaluations { get; set; }
        public IEnumerable<LessonsClient> lessonsClients { get; set; }
    }


    
 
}