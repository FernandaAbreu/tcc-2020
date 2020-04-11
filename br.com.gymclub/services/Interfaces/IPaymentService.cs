using System;
using System.Collections.Generic;
using domain.models;

namespace services.Interfaces
{
    public interface IPaymentService
    {
        public int Save(Payment entity);
        public bool Update(Payment entity);
        IEnumerable<Payment> GetAll();
        List<Payment> GetPaymentsThatAreNotPaidAndNeeded();
        List<Payment> GetPaymentsByNameOrRGOrCPF(string searchValue);
    }
}
