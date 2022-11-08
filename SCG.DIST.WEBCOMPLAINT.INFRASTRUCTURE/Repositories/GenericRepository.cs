using Microsoft.EntityFrameworkCore;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories;
using SCG.DIST.WEBCOMPLAINT.INFRASTRUCTURE.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.INFRASTRUCTURE.Repositories
{
    public class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToList();
        }

        public IQueryable<TEntity> Query()
        {
            return _dbContext.Set<TEntity>();
        }

        public bool Update(TEntity entity)
        {
            bool saveFailed = false;
            do
            {
                try
                {
                    _dbContext.Entry(entity).State = EntityState.Modified;
                    return true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                }
            } while (saveFailed);
            return true;
        }

        public void DeleteById(int id)
        {
            var entity = GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public int Count()
        {
            return _dbContext.Set<TEntity>().Count();

        }

        public void Commit()
        {
            try
            {
                Validate();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        private void Validate()
        {
            var entities = _dbContext.ChangeTracker.Entries()
                .Where(s => s.State == EntityState.Added || s.State == EntityState.Modified)
                .Select(s => s.Entity);

            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext, validateAllProperties: true);
            }
        }


    }
}
