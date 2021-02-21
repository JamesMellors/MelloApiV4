

using MelloApiV4.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MelloApiV4.Data
{
    public class DapperDatabaseWriter<TEntity> :
        IDatabaseWriter<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly ApplicationDbContext _dbContext;

        public DapperDatabaseWriter(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            var dbEntityEntry = _dbContext.Entry(entity);
            dbEntityEntry.State = EntityState.Added;
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            var dbEntityEntry = _dbContext.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            var dbEntityEntry = _dbContext.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
            _dbContext.Remove(entity);
        }

        public void DeleteWhere(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = _dbContext.Set<TEntity>().Where(predicate);

            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }

            _dbContext.RemoveRange(entities);
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void RollBack()
        {
            var changedEntries = _dbContext.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }



}