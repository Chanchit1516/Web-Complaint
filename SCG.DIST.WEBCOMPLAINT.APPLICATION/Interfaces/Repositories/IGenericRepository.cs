using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void DeleteById(int id);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        bool Update(TEntity entity);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int Count();
        IQueryable<TEntity> Query();
        void Commit();
        void Dispose();


    }
}
