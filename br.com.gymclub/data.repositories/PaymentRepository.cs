using System;
using System.Collections.Generic;
using data.Contexts;
using data.repositories.Interfaces;
using domain.models;

namespace data.repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public IEnumerable<Payment> GetAll()
        {
            return (System.Collections.Generic.IEnumerable<domain.models.Payment>)Search<Payment>(c => c.DeletedAt.HasValue.Equals(false));

        }

        public List<Payment> GetPaymentsByNameOrRGOrCPF(string searchValue)
        {
            return (System.Collections.Generic.List<domain.models.Payment>)Search<Payment>(c => c.client.User.Name.Contains(searchValue) ||  c.client.User.Rg.Contains(searchValue) || c.client.User.Cpf.Contains(searchValue));

        }

        public List<Payment> GetPaymentsThatAreNotPaidAndNeeded()
        {
            return (System.Collections.Generic.List<domain.models.Payment>)Search<Payment>(c => c.DueDate>DateTime.Now && c.PaymentDay.Equals(null));

        }
    }
}
