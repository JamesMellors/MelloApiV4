using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MelloApiV4.Repository
{
    public interface IDatabaseWriter<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteWhere(Expression<Func<TEntity, bool>> predicate);
        Task Commit();
        void RollBack();
    }
}
