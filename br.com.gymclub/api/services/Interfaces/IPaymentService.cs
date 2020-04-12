using System;
using System.Collections.Generic;
using api.models;

namespace api.services.Interfaces
{
    public interface IPaymentService
    {

        public bool Update(Payment entity);
        IEnumerable<Payment> GetAll();
        List<Payment> GetPaymentsThatAreNotPaidAndNeeded();
        List<Payment> GetPaymentsByNameOrRGOrCPF(string searchValue);
    }
}
