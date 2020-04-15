using System;
using System.Collections.Generic;
using System.Linq;
using api.context;
using api.models;
using api.repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public IEnumerable<Payment> GetAll()
        {
            return (System.Collections.Generic.IEnumerable<Payment>)Search(c => c.DeletedAt.HasValue.Equals(false));

        }

        public List<Payment> GetPaymentsByNameOrRGOrCPF(string searchValue, DateTime init, DateTime final)
        {
            return mcontexto.Payment
                 .Include(c => c.planType)
                 .Include(c => c.client)
                     .ThenInclude(c=>c.User)
                .Where(c => (c.client.User.Name.ToUpper().Contains(searchValue.ToUpper()) ||
                c.client.User.Rg.Contains(searchValue) ||
                c.client.User.Cpf.Contains(searchValue))
                && c.DueDate < DateTime.Now && c.PaymentDay ==null
                && c.DueDate >=init && c.DueDate <= final
                && c.DeletedAt.HasValue.Equals(false)).ToList();

        }

        public List<Payment> GetPaymentsThatAreNotPaidAndNeeded(DateTime init, DateTime final)
        {
            return mcontexto.Payment
                 .Include(c => c.planType)
                 .Include(c => c.client)
                 .ThenInclude(c => c.User).Where(c => c.DueDate<DateTime.Now
                  && c.DueDate >= init && c.DueDate <= final
                 && c.PaymentDay==null && c.DeletedAt.HasValue.Equals(false)).ToList();

        }

        public int Save(Payment entity)
        {
            var payment = SaveEntity(entity);
            return payment.Id;
        }
    }
}
