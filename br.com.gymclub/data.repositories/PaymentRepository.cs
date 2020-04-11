using System;
using System.Collections.Generic;
using data.repositories.Interfaces;
using datacontexts;
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
            return (System.Collections.Generic.IEnumerable<domain.models.Payment>)Search(c => c.DeletedAt.HasValue.Equals(false));

        }

        public List<Payment> GetPaymentsByNameOrRGOrCPF(string searchValue)
        {
            return (System.Collections.Generic.List<domain.models.Payment>)Search(c => (c.client.User.Name.Contains(searchValue) ||  c.client.User.Rg.Contains(searchValue) || c.client.User.Cpf.Contains(searchValue)) && c.DueDate > DateTime.Now && c.PaymentDay.Equals(null));

        }

        public List<Payment> GetPaymentsThatAreNotPaidAndNeeded()
        {
            return (System.Collections.Generic.List<domain.models.Payment>)Search(c => c.DueDate>DateTime.Now && c.PaymentDay.Equals(null));

        }
    }
}
