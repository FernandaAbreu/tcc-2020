using System;
using System.Collections.Generic;
using data.repositories.Interfaces;
using datacontexts;
using domain.models;

namespace data.repositories
{
    public class LessonsRepository : Repository<Lesson>, ILesssonRepository
    {
        public LessonsRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public IEnumerable<Lesson> GetAll()
        {
            return (System.Collections.Generic.IEnumerable<domain.models.Lesson>)Search(c => c.DeletedAt.HasValue.Equals(false));

        }


    }
}
