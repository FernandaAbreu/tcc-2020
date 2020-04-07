using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace data.repositories
{
    public interface IRepository<T> where T : class
    {
        System.Collections.IList Search<T>(object p) where T : class;

        IList Search<T>(Expression<Func<T, bool>> predicate) where T : class;

        IList<T> Search<T>(Expression<Func<T, bool>> predicate, string include) where T : class;

        IList<T> Search<T>(Expression<Func<T, bool>> predicate, Expression<Func<T, bool>> orderExpression, int skip, int take) where T : class;

        T SearchVO(Expression<Func<T, bool>> predicate);
        T SearchSingle<T>(Expression<Func<T, bool>> predicate) where T : class;
        T Search(Expression<Func<T, bool>> predicate, string include);
        T Search(string include);
        int GetCount(Func<T, bool> predicate);
        int Save<T>(T entity) where T : class;
        bool Remove<T>(T entity) where T : class;
        bool Update<T>(T entity, int codigo) where T : class;
    }
}
