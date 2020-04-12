using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace api.repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        System.Collections.IList Search(object p);

        IList Search(Expression<Func<T, bool>> predicate);

        IList<T> Search(Expression<Func<T, bool>> predicate, string include);

        IList<T> Search(Expression<Func<T, bool>> predicate, Expression<Func<T, bool>> orderExpression, int skip, int take);

        T SearchVO(Expression<Func<T, bool>> predicate);
        T SearchSingle(Expression<Func<T, bool>> predicate);
 
        T Search(string include);
        int GetCount(Func<T, bool> predicate);
        int Save(T entity) ;
        bool Remove(T entity) ;
        bool Update(T entity, int codigo);
    }
}
