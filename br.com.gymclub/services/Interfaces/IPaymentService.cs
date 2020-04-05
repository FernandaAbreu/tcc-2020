﻿using System;
namespace services.Interfaces
{
    public interface IPaymentService
    {
        public int Save<T>(T entity) where T : class;
        public bool Update<T>(T entity) where T : class;
        IEnumerable<Payment> GetAll();
        List<Payment> GetPaymentsThatAreNotPaidAndNeeded();
        List<Payment> GetPaymentsByNameOrRGOrCPF(string searchValue);
    }
}
