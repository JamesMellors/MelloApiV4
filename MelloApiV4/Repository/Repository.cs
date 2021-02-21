using Dapper;
using MelloApiV4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MelloApiV4.Repository
{
    public abstract class Repository<TEntity>
          : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly IDatabaseReader<TEntity> DatabaseReader;
        protected readonly IDatabaseWriter<TEntity> DatabaseWriter;

        protected Repository(
            IDatabaseReader<TEntity> databaseReader,
            IDatabaseWriter<TEntity> databaseWriter)
        {
            DatabaseReader = databaseReader;
            DatabaseWriter = databaseWriter;
        }

        public async Task<TEntity> Find(Guid id)
        {
            return await DatabaseReader.Find(id);
        }

        public async Task<IEnumerable<TEntity>> All()
        {
            return await DatabaseReader.All();
        }

        public async Task<IEnumerable<TEntity>> Query(CommandDefinition command)
        {
            return await DatabaseReader.Query(command);
        }

        public async Task<IEnumerable<dynamic>> QueryDynamic(CommandDefinition command)
        {
            return await DatabaseReader.QueryDynamic(command);
        }

        public async Task<TEntity> QueryFirstOrDefault(CommandDefinition command)
        {
            return await DatabaseReader.QueryFirstOrDefault(command);
        }

        public async Task<int> Count(CommandDefinition command)
        {
            return await DatabaseReader.Count(command);
        }

        public void Add(TEntity entity)
        {
            DatabaseWriter.Add(entity);
        }

        public void Update(TEntity entity)
        {
            DatabaseWriter.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            DatabaseWriter.Delete(entity);
        }

        public void DeleteWhere(Expression<Func<TEntity, bool>> predicate)
        {
            DatabaseWriter.DeleteWhere(predicate);
        }

        public async Task Commit()
        {
            await DatabaseWriter.Commit();
        }

        public void RollBack()
        {
            DatabaseWriter.RollBack();
        }
    }
}