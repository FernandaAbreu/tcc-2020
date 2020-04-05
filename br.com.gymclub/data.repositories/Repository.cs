using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace data.repositories
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        protected readonly AppDbContext mcontexto;
        private bool mdisposed = false;
        internal DbSet<T> dbSet;

        public Repository(AppDbContext contexto)
        {
            mcontexto = contexto;
            dbSet = mcontexto.Set<T>();

           
        }

      
        /// <summary>
        /// Retorna todos objetos da entidade manipulada definindo as propriedade para expansão.
        /// </summary>
        /// <returns>Retorna um IQueryable .</returns>
        public IList Search<T>(object p) where T : class
        {
            try
            {
                return mcontexto.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Retorna todos objetos da entidade manipulada definindo as propriedade para expansão.
        /// </summary>
        /// <param name="include">Lista de propriedades para expansão.</param>
        /// <returns>Retorna um IQueryable.</returns>
        //public IList Buscar<T>(params Expression<Func<T, object>>[] include) where T : class
        //{
        //    try
        //    {
        //        if (include.Length == 0)
        //            throw new Exception("Número de parametros inválido.");

        //        var query = mcontexto.Set<T>().AsQueryable();
        //        query = include.Aggregate(query, (current, exp) => current.Include(exp));


        //        return query.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null)
        //            throw new Exception(ex.InnerException.Message, ex);
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        /// <summary>
        /// Retorna os objetos da entidade manipulada de acordo a condição informada.
        /// </summary>
        /// <param name="predicate">Representa a condição a ser buscada pela entidade</param>
        /// <returns>Retorna um IQueryable</returns>
        public IList Search<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return mcontexto.Set<T>().Where(predicate).ToList<T>();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }
        public List<T> SearchAll()
        {
            try
            {
                return mcontexto.Set<T>().ToList<T>();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }




        /// <summary>
        /// Retorna os objetos da entidade manipulada de acordo a condição informada.
        /// </summary>
        /// <param name="predicate">Representa a condição a ser buscada pela entidade</param>
        /// <param name="orderExpression">Representa a ordernação que deseja buscar</param>
        /// <param name="skip">Representa apartir de qual resgistro a busca deve começar a retornar</param>
        /// <param name="take">Representa a quantidade de registros a serem retornados</param>
        /// <returns>Retorna um IQueryable</returns>
        public IList<T> Search(Expression<Func<T, bool>> predicate, Expression<Func<T, bool>> orderExpression, int skip, int take)
        {
            try
            {

                return mcontexto.Set<T>().Where(predicate).Distinct().OrderBy(orderExpression).Skip(skip).Take(take).ToList<T>();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public int GetCount(Func<T, bool> predicate)
        {
            try
            {

                return mcontexto.Set<T>().Where(predicate).Distinct().Count();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }

        }



        /// <summary>
        /// Retorna o primeiro objeto de acordo a condição informada.
        /// </summary>
        /// <param name="predicate">Representa a condição a ser buscada pela entidade</param>
        /// <returns>Retorna o objeto</returns>
        public T SearchVO(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            try
            {

                return mcontexto.Set<T>().Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public T SearchSingle<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {

                return mcontexto.Set<T>().Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }



        /// <summary>
        /// Retorna o primeiro objeto de acordo a condição informada.
        /// </summary>
        /// <param name="predicate">Representa a condição a ser buscada pela entidade</param>
        /// <param name="include">Lista de propriedades para expansão.</param>
        /// <returns>Retorna o objeto</returns>
        public T Search(System.Linq.Expressions.Expression<Func<T, bool>> predicate, string include)
        {
            try
            {

                return mcontexto.Set<T>().Include(include).Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Retorna o primeiro objeto de acordo a condição informada.
        /// </summary>
        /// <param name="include">Lista de propriedades para expansão.</param>
        /// <returns>Retorna o objeto</returns>
        public T Search(string include)
        {
            try
            {

                return mcontexto.Set<T>().Include(include).FirstOrDefault();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Retorna um IQueryable manipulada de acordo a condição informada.
        /// </summary>
        /// <param name="include">Lista de propriedades para expansão.</param>
        /// <param name="predicate">Representa a condição a ser testada pela entidade</param>
        /// <returns>Retorna um IQueryable</returns>
        public IList<T> Search<T>(Expression<Func<T, bool>> predicate, string include) where T : class
        {
            try
            {
                IList<T> result = mcontexto.Set<T>().Include(include).Where(predicate).ToList<T>();
                return result;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Adiciona a entidade indicada.
        /// </summary>
        /// <param name="entity">Entidade a ser incluída.</param>
        /// <returns>Retorna a entidade após a inclusão. Apresentando algum erro retorna null.</returns>
        public int Save<T>(T entity) where T : class
        {
            //TODO:metodo de validação das entidades
            try
            {
                mcontexto.Set<T>().Add(entity);
                return mcontexto.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }


        }
        /// <summary>
        /// Exclui a entidade indicada.
        /// </summary>
        /// <param name="entity">Entidade a ser deletada.</param>
        /// <returns>Retorna true se a entidade for excluido. Caso contrário retorna false.</returns>
        public bool Remove<T>(T entity) where T : class
        {

            try
            {
                mcontexto.Set<T>().Remove(entity);
                mcontexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);

            }
        }
        /// <summary>
        /// Atualiza a entidade indicada.
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada.</param>
        /// <returns>Retorna true se a entidade for atualizado. Caso contrário retorna false.</returns>

        public bool Update<T>(T entity) where T : class
        {
            //TODO:metodo de validação das entidades
            try
            {


                //if (mcontexto.Entry(entity).State == EntityState.Unchanged)
                mcontexto.Entry(entity).State = EntityState.Modified;

                mcontexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }
        public bool Update<T>(T entity, int codigo) where T : class
        {
            //TODO:metodo de validação das entidades
            try
            {


                //if (mcontexto.Entry(entity).State == EntityState.Unchanged)
                // mcontexto.Entry(entity).State = EntityState.Modified;
                var original = mcontexto.Set<T>().Find(codigo);
                mcontexto.Entry(original).CurrentValues.SetValues(entity);
                mcontexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.mdisposed)
            {
                if (disposing)
                {
                    mcontexto.Dispose();
                }
            }
            this.mdisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }











        public IList<T> Search<T>(Expression<Func<T, bool>> predicate, Expression<Func<T, bool>> orderExpression, int skip, int take) where T : class
        {
            try
            {

                return mcontexto.Set<T>().Where(predicate).Distinct().OrderBy(orderExpression).Skip(skip).Take(take).ToList<T>();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        
    }

}
