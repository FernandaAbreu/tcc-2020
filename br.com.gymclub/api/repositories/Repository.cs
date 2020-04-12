using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using api.context;
using Microsoft.EntityFrameworkCore;

namespace api.repositories
{
    public abstract class Repository<TEntity> : IDisposable where TEntity : class
    {
        protected readonly AppDbContext mcontexto;
        private bool mdisposed = false;
        internal DbSet<TEntity> dbSet;

        public Repository(AppDbContext contexto)
        {
            mcontexto = contexto;
            dbSet = mcontexto.Set<TEntity>();

           
        }

      
        /// <summary>
        /// Retorna todos objetos da entidade manipulada definindo as propriedade para expansão.
        /// </summary>
        /// <returns>Retorna um IQueryable .</returns>
        public IList Search(object p) 
        {
            try
            {
                return dbSet.ToList();
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
        public IList Search(Expression<Func<TEntity, bool>> predicate) 
        {
            try
            {
                return dbSet.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }
        public List<TEntity> SearchAll()
        {
            try
            {
                return dbSet.ToList();
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
        public IList<TEntity> Search(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, bool>> orderExpression, int skip, int take)
        {
            try
            {

                return dbSet.Where(predicate).Distinct().OrderBy(orderExpression).Skip(skip).Take(take).ToList();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public int GetCount(Func<TEntity, bool> predicate)
        {
            try
            {

                return dbSet.Where(predicate).Distinct().Count();
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
        public TEntity SearchVO(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            try
            {

                return dbSet.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public TEntity SearchSingle(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate) 
        {
            try
            {

                return dbSet.Where(predicate).FirstOrDefault();
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
        public TEntity Search(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, string include)
        {
            try
            {

                return dbSet.Include(include).Where(predicate).FirstOrDefault();
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
        public TEntity Search(string include)
        {
            try
            {

                return dbSet.Include(include).FirstOrDefault();
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
        public IList<TEntity> SearchPredcteAndIInclude(Expression<Func<TEntity, bool>> predicate, string include) 
        {
            try
            {
                IList<TEntity> result = dbSet.Include(include).Where(predicate).ToList();
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
        public int Save(TEntity entity) 
        {
            //TODO:metodo de validação das entidades
            try
            {
                dbSet.Add(entity);
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
        public bool Remove(TEntity entity) 
        {

            try
            {
                dbSet.Remove(entity);
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

        public bool Update(TEntity entity) 
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
        public bool Update(TEntity entity, int codigo) 
        {
            //TODO:metodo de validação das entidades
            try
            {


                //if (mcontexto.Entry(entity).State == EntityState.Unchanged)
                // mcontexto.Entry(entity).State = EntityState.Modified;
                var original = dbSet.Find(codigo);
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

        
    }

}
