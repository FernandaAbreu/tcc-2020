using System;
using System.Collections.Generic;
using api.models;

namespace api.repositories.Interfaces
{
    public interface IPaymentRepository
    {
        public int Save(Payment entity);
        public bool Update(Payment entity);
        IEnumerable<Payment> GetAll();
        List<Payment> GetPaymentsThatAreNotPaidAndNeeded(DateTime init,DateTime final);
        List<Payment> GetPaymentsByNameOrRGOrCPF(string searchValue, DateTime init, DateTime final);
    }
}
