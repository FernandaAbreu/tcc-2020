using System;
using System.Collections.Generic;
using System.Linq;
using api.context;
using api.models;
using api.repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.repositories
{
    public class InstructorRepository : Repository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public List<Instructor> GetAll()
        {
            return mcontexto.Instructor
                .Include(c => c.city)
                .Include(c => c.User)
                .Include(c => c.state)
                 .Where((c => c.DeletedAt.HasValue.Equals(false))).ToList();
        }

        public Instructor FindById(int id)
        {
            return mcontexto.Instructor
                .Include(c => c.city)
                .Include(c => c.User)
                .Include(c => c.state)
                 .Where(u => u.Id == id)
                 .SingleOrDefault();
        }
        public List<Instructor> GetInstructorByNameOrRGOrCPF(string searchValue)
        {
            return mcontexto.Instructor
                .Include(c => c.city)
                .Include(c => c.User)
                .Include(c => c.state)
                .Where(c => c.User.Name.Contains(searchValue)
                || c.User.Rg.Contains(searchValue)
                || c.User.Cpf.Contains(searchValue)).ToList();

        }

        bool IInstructorRepository.Update(Instructor entity,int codigo)
        {
            return Update(entity,codigo);
        }

        public bool Remove<T>(Instructor entity) where T : class
        {
            return Remove<Instructor>(entity);
        }

        public int Save(Instructor entity)
        {
            var instructor = SaveEntity(entity);
            return instructor.Id;
        }
    }
}
