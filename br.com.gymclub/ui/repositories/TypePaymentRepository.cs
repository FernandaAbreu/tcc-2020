using System;
using System.Collections.Generic;
using System.Linq;
using api.context;
using api.models;
using api.repositories;
using api.repositories.Interfaces;

namespace ui.repositories
{
    public class TypePaymentRepository : Repository<TypePayment>, ITypepaymentRepository
    {
        public TypePaymentRepository(AppDbContext contexto) : base(contexto)
        {
        }



        public List<TypePayment> GetAll()
        {
            return SearchAll().OrderBy(c => c.Name).ToList();
        }
    }
}
