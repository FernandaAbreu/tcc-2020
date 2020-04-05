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


    }
}
