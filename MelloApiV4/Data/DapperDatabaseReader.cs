using Dapper;
using Dommel;
using MelloApiV4.Data.Connections;
using MelloApiV4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data
{
    public class DapperDatabaseReader<TEntity> :
        IDatabaseReader<TEntity> where TEntity : class, IEntity
    {
        protected IConnectionFactory ConnectionFactory;

        public DapperDatabaseReader(
            IConnectionFactory connectionFactory)
        {
            ConnectionFactory = connectionFactory;
        }

        public async Task<TEntity> Find(Guid id)
        {
            using (var conn = ConnectionFactory.CreatePrimaryConnection())
            {
                await conn.OpenAsync();
                return await conn.GetAsync<TEntity>(id);
            }
        }

        public async Task<IEnumerable<TEntity>> All()
        {
            using (var conn = ConnectionFactory.CreatePrimaryConnection())
            {
                await conn.OpenAsync();
                return await conn.GetAllAsync<TEntity>();
            }
        }

        public async Task<IEnumerable<TEntity>> Query(CommandDefinition command)
        {
            using (var conn = ConnectionFactory.CreatePrimaryConnection())
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<TEntity>(command);
            }
        }

        public async Task<IEnumerable<dynamic>> QueryDynamic(CommandDefinition command)
        {
            using (var conn = ConnectionFactory.CreatePrimaryConnection())
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<dynamic>(command);
            }
        }

        public async Task<int> Count(CommandDefinition command)
        {
            using (var conn = ConnectionFactory.CreatePrimaryConnection())
            {
                await conn.OpenAsync();
                return await conn.ExecuteScalarAsync<int>(command);
            }
        }

        public async Task<TEntity> QueryFirstOrDefault(CommandDefinition command)
        {
            using (var conn = ConnectionFactory.CreatePrimaryConnection())
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<TEntity>(command);
            }
        }
    }
}
