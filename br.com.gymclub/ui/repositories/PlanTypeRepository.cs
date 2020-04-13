using System;
using System.Collections.Generic;
using System.Linq;
using api.context;
using api.models;
using api.repositories;
using api.repositories.Interfaces;

namespace ui.repositories
{
    public class PlanTypeRepository : Repository<PlanType>, IPlanTypeRepository
    {
        public PlanTypeRepository(AppDbContext contexto) : base(contexto)
        {
        }



        public List<PlanType> GetAll()
        {
            return SearchAll().OrderBy(c => c.Name).ToList();
        }
    }
}
