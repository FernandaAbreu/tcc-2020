using System;
using System.Collections.Generic;
using domain.models;

namespace data.repositories.Interfaces
{
    public interface IPaymentRepository
    {
        public int Save<T>(T entity) where T : class;
        public bool Update<T>(T entity) where T : class;
        IEnumerable<Payment> GetAll();
        List<Payment> GetPaymentsThatAreNotPaidAndNeeded();
        List<Payment> GetPaymentsByNameOrRGOrCPF(string searchValue);
    }
}
